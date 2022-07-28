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

        public ActivityService(
            IRepository<Activity, long> repository, 
            IActivityUserRepository activityUserRepository) : base(repository)
        {
            _activityUserRepository = activityUserRepository;
        }
    }
}
