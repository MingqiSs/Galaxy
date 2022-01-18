using Galaxy.Product.Application.Contarcts;
using Galaxy.Product.Domin;
using Galaxy.Product.EntityFrameworkCore;
using System;
using Volo.Abp.Modularity;

namespace Galaxy.Product.Application
{
    [DependsOn(typeof(GalaxyProductDominModule),
       typeof(GalaxyProductEntityFrameworkCoreModule)
        )] 
    public class GalaxyProductAppModule : AbpModule
    {
    }
}
