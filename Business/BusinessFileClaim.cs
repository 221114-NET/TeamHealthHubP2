using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Repo;

namespace Business
{
    public class BusinessFileClaim : IBusinessFileClaim
    {
        private IRepoFileClaim _IRepoFileClaim;

        public BusinessFileClaim(IRepoFileClaim irepoFileClaim)
        {
            _IRepoFileClaim = irepoFileClaim;
        }
        public string FileClaim(string userEmail, ModelClaimHealth modelClaimHealth)
        {
            return _IRepoFileClaim.FileClaim(userEmail, modelClaimHealth);
        }
    }
}