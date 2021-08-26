using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Vue.Apd.Api
{
	public static class ApdApiExtensions
	{
		public static IServiceCollection AddApdApi(this IServiceCollection services)
		{
			services.AddControllers();

			services.AddApiVersioning(options =>
			{
				options.ReportApiVersions = true;
				options.ApiVersionReader = new UrlSegmentApiVersionReader();
				options.AssumeDefaultVersionWhenUnspecified = true;
				options.UseApiBehavior = false;
			});

			services.AddVersionedApiExplorer(options =>
			{
				options.GroupNameFormat = "'v'VVV";
				options.SubstituteApiVersionInUrl = true;
			});
			services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
			services.AddSwaggerGen(options =>
			{
				options.EnableAnnotations();
				options.OperationFilter<SwaggerDefaultValues>();
			});
			services.RegisterApiServices();
			return services;
		}

		public static IApplicationBuilder UseApdApi(this IApplicationBuilder app, IWebHostEnvironment env,
			IConfiguration configuration)
		{
			var swaggerOptions = new SwaggerOptions();
			configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
			if (swaggerOptions.Environments.Contains(env.EnvironmentName))
			{
				app.UseSwagger();
				var apiVersionDescriptionProvider =
					app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();
				app.UseSwaggerUI(options =>
				{
					foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
					{
						options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
							description.GroupName);
					}
				});
			}

			return app;
		}

		private static IServiceCollection RegisterApiServices(this IServiceCollection services)
		{
			//TODO Register API Services here
			services.AddSingleton<V1.Services.Interfaces.IRecordService, V1.Services.RecordService>(); //TODO Remove this
			services.AddSingleton<V2.Services.Interfaces.IRecordService, V2.Services.RecordService>(); //TODO Remove this
			return services;
		}
	}
}
