using System;
using System.Collections.Generic;
using System.Text;

namespace Activities.Mini.WxActivities
{
    public class WxUserRegisterDto
    {
        public string Avatar { get; set; }
        public string MiniOpenId { get; set; }
        public string UnionId { get; set; }
        public string NickName { get; set; }
        public string RealName { get; set; }
        public string Phone { get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int IsChinese { get; set; }
    }
}
