using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.Order.Application.Contarcts.Models
{
   public class OrderDto
    {
        /// <summary>
        /// 订单号id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 订单号id
        /// </summary>
        public Guid ProductId { get; set; }
        /// <summary>
        /// 订单名称
        /// </summary>
        public string ProductName { get; set; }
    }
}
