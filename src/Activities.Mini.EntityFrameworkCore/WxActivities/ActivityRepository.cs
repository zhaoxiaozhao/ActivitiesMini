using Activities.Mini.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Activities.Mini.WxActivities
{
    public class ActivityRepository : EfCoreRepository<MiniDbContext, Activity, long>, IActivityRepository
    {
        public ActivityRepository(IDbContextProvider<MiniDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
