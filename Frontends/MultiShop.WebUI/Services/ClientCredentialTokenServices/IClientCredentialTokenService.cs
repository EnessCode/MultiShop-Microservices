namespace MultiShop.WebUI.Services.ClientCredentialTokenServices
{
	public interface IClientCredentialTokenService
	{
		Task<string> GetCredentialToken();
	}
}
