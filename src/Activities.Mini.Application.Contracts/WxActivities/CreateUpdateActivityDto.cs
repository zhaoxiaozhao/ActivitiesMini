using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Activities.Mini.WxActivities
{
    public class CreateUpdateActivityDto
    {
        [Required]
        public string CoverUrl { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
