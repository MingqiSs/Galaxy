using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Galaxy.Product.Domin
{
    [Table("app_product")]
    public class AppProduct : AggregateRoot<Guid>
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }
    }
}
