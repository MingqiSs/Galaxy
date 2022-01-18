using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.Customer.Application.Contarcts.Models
{
    /// <summary>
    /// 返回结果集（为了跟其他项目对接，统一为小写） 版本 : v.1.4
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultDto<T>
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public int Res { get; set; }

        /// <summary>
        /// 返回码
        /// </summary>
        public ResponseCode Ec { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public T Dt { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Msg { get; set; }

        public ResultDto()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        public ResultDto(T dt)
        {
            Res = 1;
            Ec = (int)ResponseCode.sys_success;
            Msg = "";
            Dt = dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        public ResultDto(ResponseCode code, string msg)
        {
            Res = 0;
            Ec = code;
            Msg = msg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="res"></param>
        /// <param name="ec"></param>
        /// <param name="msg"></param>
        public ResultDto(int res, ResponseCode ec, string msg)
        {
            Res = res;
            Ec = ec;
            Msg = msg;
        }

    }
    /// <summary>
    /// 状态码
    /// </summary>
    public enum ResponseCode
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        [Description("操作成功。")]
        sys_success = 0,

        /// <summary>
        /// 休息一下,马上回来
        /// </summary>
        [Description("休息一下,马上回来。")]
        sys_fail = 1,
        /// <summary>
        /// 参数值格式有误
        /// </summary>
        [Description("参数值格式有误。")]
        sys_param_format_error = 2,
        /// <summary>
        /// 获取资源不存在
        /// </summary>
        [Description("资源不存在。")]
        sys_access_resources_empty = 3,
        /// <summary>
        /// 请勿重复操作。
        /// </summary>
        [Description("请勿重复操作。")]
        sys_repeat_operate = 4,

        /// <summary>
        /// 授权码无效
        /// </summary>
        [Description("授权码无效。")]
        sys_token_invalid = 5,

        /// <summary>
        /// 验证失败
        /// </summary>
        [Description("验证失败。")]
        sys_verify_failed = 6,

        /// <summary>
        /// 上传失败
        /// </summary>
        [Description("上传失败。")]
        sys_upload_fail = 7,

        /// <summary>
        /// 未知错误
        /// </summary>
        [Description("未知错误。")]
        sys_exception = 8,
        /// <summary>
        /// 用户被冻结
        /// </summary>
        [Description("用户被冻结。")]
        user_status_freeze = 11,
        /// <summary>
        /// 首入金额限制
        /// </summary>
        [Description("首入金额限制")]
        FirstDepositLimit = 101,
        /// <summary>
        /// 未绑定
        /// </summary>
        [Description("未绑定。")]
        Unbound = 1001,
        /// <summary>
        /// 绑定失败
        /// </summary>
        [Description("绑定失败。")]
        BindingFailure = 1002,
        /// <summary>
        /// 登录
        /// </summary>
        [Description("登录")]
        Login = 1003,
        /// <summary>
        /// 注册
        /// </summary>
        [Description("注册")]
        Register = 1004
    }
}
