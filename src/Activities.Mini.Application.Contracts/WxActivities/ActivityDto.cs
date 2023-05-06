using Activities.Mini.Core.Converter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;

namespace Activities.Mini.WxActivities
{
    public class ActivityDto: EntityDto<long>
    {
        public string CoverUrl { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime StartTime { get; set; }
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime EndTime { get; set; }
        public long Creator { get; set; }
        public string Address { get; set; }
        public List<ActivityUserDto> ActivityUsers { get; set; }
        public List<ActivityAppendixDto> ActivityAppendices { get; set; }
    }
}
