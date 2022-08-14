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
    public class WxUserRepository : EfCoreRepository<MiniDbContext, WxUser, long>, IWxUserRepository
    {
        public WxUserRepository(IDbContextProvider<MiniDbContext> dbContextProvider)
        : base(dbContextProvider)
        {

        }
        public async Task<WxUser> FindByOpenIdAsync(string openId)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(u => u.MiniOpenId == openId);
        }
    }
}
