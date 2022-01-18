using Galaxy.Order.Application;
using Galaxy.Product.Application.Contarcts;
using Galaxy.Product.HttpApi.Clinet;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Galaxy.Order.Web
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]//注入Mvc
    [DependsOn(typeof(AbpAutofacModule))]//注入autofac
    [DependsOn(typeof(AbpHttpClientModule))]//注入http

    [DependsOn(typeof(GalaxyOrderAppModule))]//注入应用层
    [DependsOn(typeof(GalaxyProductAppContarctsModule))]

    [DependsOn(typeof(ProductHttpApiClinetModule))]
    
    public class GalaxyOrderWebModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            //获取配置文件
            var configuration = context.Services.GetConfiguration();

            //注入自动Api控制器
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(GalaxyOrderAppModule).Assembly);
            });
            ////创建动态客户端代理
            //context.Services.AddHttpClientProxies(
            //    typeof(GalaxyProductAppContarctsModule).Assembly,
            //    remoteServiceConfigurationName: "Product"  //代理名称
            //);
            ConfigureSwaggerServices(context.Services);
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Galaxy.Order.Web v1"));
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
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Galaxy.Order.Web", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                }
            );
        }
    }
}
