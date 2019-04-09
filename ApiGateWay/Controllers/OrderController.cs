using ApiGateWay.CartService;
using ApiGateWay.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiGateWay.Controllers
{
    [Route("api/[controller]")]
    public class OrderController :  Controller
    {

        private readonly URLConfig _urls;
        private readonly IOrderService _service;

        public OrderController(IOptions<URLConfig> config, IOrderService service)
        {
            _urls = config.Value;
            _service = service;
        }

        [HttpGet]
        [Route("OrderDetails/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetOrders(int id)
        {
            try
            {
                var booksCategory = await _service.GetOrders(id);

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
