using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Activities.Mini.Activity;

public class Activity: AggregateRoot<long>
{
    public string CoverUrl { get; set; }
    public string Subject { get; protected set; }
    public string Content { get; protected set; }
    public DateTime? StartTime { get; protected set; }
    public DateTime? EndTime { get; protected set; }
    public long Creator { get; protected set; }
    public string Address { get; protected set; }
    public List<Attender> Attenders { get; protected set; }

    protected Activity() { }
    public Activity(string subject, string conent)
    {
        Subject = subject;
        Content = conent;
        Attenders = new List<Attender>();
    }
    public void SetStartTime(DateTime? start) { StartTime = start; }
    public void SetEndTime(DateTime? end) { EndTime = end; }
    public void AddAttender(long attenderId)
    {
        if (attenderId == 0) return;

        Attenders.Add(new Attender(attenderId));
    }
}
