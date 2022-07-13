using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Activities.Mini.WxActivities;

public class WxUser : AggregateRoot<long>
{
    public string Avatar { get; set; }
    public string MiniOpenId { get; set; }
    public string UnionId { get; set; }
    public string NickName { get; set; }
    public string RealName { get; set; }
    public int Gender { get; set; }
    public int Age { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public int IsChinese { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    protected WxUser() { }
    public WxUser(long id)
    {
        Id = id;
    }
    public override object[] GetKeys()
    {
        throw new NotImplementedException();
    }
}

