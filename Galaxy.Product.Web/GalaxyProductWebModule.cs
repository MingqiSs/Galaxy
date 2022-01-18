using Galaxy.Product.Application;
using Galaxy.Product.Application.Contarcts;
using Galaxy.Product.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Galaxy.Product.Web
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]//注入Mvc
    [DependsOn(typeof(AbpAutofacModule))]//注入autofac
    [DependsOn(typeof(AbpHttpClientModule))]//注入http
    //[DependsOn(typeof(ProductHttpApiModule))]
    [DependsOn(typeof(GalaxyProductAppModule))]//注入应用层
    public class GalaxyProductWebModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            ////配置数据库连接字符串
            //Configure<AbpDbConnectionOptions>(options =>
            //{
            //    options.ConnectionStrings["Default"] = configuration["ConnectionStrings:Default"];
            //});
            //注入自动Api控制器
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(GalaxyProductAppModule).Assembly);
            });
            //注入apbSwagger
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Galaxy.Product.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseUnitOfWork();
        }
        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Galaxy.Product.Web", Version = "v1" });             
                var xmlPath = Path.Combine(AppContext.BaseDirectory, "Galaxy.Product.Application.xml");
                s.DocInclusionPredicate((docName, description) => true);             
                s.IncludeXmlComments(xmlPath);
                s.CustomSchemaIds(type => type.FullName);
            });
        }
    }
}
   
