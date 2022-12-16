using Microsoft.AspNetCore.Mvc;
using Models;
using Business;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly IBusinessNewUser _iBusinessNewUser;
        private readonly IBusinessFileClaim _iBusinessFileClaim;
        private readonly IBusinessLoginUser _iBusinessLoginUser;

        public ApiController(IBusinessNewUser iBusinessNewUser, IBusinessFileClaim iBusinessFileClaim, IBusinessLoginUser iBusinessLoginUser)
        {
            _iBusinessNewUser = iBusinessNewUser;
            _iBusinessFileClaim = iBusinessFileClaim;
            _iBusinessLoginUser = iBusinessLoginUser;
        }

        [HttpPost("NewUser/Signup")]
        public string NewUser(DtoNewUser dtoNewUser)
        {
            return _iBusinessNewUser.NewUser(dtoNewUser);
        }
        
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user, admin")]
        [HttpPost("User/FileClaim")]
        public string FileClaim(DtoNewFileClaim dtoNewFileClaim)
        {
            ModelClaimHealth modelClaimHealth = new ModelClaimHealth();
            string userEmail = ($"{this.User.FindFirst(ClaimTypes.NameIdentifier).Value}");
            modelClaimHealth.ClaimType = dtoNewFileClaim.ClaimType;
            modelClaimHealth.ClaimAmount = dtoNewFileClaim.ClaimAmount;
            return _iBusinessFileClaim.FileClaim(userEmail, modelClaimHealth);
        }

        [HttpPost("User/Login")]
        public string LoginUser(DtoLogin dtoLogin)
        {
            return _iBusinessLoginUser.LoginUser(dtoLogin);
        }
    }
}