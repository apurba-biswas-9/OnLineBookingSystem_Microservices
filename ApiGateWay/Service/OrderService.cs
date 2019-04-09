using ApiGateWay.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiGateWay.Service
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _apiClient;
        private readonly URLConfig _urls;
        public OrderService(HttpClient httpClient, IOptions<URLConfig> config)
        {
            _apiClient = httpClient;
            _urls = config.Value;
        }


        public async Task<List<OrderDetails>> GetOrders(int id)
        {
            var data = await _apiClient.GetAsync(_urls.Order + URLConfig.OrderOperations.GetItems(id));
            if (data.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var orders = JsonConvert.DeserializeObject<List<Order>>(await data.Content.ReadAsStringAsync());
                var bookData = await _apiClient.GetStringAsync(_urls.Book + URLConfig.BookOperations.GetItems());
                var books = !string.IsNullOrEmpty(bookData) ? JsonConvert.DeserializeObject<List<BookModel>>(bookData) : null;

                if (orders?.Count > 0)
                {
                    return (from b in orders
                            join p in books on b.BookId equals p.Id into ps
                            from p in ps.DefaultIfEmpty()
                            select new OrderDetails { Id = b.Id,  BookName = p.BooksTitle, TotalPrice = p.Price * b.Quantity, Units = b.Quantity, OrderDate = b.OrderDate, OrderStatus = b.OurderStatus.ToString(), UnitPrice = p.Price, IsCancled = false })
                                   .ToList();
                }
            }
            return null;
        }
    }
}
