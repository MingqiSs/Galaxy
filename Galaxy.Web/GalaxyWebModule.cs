using Galaxy.Order.Application;
using Galaxy.Product.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

namespace Galaxy.Web
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]//注入Mvc
    [DependsOn(typeof(AbpAutofacModule))]//注入autofac
    [DependsOn(typeof(AbpSwashbuckleModule))]//注入Swagger
   [DependsOn(typeof(AbpAspNetCoreAuthenticationJwtBearerModule))]//注入认证授权 jwt

    [DependsOn(typeof(GalaxyProductAppModule))]//注入产品应用层
    [DependsOn(typeof(GalaxyOrderAppModule))]//注入订单应用层
    public class GalaxyWebModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            //注入自动Api控制器
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(GalaxyProductAppModule).Assembly);
                options.ConventionalControllers.Create(typeof(GalaxyOrderAppModule).Assembly);
            });
            //注入apbSwagger
            ConfigureSwaggerServices(context.Services);
            //注入jwt
            ConfigureAuthentication(context, configuration);
            //注册 日志
            context.Services.AddLogging(t => t.AddNLog());
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Galaxy.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddAbpSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Galaxy.Web", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                }
            );
        }
        /// <summary>
        /// 配置jwt
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                    options.Audience = "Galaxy";
                });
        }
    }
}
