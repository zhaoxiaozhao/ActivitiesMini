using Activities.Mini.Core.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Volo.Abp.Caching;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Activities.Mini.Common;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;

namespace Activities.Mini.Core.Extensions
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthLoginAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Token"].ToString();
            var _cache = context.HttpContext.RequestServices.GetService<IDistributedCache<SessionUser>>();
            var sessonUser = _cache.Get(token);
            if(sessonUser == null)
            {
                context.Result = new JsonResult(ApiResult.Failed("Unlogin", 401));
                return;
            }
            else
            {
                return;
            }
        }
    }
}
