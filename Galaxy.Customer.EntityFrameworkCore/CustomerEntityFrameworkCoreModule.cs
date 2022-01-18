using Galaxy.Customer.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Modularity;

namespace Galaxy.Customer.EntityFrameworkCore
{

    [DependsOn(typeof(AbpEntityFrameworkCoreModule),
      typeof(AbpEntityFrameworkCoreMySQLModule),
      typeof(CustomerDomainModule)
)]
    public class CustomerEntityFrameworkCoreModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            //MCBKRDemoEfCoreEntityExtensionMappings.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CustomerDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                // 默认情况下为每个聚合根实体(AggregateRoot派生的子类)创建一个仓储.如果想要为其他实体也创建仓储 请将includeAllEntities 设置为 true
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseMySQL();
            });
        }
    }
}
