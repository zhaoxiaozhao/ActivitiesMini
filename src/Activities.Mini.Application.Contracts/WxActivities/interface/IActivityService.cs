using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Activities.Mini.WxActivities
{
    public interface IActivityService: ICrudAppService<ActivityDto, long, PagedAndSortedResultRequestDto, CreateUpdateActivityDto>
    {

    }
}
