using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Activities.Mini.WxActivities;

public class ActivityUser : Entity
{
    public long Id { get; set; }
    public long WxUserId { get; set; }
    public long ActivityId { get; set; }
    public DateTime AttendTime { get; protected set; }
    protected ActivityUser() { }
    public ActivityUser(long wxUserId, long activityId)
    {
        WxUserId = wxUserId;
        ActivityId = activityId;
        AttendTime = DateTime.Now;
    }
    public override object[] GetKeys()
    {
        throw new NotImplementedException();
    }
}
