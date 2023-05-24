using Activities.Mini.Core.Converter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;

namespace Activities.Mini.WxActivities
{
    public class ActivityUserDto: EntityDto<long>
    {
        public long WxUserId { get; set; }
        public long ActivityId { get; set; }
        public WxUserDto User { get; set; }
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime AttendTime { get; set; }
    }
}
