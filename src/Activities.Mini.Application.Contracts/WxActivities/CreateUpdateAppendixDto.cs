using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activities.Mini.WxActivities
{
    public class CreateUpdateAppendixDto
    {
        [Required]
        public long ActivityId { get; set; }
        [Required]
        public int Sort { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
