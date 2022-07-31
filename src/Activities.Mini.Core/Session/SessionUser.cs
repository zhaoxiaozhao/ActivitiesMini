using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activities.Mini.Core.Session
{
    public class SessionUser
    {
        public long WxUserId { get; set; }
        public string OpenId { get; set; }
        public string SessionKey { get; set; }
    }
}
