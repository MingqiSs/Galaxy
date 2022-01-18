using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Galaxy.Product.HttpApi.Controllers
{
    public abstract  class ProductController : AbpController
    {
        protected ProductController()
        {
          //  LocalizationResource = typeof(BookStoreResource);
        }
    }
}
