using System;
using System.Net.Http;
using System.Threading.Tasks;
using Activities.Mini.Core.http;
using Activities.Mini.Core.Session;
using Activities.Mini.Core.Extensions;
using Volo.Abp.Caching;
using Volo.Abp.BlobStoring;
using Microsoft.Extensions.Caching.Distributed;

namespace Activities.Mini.WxActivities
{
    public class WxUserService : MiniAppService, IWxUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IWxUserRepository _wxUserRepository;
        private readonly IDistributedCache<SessionUser> _cache;

        public WxUserService(
            IHttpClientFactory httpClientFactory,
            IWxUserRepository wxUserRepository,
            IDistributedCache<SessionUser> cache,
            IBlobContainer blobContainer
            )
        {
            _httpClientFactory = httpClientFactory;
            _wxUserRepository = wxUserRepository;
            _cache = cache;
        }

        public async Task<LoginResultDto> LoginAsync(WxUserLoginDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var appId = "wx5d3c5102b7faae1d";
            var secret = "3ad58c5b0776b02e7447625d82be92c8";
            var url = $"https://api.weixin.qq.com/sns/jscode2session?appid={appId}&secret={secret}&js_code={dto.Code}&grant_type=authorization_code";
            var result = await client.GetAsync<LoginResultDto>(url);      
            
            var wxUser = await _wxUserRepository.GetAsync(m=>m.MiniOpenId == result.openid);
            var sessionUser = new SessionUser()
            {
                OpenId = result.openid,
                SessionKey = result.session_key,
                WxUserId = wxUser?.Id ?? 0
            };

            var cacheKey = (result.session_key + result.openid).GetSHA256Hash();
            await _cache.SetAsync(cacheKey, sessionUser, new DistributedCacheEntryOptions() { SlidingExpiration = TimeSpan.FromHours(2) });

            return result;
        }

        public Task<RegisterResultDto> RegisterAsync(WxUserRegisterDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
