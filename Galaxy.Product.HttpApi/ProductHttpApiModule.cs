using Galaxy.Product.Application.Contarcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Galaxy.Product.HttpApi
{

    [DependsOn(
        typeof(GalaxyProductAppContarctsModule)
        )]
    public class ProductHttpApiModule : AbpModule
    {
    }
}
