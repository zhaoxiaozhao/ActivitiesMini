using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Activities.Mini.WxActivities
{
    public interface IActivityAppendixRepository : IRepository<ActivityAppendix, long>
    {
    }
}
