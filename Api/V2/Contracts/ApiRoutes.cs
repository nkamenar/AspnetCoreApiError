namespace Vue.Apd.Api.V2.Contracts
{
	public static class ApiRoutes
	{
		public const string ApiVersion = "2.0";
		public const bool IsDeprecated = false;
		private const string UrlVersion = "v" + ApiVersion;
		public const string Base = "api/" + UrlVersion;

		public static class Records
		{
			public const string GetAll = Base + "/records";
			public const string Get = Base +"/record/{recordId}";
			public const string Create = Base +"/records";
			public const string Update = Base + "/records/{recordId}";
		}
	}
}
