﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Activities.Mini.WxActivities
{
    public class WxUserDto: EntityDto<long>
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
    }
}
