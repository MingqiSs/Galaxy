using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Galaxy.Customer.Domain.Entities
{
    [Table("App_Customer")]
    public class AppCustomer : AggregateRoot<Guid>
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 平台账户
        /// </summary>
        public int  Account { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>        
        public string Email { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(300)")]
        public string Mobile { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 数据状态
        /// </summary>
        public int DataStatus { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int Gender { get; set; }
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
