using Activities.Mini.Common;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Activities.Mini.WxActivities
{
    public interface IWxUserService: IApplicationService
    {
        public Task<IApiResult> RegisterAsync(WxUserRegisterDto dto);

        public Task<IApiResult> LoginAsync(WxUserLoginDto dto);

        public Task<IApiResult> DeleteAsync(string openId);
    }
}
