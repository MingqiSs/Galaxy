using Galaxy.Customer.Application.Contarcts.Models;
using Galaxy.Customer.Application.Contarcts.Models.RP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Galaxy.Customer.Application.Contarcts
{
    public interface ICustomerService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<ResultDto<CustomerRP>> LoginAsync(CustomerLoginRQ rq);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<ResultDto<CustomerRP>> RegisterAsync(RegisterRQ rq);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        Task<ResultDto<CustomerRP>> GetCustomerInfoAsync(Guid id);
    }
}
