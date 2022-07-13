using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Activities.Mini.WxActivities
{
    public class ActivityUserDto: EntityDto<long>
    {
        public long WxUserId { get; set; }
        public long ActivityId { get; set; }
        public DateTime AttendTime { get; set; }
    }
}
