using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Activities.Mini.WxActivities
{
    [AllowAnonymous]
    public class AppendixService :
        CrudAppService<
            ActivityAppendix,
            ActivityAppendixDto,
            long,
            PagedAndSortedResultRequestDto,
            CreateUpdateAppendixDto>, IAppendixService
    {
  
        public AppendixService(IRepository<ActivityAppendix, long> repository) : base(repository)
        {
            
        }
    }
}
