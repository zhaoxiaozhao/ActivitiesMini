using Activities.Mini.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Activities.Mini.WxActivities
{
    public interface IActivityService: ICrudAppService<ActivityDto, long, PagedAndSortedResultRequestDto, CreateUpdateActivityDto>
    {
        Task<IApiResult> AddUser(CreateActivityUserDto createActivityUserDto);
    }
}
