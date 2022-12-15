using Microsoft.AspNetCore.Mvc;
using Models;
using Business;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
//using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly IBusinessClassNewUser _iBusinessClassNewUser;

        public ApiController(IBusinessClassNewUser iBusinessClassNewUser)
        {
            _iBusinessClassNewUser = iBusinessClassNewUser;
        }
        
        [HttpPost("NewUser/Signup")]
        public string NewUser(string email, string firstname, string lastname, string password)
        {
            return _iBusinessClassNewUser.NewUser(email, firstname, lastname, password);
        }
    }
}