using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.CrossCutting.DependencyInjector
{
	public static class SwaggerServiceCollectionExtension
	{
		public static IServiceCollection AddSwaggerDocVersion(this IServiceCollection services)
		{
			services.AddSwaggerGen(options =>
			{
				options.CustomSchemaIds(type => type.ToString());
				options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
				{
					Title = "CloudSuite Subscriptions Api DotNet Core version 1.0",
					Version = "v1",
					Contact = new Microsoft.OpenApi.Models.OpenApiContact()
					{
						Email = "lesterlucasit@hotmail.com",
						Name = "Lester Cerioli"
					}
				});
			});
			services.AddApiVersioning(opt =>
			{
				opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
				opt.AssumeDefaultVersionWhenUnspecified = true;
				opt.ReportApiVersions = true;
				opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
					new HeaderApiVersionReader("x-api-version"),
					new MediaTypeApiVersionReader("x-api-version"));
			});
			services.AddVersionedApiExplorer(setup =>
			{
				setup.GroupNameFormat = "'v'VVV";
				setup.SubstituteApiVersionInUrl = true;
			});
			return services;
		}
	}
}
