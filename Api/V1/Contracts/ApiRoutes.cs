namespace Vue.Apd.Api.V1.Contracts
{
	public static class ApiRoutes
	{
		public const string ApiVersion = "1.0";
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
