using System;
using System.Net.Http;
using System.Threading.Tasks;
using Activities.Mini.Core.http;
using Activities.Mini.Core.Session;
using Activities.Mini.Core.Extensions;
using Volo.Abp.Caching;
using Volo.Abp.BlobStoring;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Activities.Mini.Common;
using Microsoft.AspNetCore.Http;
using Volo.Abp.ObjectMapping;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;

namespace Activities.Mini.WxActivities
{
    public class WxUserService : MiniAppService, IWxUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IWxUserRepository _wxUserRepository;
        private readonly IConfiguration _configuration;
        private readonly IDistributedCache<SessionUser> _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WxUserService(
            IConfiguration configuration,
            IDistributedCache<SessionUser> cache,
            IWxUserRepository wxUserRepository,
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _cache = cache;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _wxUserRepository = wxUserRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<IApiResult> LoginAsync(WxUserLoginDto dto)
        {
            ArgumentNullException.ThrowIfNull(nameof(dto));

            var client = _httpClientFactory.CreateClient();
            var appId = _configuration["MiniProgram:AppId"];
            var secret = _configuration["MiniProgram:Secret"];
            var url = $"https://api.weixin.qq.com/sns/jscode2session?appid={appId}&secret={secret}&js_code={dto.Code}&grant_type=authorization_code";
            var result = await client.GetAsync<LoginResultDto>(url);

            var wxUser = await _wxUserRepository.FindByOpenIdAsync(result.openid);
            var sessionUser = new SessionUser()
            {
                OpenId = result.openid,
                SessionKey = result.session_key,
                WxUserId = wxUser?.Id ?? 0
            };

            var cacheKey = (result.session_key + result.openid).GetSHA256Hash();
            await _cache.SetAsync(cacheKey, sessionUser, new DistributedCacheEntryOptions() { SlidingExpiration = TimeSpan.FromHours(2) });

            return ApiResult.Succeed(new 
            { 
                Token = cacheKey,
                UserInfo = wxUser,
                IsRegister = sessionUser.WxUserId > 0
            });
        }

        [HttpPost]
        public async Task<IApiResult> RegisterAsync(WxUserRegisterDto dto)
        {
            ArgumentNullException.ThrowIfNull(nameof(dto));
            var token = _httpContextAccessor.HttpContext.Request.Headers["token"];
            var sessionUser = await _cache.GetAsync(token);
            ArgumentNullException.ThrowIfNull(nameof(sessionUser));
            var wxUser = await _wxUserRepository.FindByOpenIdAsync(sessionUser.OpenId);
            if(wxUser == null)
            {
                dto.MiniOpenId = sessionUser.OpenId;
                wxUser = ObjectMapper.Map<WxUserRegisterDto, WxUser>(dto);
                await _wxUserRepository.InsertAsync(wxUser);
            }
            else
            {
                wxUser.Avatar = dto.Avatar;
                wxUser.Gender = dto.Gender;
                wxUser.NickName = dto.NickName;
                await _wxUserRepository.UpdateAsync(wxUser);
            }
            return ApiResult.Succeed(new { UserInfo = wxUser }, "注册成功");
        }

        [HttpPost]
        public async Task<IApiResult> DeleteAsync(string openId)
        {
            var wxUser = await _wxUserRepository.FindByOpenIdAsync(openId);
            await _wxUserRepository.DeleteAsync(wxUser);
            return ApiResult.Succeed("删除成功");
        }
    }
}
