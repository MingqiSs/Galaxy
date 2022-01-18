using Galaxy.Product.Application.Contarcts;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Modularity;

namespace Galaxy.Product.HttpApi.Clinet
{
    public class ProductHttpApiClinetModule:AbpModule
    {
        public const string RemoteServiceName = "Product";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(GalaxyProductAppContarctsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
