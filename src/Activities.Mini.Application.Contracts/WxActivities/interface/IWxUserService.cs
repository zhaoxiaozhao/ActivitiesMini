using Activities.Mini.Common;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Activities.Mini.WxActivities
{
    public interface IWxUserService : IApplicationService
    {
        Task<IApiResult> RegisterAsync(WxUserRegisterDto dto);

        Task<IApiResult> LoginAsync(WxUserLoginDto dto);

        Task<IApiResult> DeleteAsync(string openId);

        Task<IApiResult> GetUserPhoneAsync(string code);
    }
}
