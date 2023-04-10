using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Activities.Mini.WxActivities;

public class Activity: AggregateRoot<long>
{
    public string CoverUrl { get; set; }
    public string Subject { get; protected set; }
    public string Content { get; protected set; }
    public DateTime StartTime { get; protected set; }
    public DateTime EndTime { get; protected set; }
    public long Creator { get; protected set; }
    public string Address { get; protected set; }
    public List<ActivityUser> ActivityUsers { get; set; }
    public List<ActivityAppendix> ActivityAppendices { get; set; }
    protected Activity() { }
    public Activity(string subject, string conent)
    {
        Subject = subject;
        Content = conent;
        ActivityUsers = new List<ActivityUser>();
    }
    public void SetStartTime(DateTime start) { StartTime = start; }
    public void SetEndTime(DateTime end) { EndTime = end; }
    public void AddWxUser(long wxUserId, long activityId)
    {
        ActivityUsers.Add(new ActivityUser(wxUserId, activityId));
    }
}
