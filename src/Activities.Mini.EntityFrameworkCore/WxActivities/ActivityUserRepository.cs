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
    public class ActivityUserRepository : EfCoreRepository<MiniDbContext, ActivityUser, long>, IActivityUserRepository
    {
        public ActivityUserRepository(IDbContextProvider<MiniDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
