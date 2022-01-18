using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.Customer.Application.Contarcts.Models.RP
{
   public class CustomerRP
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 平台账户
        /// </summary>
        public int Account { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>        
        public string Email { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 数据状态
        /// </summary>
        public int DataStatus { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int Gender { get; set; }
        /// <summary>
        /// 手机区号(中国大陆 86,中国香港 852,中国澳门 853,中国台湾886)
        /// </summary>
        public string AreaCode { get; set; }
        /// <summary>
        /// 注册ip
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
