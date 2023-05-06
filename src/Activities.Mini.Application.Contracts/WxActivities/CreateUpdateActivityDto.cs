using Activities.Mini.Core.Converter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Activities.Mini.WxActivities
{
    public class CreateUpdateActivityDto
    {
        [Required]
        public string CoverUrl { get; set; }
        //[Required]
        public string Subject { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime StartTime { get; set; }
        [Required]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime EndTime { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public long Creator { get; set; }
        public List<ActivityUserDto> ActivityUsers { get; set; }
        public List<ActivityAppendixDto> ActivityAppendices { get; set; }
    }
}
