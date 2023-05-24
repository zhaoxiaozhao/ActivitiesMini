using Activities.Mini.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Activities.Mini.WxActivities
{
    public class AppendixRepository : EfCoreRepository<MiniDbContext, ActivityAppendix, long>, IAppendixRepository
    {
        public AppendixRepository(IDbContextProvider<MiniDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<ActivityAppendix> FindByActivityIdAsync(long activityId)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(u => u.ActivityId == activityId);
        }
    }
}
