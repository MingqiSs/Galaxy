using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.Customer.Application.Contarcts.Models.RP
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerLoginRQ
    {
        /// <summary>
        ///登录类型 (1:密码登录;2:验证码登录)
        /// </summary>
       // [Range(1, 2)]
        //[Required]
       // public byte Type { get; set; }
        /// <summary>
        /// 账号(手机号)
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [JsonProperty("Pwd")]
        public string Pwd { get; set; }
        /// <summary>
        /// 设备名称 
        /// </summary>
        public string DeviceName { get; set; }
        /// <summary>
        /// 设备系统
        /// </summary>
        public string DeviceSystem { get; set; }
        /// <summary>
        /// 设备型号 
        /// </summary>
        public string DeviceType { get; set; }
    }
    public class RegisterRQ
    {
        /// <summary>
        /// 账号(手机号)
        /// </summary>
        [Required]
        public string Mobile { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        public string PwdConfirm { get; set; }
        /// <summary>
        /// 设备名称 
        /// </summary>
        public string DeviceName { get; set; }
        /// <summary>
        /// 设备系统
        /// </summary>
        public string DeviceSystem { get; set; }
        /// <summary>
        /// 设备型号 
        /// </summary>
        public string DeviceType { get; set; }
    }
}
