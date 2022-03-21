using Galaxy.Customer.Application.Contarcts;
using Galaxy.Customer.Application.Contarcts.Models;
using Galaxy.Customer.Application.Contarcts.Models.RP;
using Galaxy.Customer.Domain.Entities;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Galaxy.Customer.Application
{
    /// <summary>
    /// 客户服务
    /// </summary>
    public class CustomerService : ApplicationService, ICustomerService
    {
        private readonly IRepository<AppCustomer, Guid> _appCustomersRepo;
        /// <summary>
        /// 客户服务
        /// </summary>
        /// <param name="appCustomersRepo"></param>
        public CustomerService(IRepository<AppCustomer, Guid> appCustomersRepo)
        {
            _appCustomersRepo = appCustomersRepo;
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResultDto<CustomerRP>> GetCustomerInfoAsync(Guid id)
        {
            var result = new CustomerRP
            {
            };
            var customer = await _appCustomersRepo.FindAsync(q => q.Id == id);

            return new ResultDto<CustomerRP> { Dt = result };
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public async Task<ResultDto<CustomerRP>> LoginAsync(CustomerLoginRQ rq)
        {
            var result = new CustomerRP
            {
            };
            var customer = await _appCustomersRepo.FindAsync(q => q.Mobile == rq.Mobile && q.Pwd == rq.Pwd);
            if (customer == null)
            {
                return new ResultDto<CustomerRP>(ResponseCode.sys_param_format_error,"未找到用户,请先注册");
            }
            result.Account = customer.Account;
            result.Email = customer.Email;
            result.Id = customer.Id;
           
            //HttpContext.Response.Headers.Add("Authorization", new StringValues(""));
            return new ResultDto<CustomerRP> { Dt = result };
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>

        public async Task<ResultDto<CustomerRP>> RegisterAsync(RegisterRQ rq)
        {
            var result = new CustomerRP
            {
            };
            var model= new AppCustomer()
            {
                Account=1,
                DataStatus=1,
                CreateTime=DateTime.Now,
                Mobile=rq.Mobile,
                Pwd=rq.Pwd,
                Email=String.Empty,
                IP=String.Empty,
                Name=String.Empty,
                Remark=String.Empty,
            };
            var customer = await _appCustomersRepo.InsertAsync(model);
            result.Account = customer.Account;
            result.Email = customer.Email;
            result.Id = customer.Id;
            return new ResultDto<CustomerRP> { Dt= result };
        }
    }
}
