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
        private readonly IBusinessNewUser _iBusinessNewUser;
        private readonly IBusinessFileClaim _iBusinessFileClaim;

        public ApiController(IBusinessNewUser iBusinessNewUser, IBusinessFileClaim iBusinessFileClaim)
        {
            _iBusinessNewUser = iBusinessNewUser;
            _iBusinessFileClaim = iBusinessFileClaim;
        }

        [HttpPost("NewUser/Signup")]
        public string NewUser(DtoNewUser dtoNewUser)
        {
            return _iBusinessNewUser.NewUser(dtoNewUser);
        }

        [HttpPost("User/FileClaim")]
        public string FileClaim(ModelClaimHealth modelClaimHealth)
        {
            return _iBusinessFileClaim.FileClaim(modelClaimHealth);
        }
    }
}