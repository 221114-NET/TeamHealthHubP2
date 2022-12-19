using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Repo;

namespace Business
{
    public class BusinessAdminPendingClaims : IBusinessAdminPendingClaims
    {
        private readonly IRepoAdminPendingClaims _iRepoAdminPendingClaims;

        public BusinessAdminPendingClaims(IRepoAdminPendingClaims irepoAdminPendingClaims)
        {
            _iRepoAdminPendingClaims = irepoAdminPendingClaims;

        }

        public List<ModelClaimHealth> AdminPendingClaims()
        {
            return _iRepoAdminPendingClaims.AdminPendingClaims();
        }
        
    }
}