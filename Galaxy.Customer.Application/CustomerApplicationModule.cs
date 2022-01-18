using Galaxy.Customer.Domain;
using Galaxy.Customer.EntityFrameworkCore;
using System;
using Volo.Abp.Modularity;

namespace Galaxy.Customer.Application
{
    /// <summary>
    /// 
    /// </summary>
    [DependsOn(typeof(CustomerDomainModule),
      typeof(CustomerEntityFrameworkCoreModule)
       )]
    public class CustomerApplicationModule : AbpModule
    {
    }
}
