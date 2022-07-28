using System;
using System.Collections.Generic;
using System.Text;

namespace Activities.Mini.WxActivities
{
    public class LoginResultDto: WxResultBase
    {
        public string openid { get; set; }
        public string session_key { get; set; }
        public string unionid { get; set; }
    }
}
