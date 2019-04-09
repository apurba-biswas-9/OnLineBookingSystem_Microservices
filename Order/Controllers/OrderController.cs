
using Microsoft.AspNetCore.Mvc;
using Order.DataModel;
using Order.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Cart.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderServices _services;
        
        public OrderController(IOrderServices services)
        {
            _services = services;
        }


        // GET api/values
        [HttpGet]
        [Route("Orders/{customerId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetOrders(int customerId)
        {
            try
            {
                var result = await _services.GetOrders(customerId);

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
        public async Task<IActionResult> Post([FromBody]List<OrderModel> model)
        {
            if (model is null)
                return BadRequest();

            var result = await _services.Save(model);
            return result > 0 ? (IActionResult)Ok(result) : (IActionResult)BadRequest();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]OrderModel model)
        {
            if (model is null )
                return BadRequest();

            var result = await _services.Update(model);
            return result > 0 ? (IActionResult)Ok(result) : (IActionResult)BadRequest();

        }

        [HttpPost("UpdateOrderStatus")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody]OrderUpdateStatusModel model)
        {
            if (model is null)
                return BadRequest();

            var result = await _services.UpdateOrderStatus(model);
            return result > 0 ? (IActionResult)Ok(result) : (IActionResult)BadRequest();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _services.Delete(id);
            return result ? (IActionResult)Ok(result) : (IActionResult)BadRequest();
        }
    }
}
