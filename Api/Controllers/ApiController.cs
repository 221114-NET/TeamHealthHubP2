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
        private readonly IBusinessGetUserClaim _iBusinessGetUserClaim;

        public ApiController(IBusinessNewUser iBusinessNewUser, IBusinessFileClaim iBusinessFileClaim, IBusinessLoginUser iBusinessLoginUser,
            IBusinessGetUserClaim iBusinessGetUserClaim)
        {
            _iBusinessNewUser = iBusinessNewUser;
            _iBusinessFileClaim = iBusinessFileClaim;
            _iBusinessLoginUser = iBusinessLoginUser;
            _iBusinessGetUserClaim = iBusinessGetUserClaim;
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
            string userEmail = ($"{this.User.FindFirst(ClaimTypes.Email).Value}");
            modelClaimHealth.ClaimType = dtoNewFileClaim.claimtype;
            modelClaimHealth.ClaimAmount = dtoNewFileClaim.claimamount;
            modelClaimHealth.ClaimDescription = dtoNewFileClaim.claimdescription;
            return _iBusinessFileClaim.FileClaim(userEmail, modelClaimHealth);
        }

        [HttpPost("User/Login")]
        public string LoginUser(DtoLogin dtoLogin)
        {
            return _iBusinessLoginUser.LoginUser(dtoLogin);
        }

        // client must have a role to use this http request
        // if you are not authenticated then the response will be a 401 because you don't have access to it
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("User/GetClaim")]
        public List<ModelClaimHealth> GetUserClaims(DtoGetUserClaims dtoGetUserClaims)
        {
            ModelClaimHealth modelClaimHealth = new ModelClaimHealth();
            modelClaimHealth.UserId = dtoGetUserClaims.UserId;
            return _iBusinessGetUserClaim.GetUserClaims(modelClaimHealth);
        }
    }
}