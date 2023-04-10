using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Activities.Mini.WxActivities
{
    public class ActivityAppendixDto: EntityDto<long>
    {
        public int Sort { get; set; }
        public int Type { get; set; }
        public string Value { get; set; }
    }
}
