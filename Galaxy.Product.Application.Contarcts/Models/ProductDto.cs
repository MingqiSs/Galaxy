using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.Product.Application.Contarcts.Models
{
   public class ProductDto
    {
        /// <summary>
        /// 产品id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }
    }
}
