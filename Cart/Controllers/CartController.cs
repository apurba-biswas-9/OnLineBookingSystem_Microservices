using Cart.DataModel;
using Cart.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Cart.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly ICartServices _services;
        public CartController(ICartServices services)
        {
            _services = services;
        }


        // GET api/values
        [HttpGet]
        [Route("Carts/{customerId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetTaskWithPaginate(int customerId)
        {
            try
            {
                var result = await _services.GetCarts(customerId);

                if (result?.Count > 0)
                    return Ok(result);
                return NotFound();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
        }

        // GET api/values
        [HttpGet]
        [Route("Count/{customerId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetCartsCount(int customerId)
        {
            try
            {
                var result = await _services.GetCarts(customerId);

                if (result?.Count > 0)
                    return Ok(result.Count);
                return Ok(0);
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
        }


        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CartModel model)
        {
            if (model is null)
                return BadRequest();

            var result = await _services.Save(model);
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
