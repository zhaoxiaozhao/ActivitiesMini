using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Activities.Mini.WxActivities
{
    public interface IAppendixService : ICrudAppService<ActivityAppendixDto, long, PagedAndSortedResultRequestDto, CreateUpdateAppendixDto>
    {

    }
}
