using ApiGateWay.CartService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiGateWay.Controllers
{
    [Route("api/[controller]")]
    public class BasketController : Controller
    {
    
        private readonly URLConfig _urls;
        private readonly ICartService _cartService;

        public BasketController(IOptions<URLConfig> config, ICartService cartService)
        {
            _urls = config.Value;
            _cartService = cartService;
        }
        [HttpGet]
        [Route("BookInfo/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetBooks(int id)
        {
            try
            {
                var booksCategory = await _cartService.GetByIdAsync(id);

                if (booksCategory != null)
                {
                    return Ok(booksCategory);
                }

                return NotFound();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
        }

        
    }
}
