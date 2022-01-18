using Galaxy.Product.Application.Contarcts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Galaxy.Product.Application.Contarcts
{
    public interface IProductService:IApplicationService
    {
        /// <summary>
        /// 获取产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         Task<ProductDto> GetAsync(Guid id);
        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <returns></returns>
        Task<List<ProductDto>> GetListAsync();
        /// <summary>
        /// 创建产品
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ProductDto> CreateAsync(ProductDto input);

    }
}
