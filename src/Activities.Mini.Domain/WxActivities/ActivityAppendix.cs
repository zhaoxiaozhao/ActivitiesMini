using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Activities.Mini.WxActivities
{
    public class ActivityAppendix : Entity<long>
    {
        public long ActivityId { get; set; }
        public int Sort { get; set; }
        public int Type { get; set; }
        public string Value { get; set; }

        public ActivityAppendix() { }

        public ActivityAppendix(long activityId, int sort, int type, string value)
        {
            ActivityId = activityId;
            Sort = sort;
            Type = type;
            Value = value;
        }
    }
}
