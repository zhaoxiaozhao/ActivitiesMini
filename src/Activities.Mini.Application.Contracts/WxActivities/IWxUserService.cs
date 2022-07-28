using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Activities.Mini.WxActivities
{
    public interface IWxUserService: IApplicationService
    {
        public RegisterResultDto Register(WxUserRegisterDto dto);

        public Task<LoginResultDto> LoginAsync(WxUserLoginDto dto);
    }
}
