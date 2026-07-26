
using IdentityModel.Client;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.Services.ClientCredentialTokenServices
{
	public class ClientCredentialTokenService : IClientCredentialTokenService
	{
		private readonly HttpClient _httpClient;
		private readonly ServiceApiSettings _serviceApiSettings;
		private readonly ClientSettings _clientSettings;
		private readonly IMemoryCache _memoryCache;

		public ClientCredentialTokenService(HttpClient httpClient, IOptions<ServiceApiSettings> serviceApiSettings, IOptions<ClientSettings> clientSettings, IMemoryCache memoryCache)
		{
			_httpClient = httpClient;
			_serviceApiSettings = serviceApiSettings.Value;
			_clientSettings = clientSettings.Value;
			_memoryCache = memoryCache;
		}

		public async Task<string> GetCredentialToken()
		{
			if (_memoryCache.TryGetValue("multishoptoken", out string cachedToken))
			{
				return cachedToken;
			}

			var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
			{
				Address = _serviceApiSettings.IdentityServerUrl,
				Policy = new DiscoveryPolicy
				{
					RequireHttps = false
				}
			});

			var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
			{
				ClientId = _clientSettings.MultiShopVisitorClient.ClientId,
				ClientSecret = _clientSettings.MultiShopVisitorClient.ClientSecret,
				Address = discoveryEndPoint.TokenEndpoint
			};

			var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);
			if (tokenResponse.IsError)
			{
				throw new Exception("Token alınamadı: " + tokenResponse.ErrorDescription);
			}

			_memoryCache.Set("multishoptoken", tokenResponse.AccessToken, TimeSpan.FromSeconds(tokenResponse.ExpiresIn));
			return tokenResponse.AccessToken;
		}
	}
}
