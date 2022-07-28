using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Activities.Mini.Core.http;

namespace Activities.Mini.WxActivities
{
    public class WxUserService : MiniAppService, IWxUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public WxUserService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<LoginResultDto> LoginAsync(WxUserLoginDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var appId = "wx5d3c5102b7faae1d";
            var secret = "3ad58c5b0776b02e7447625d82be92c8";
            var url = $"https://api.weixin.qq.com/sns/jscode2session?appid={appId}&secret={secret}&js_code={dto.Code}&grant_type=authorization_code";
            var result = await client.GetAsync<LoginResultDto>(url);
            return result;
        }

        public RegisterResultDto Register(WxUserRegisterDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
