using Galaxy.Product.Application.Contarcts;
using Galaxy.Product.Application.Contarcts.Models;
using Galaxy.Product.Domin;
using Galaxy.Product.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Galaxy.Product.Application
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductService : ApplicationService, IProductService
    {
        private readonly IRepository<AppProduct, Guid> _appProductRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appProductRepository"></param>
        public ProductService(IRepository<AppProduct, Guid> appProductRepository
                              )
        {

            _appProductRepository = appProductRepository;
        }
        /// <summary>
        /// 获取商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductDto> GetAsync(Guid id)
        {
            var p = new ProductDto() { };
            var model = await _appProductRepository.GetAsync(q => q.Id == id);
            if (model != null)
            {
                p.Id = model.Id;
                p.Name = model.Name;
            }
            return p;
        }
        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<ProductDto>> GetListAsync()
        {
            var list = await _appProductRepository.GetListAsync();
            var p = new List<ProductDto>() { };
            foreach (var item in list)
            {
                p.Add(new ProductDto
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }
            return p;
        }
        /// <summary>
        /// 创建产品
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ProductDto> CreateAsync(ProductDto input)
        {
            //Check.NotNullOrWhiteSpace(name, nameof(name));
            var p = new ProductDto() { };
            var model = new AppProduct
            {
                Name = input.Name,
            };
            try
            {
                await _appProductRepository.InsertAsync(model, autoSave: true);
            }
            catch (Exception ex)
            {

                throw;
            }
           
            return p;
        }

        /// <summary>
        /// 测试自定义HTTP Method
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        ///  //如果需要为特定方法自定义HTTP Method, 则可以使用标准ASP.NET Core的属性([HttpPost], [HttpGet], [HttpPut]... 等等.). 这需要添加Microsoft.AspNetCore.Mvc.Core的Nuget包.
        [HttpGet]
        public ProductDto TestHTTPMethod(string input)
        {
            var p = new ProductDto() { };

            return p;
        }
    }
}
