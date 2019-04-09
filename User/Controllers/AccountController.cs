using User.DataModel;
using User.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace User.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly ICustomerService _ICustomerService;
        private IConfiguration _config;
        public AccountController(ICustomerService service, IConfiguration config)
        {
            _ICustomerService = service;
            _config = config;
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody]LoginModel loginModel)
        {

            IActionResult response = Unauthorized();


            if (loginModel is null)
                return BadRequest();
            var customer = _ICustomerService.Login(loginModel.UserId, loginModel.Password);
            if (customer != null)
            {
                var tokenString = BuildToken(new UserInfo { UserName = customer.CustomerName, UserType = customer.User.UserCategory });
                return Ok(new { UserName = customer.CustomerName, UserType = customer.User.UserCategory,  token = tokenString, userId= customer.CustomerId });

            }
            return NotFound();
        }


        private string BuildToken(UserInfo user)
        {
            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.GivenName, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
         };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
