using ApiGateWay.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiGateWay.CartService
{
    public class CartService  : ICartService
    {

        private readonly HttpClient _apiClient;
        private readonly URLConfig _urls;
        public CartService(HttpClient httpClient, IOptions<URLConfig> config)
        {
            _apiClient = httpClient;
            _urls = config.Value;
        }

        public async Task<List<BookModel>> GetByIdAsync(int id)
        {
            var cartData = await _apiClient.GetAsync(_urls.Cart + URLConfig.CartOperations.GetItemById(id));
            if (cartData.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var cart = JsonConvert.DeserializeObject<List<CartModel>>(await cartData.Content.ReadAsStringAsync());

                var bookData = await _apiClient.GetStringAsync(_urls.Book + URLConfig.BookOperations.GetItems());
                var books = !string.IsNullOrEmpty(bookData) ? JsonConvert.DeserializeObject<List<BookModel>>(bookData) : null;

                if (cart?.Count > 0)
                {
                    return (from b in cart
                            join p in books on b.BookId equals p.Id into ps
                            from p in ps.DefaultIfEmpty()
                            select new BookModel { Id = p.Id, BooksTitle = p.BooksTitle, Price = p.Price, isSelected = p.isSelected, Units = p.Units, CartId = b.Id })
                                   .ToList();
                }
            }
            return null;   
        }

      
    }
}
