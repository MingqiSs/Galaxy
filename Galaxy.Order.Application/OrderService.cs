using Galaxy.Order.Application.Contarcts.Models;
using Galaxy.Product.Application.Contarcts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;

namespace Galaxy.Order.Application
{
    //[Authorize]
    public class OrderService : ApplicationService
    {
        public static List<OrderDto> Orders = new List<OrderDto> { new OrderDto { Id = "12345",ProductId=new Guid("3a00a5cb-28bf-e09d-44ae-b96d7ca0e8e0") }, new OrderDto { Id = "54321", ProductId = new Guid("3a00a5cb-28bf-e09d-44ae-b96d7ca0e8e0") } };
        private readonly  IProductService _productService;
        private readonly ILogger<OrderService> _logger;//日志使用
        private readonly IDistributedCache<OrderDto, string> _cache;//缓存使用
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productService"></param>
        /// <param name="logger"></param>
        /// <param name="cache"></param>
        public OrderService(IProductService productService,
                               ILogger<OrderService> logger,
                               IDistributedCache<OrderDto, string> cache
            )
        {
            _productService = productService;
            _logger = logger;
           _cache = cache;
        }

        //[AllowAnonymous]
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OrderDto> GetAsync(string id)
        {
            _logger.LogInformation("获取GetAsync 方法");
            var order = Orders.Where(q => q.Id == id).FirstOrDefault();
            if (order != null)
            { 

               var p =await _productService.GetAsync(order.ProductId);

                order.ProductName = p?.Name ?? string.Empty;
            }
            return order;
        }
        /// <summary>
        /// 获取(缓存示例)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OrderDto> GetCacheAsync(string id)
        {
            return await _cache.GetOrAddAsync(
              $"order_{id}",
              async () => await GetAsync(id),
              () => new DistributedCacheEntryOptions
              {
                  AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
              }
          );
        }
        /// <summary>
        /// /获取(授权)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Authorize("BookStore_Author_Create")]
        public async Task<OrderDto> GetAuthorAsync(string id)
        {
            return await GetAsync(id);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public async Task<List<OrderDto>> GetListAsync()
        //{
        //    Thread.Sleep(TimeSpan.FromSeconds(1));
        //    var list = Orders;
        //    return list;
        //}

     
    }
}
