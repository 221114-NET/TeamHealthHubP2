using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Business
{
    public interface IBusinessGetUserClaim
    {
        public List<ModelClaimHealth> GetUserClaims(int userId);
    }
}