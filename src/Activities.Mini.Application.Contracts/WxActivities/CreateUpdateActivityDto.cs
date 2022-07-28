using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Activities.Mini.WxActivities
{
    public class CreateUpdateActivityDto
    {
        [Required]
        [MaxLength(200)]
        public string CoverUrl { get; set; }
        [Required]
        [MaxLength(200)]
        public string Subject { get; set; }
        [Required]
        [MaxLength(200)]
        public string Content { get; set; }
        [Required]
        [MaxLength(200)]
        public DateTime StartTime { get; set; }
        [Required]
        [MaxLength(200)]
        public DateTime EndTime { get; set; }
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }
    }
}
