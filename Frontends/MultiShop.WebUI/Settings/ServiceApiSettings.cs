namespace MultiShop.WebUI.Settings
{
	public class ServiceApiSettings
	{
		public string OcelotUrl { get; set; }
		public string IdentityServerUrl { get; set; }
		public ServerApi Catalog { get; set; }
		public ServerApi Discount { get; set; }
		public ServerApi Order { get; set; }
		public ServerApi Cargo { get; set; }
		public ServerApi Basket { get; set; }
		public ServerApi Comment { get; set; }
		public ServerApi Message { get; set; }
	}

	public class ServerApi
	{
		public string Path { get; set; }
	}
}
