using Microsoft.AspNetCore.Mvc;
using Order.DataModel;
using Order.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Order.Controllers
{
    [Route("api/[controller]")]
    public class OrderHistoryController : Controller
    {

        private readonly IOrderHistoryService _services;

        public OrderHistoryController(IOrderHistoryService services)
        {
            _services = services;
        }

        // GET api/values
        [HttpGet]
        [Route("OrdersHistory/{OrderId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetOrders(int OrderId)
        {
            try
            {
                var result = await _services.GetOrderHistory(OrderId);

                if (result?.Count > 0)
                    return Ok(result);
                return NotFound();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]OrderHistoryModel model)
        {
            if (model is null)
                return BadRequest();

            var result = await _services.Save(model);
            return result > 0 ? (IActionResult)Ok(result) : (IActionResult)BadRequest();

        }

    }
}
