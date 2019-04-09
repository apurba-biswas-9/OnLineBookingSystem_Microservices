using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Order.ExternalService
{
    public class CartService : ICartService
    {
        private readonly HttpClient _apiClient;
        private readonly URLConfig _urls;
        public CartService(HttpClient httpClient, IOptions<URLConfig> config)
        {
            _apiClient = httpClient;
            _urls = config.Value;
        }

        public async Task DeleteAsync(int id)
        {
            var cartData = await _apiClient.DeleteAsync(_urls.Cart + URLConfig.CartOperations.GetDeleteApi(id));           

        }
    }
}
