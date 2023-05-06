using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp.Application.Services;
using static IdentityServer4.IdentityServerConstants;

namespace Activities.Mini.WxActivities
{
    public class WeChatAppService : MiniAppService, IWeChatAppService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<WeChatAppService> _logger;
        public WeChatAppService(IHttpClientFactory httpClientFactory, ILogger<WeChatAppService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<string> GetAccessToken(string appId, string appSecret)
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={appId}&secret={appSecret}");

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(responseContent);

                string message = $"GetAccessToken:{json}";
                _logger.LogInformation(message);

                return json["access_token"]?.ToString() ?? string.Empty;
            }

            throw new Exception("Failed to get access token.");
        }

        public async Task<string> GetUserPhoneAsync(string accessToken, string code)
        {
            var client = _httpClientFactory.CreateClient();
            var data = new { code };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var url = $"https://api.weixin.qq.com/wxa/business/getuserphonenumber?access_token={accessToken}";
            var response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                string message = $"wx_getuserphonenumber:{responseContent}";
                _logger.LogInformation(message);
                var json = JObject.Parse(responseContent);
                return json["phone_info"]?["phoneNumber"]?.ToString() ?? string.Empty;
            }
            throw new Exception("Failed to get user phone number.");
        }

    }
}
