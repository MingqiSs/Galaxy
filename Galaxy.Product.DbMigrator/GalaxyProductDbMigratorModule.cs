using Galaxy.Product.Application.Contarcts;
using Galaxy.Product.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Galaxy.Product.DbMigrator
{
    [DependsOn(
    typeof(AbpAutofacModule),
    typeof(GalaxyProductEntityFrameworkCoreModule),
    typeof(GalaxyProductAppContarctsModule)
    )]
    class GalaxyProductDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
  
}
