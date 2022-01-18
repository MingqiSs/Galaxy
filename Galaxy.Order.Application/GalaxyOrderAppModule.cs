using System;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace Galaxy.Order.Application
{
    [DependsOn(typeof(AbpCachingModule))] //注入缓存
    public class GalaxyOrderAppModule: AbpModule
    {
    }
}
