using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.ObjectMapping;
using System.Reflection;
using Activities.Mini.Common;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;
using Microsoft.AspNetCore.Http;
using Activities.Mini.Core.Session;
using Volo.Abp.Caching;
using Activities.Mini.Core.Extensions;

namespace Activities.Mini.WxActivities
{
    [AllowAnonymous]
    [AuthLoginAttribute]
    public class ActivityService : 
        CrudAppService<
            Activity,
            ActivityDto,
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateActivityDto>,
        IActivityService
    {
        private readonly IActivityUserRepository _activityUserRepository;
        private readonly IAppendixRepository _appendixRepository;
        private readonly IWxUserRepository _wxUserRepository;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDistributedCache<SessionUser> _cache;
        //private readonly IObjectMapper<MiniApplicationModule> _mapper;

        public ActivityService(
            IRepository<Activity, long> repository,
            IAppendixRepository appendixRepository,
            IWxUserRepository wxUserRepository,
            IDistributedCache<SessionUser> cache,
            IHttpContextAccessor httpContextAccessor,
            IActivityUserRepository activityUserRepository) : base(repository)
        {
            //_mapper = mapper;
            _cache = cache;
            _activityUserRepository = activityUserRepository;
            _appendixRepository = appendixRepository;
            _wxUserRepository = wxUserRepository;
            _httpContextAccessor = httpContextAccessor;
            ObjectMapperContext = typeof(MiniApplicationModule);
        }

        [HttpPost]
        public async Task<IApiResult> AddUser(CreateActivityUserDto createActivityUserDto)
        {
            var user = await _wxUserRepository.GetAsync(createActivityUserDto.WxUserId);

            var avitityUser = await _activityUserRepository.GetListAsync(m => m.ActivityId == createActivityUserDto.ActivityId && m.WxUserId == createActivityUserDto.WxUserId);

            if (avitityUser == null)
            {
                await _activityUserRepository.InsertAsync(new ActivityUser(createActivityUserDto.WxUserId, createActivityUserDto.ActivityId));
            }

            return ApiResult.Succeed(user);
        }

        [HttpGet]
        public override async Task<ActivityDto> GetAsync(long id)
        {
            var token = _httpContextAccessor.HttpContext.Request.Headers["token"].ToString();
            var sessonUser = await _cache.GetAsync(token);
            var activity = await  base.GetAsync(id);
            var appendices = await _appendixRepository.GetListAsync(m => m.ActivityId == id);
            var users = await _activityUserRepository.GetListAsync(m => m.ActivityId == id);
            var wxUsers = await _wxUserRepository.GetListAsync(m => users.Select(n => n.WxUserId).Contains(m.Id));
            var list = ObjectMapper.Map<List<ActivityAppendix>, List<ActivityAppendixDto>>(appendices);
            var userDtos = ObjectMapper.Map<List<ActivityUser>, List<ActivityUserDto>>(users);
            var wxUserDtos = ObjectMapper.Map<List<WxUser>, List<WxUserDto>>(wxUsers);
            foreach (var item in userDtos)
            {
                item.User = wxUserDtos.FirstOrDefault(m => m.Id == item.WxUserId);
            }
            activity.ActivityAppendices = list;
            activity.ActivityUsers = userDtos;

            activity.IsAttend = userDtos.Any(m=>m.WxUserId == sessonUser.WxUserId);

            return activity;
        }
    }
}
