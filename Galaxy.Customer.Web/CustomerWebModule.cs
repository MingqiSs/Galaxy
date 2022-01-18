using Galaxy.Customer.Application;
using Galaxy.Customer.Web.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using System;
using System.IO;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Galaxy.Customer.Web
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]//注入Mvc
    [DependsOn(typeof(AbpAutofacModule))]//注入autofac
    [DependsOn(typeof(AbpHttpClientModule))]//注入http
    [DependsOn(typeof(CustomerApplicationModule))]//注入应用层
    public class CustomerWebModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

           
            ////配置数据库连接字符串
            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings["Default"] = configuration["ConnectionStrings:Default"];
            });
            //注入自动Api控制器
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(CustomerApplicationModule).Assembly);
            });
            //注入apbSwagger
            ConfigureSwaggerServices(context.Services);

            context.Services.AddLogging(t => t.AddNLog());

            context.Services.AddMvc().AddMvcOptions(options =>
            {
                options.Filters.Add(typeof(CustomExceptionFilterAttribute));
            });
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Galaxy.Customer.Web v1"));
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
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Galaxy.Customer.Web", Version = "v1" });
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, "Galaxy.Customer.Application.xml");
                s.DocInclusionPredicate((docName, description) => true);
                //s.IncludeXmlComments(xmlPath);
                s.CustomSchemaIds(type => type.FullName);
            });
        }
    }
}
