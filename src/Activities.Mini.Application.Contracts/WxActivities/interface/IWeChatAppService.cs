using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Activities.Mini.WxActivities
{
    public interface IWeChatAppService : IApplicationService
    {
        Task<string> GetAccessToken(string appId, string appSecret);

        Task<string> GetUserPhoneAsync(string accessToken, string code);
    }
}
