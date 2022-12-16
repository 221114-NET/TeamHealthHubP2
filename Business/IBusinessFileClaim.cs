using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Business
{
    public interface IBusinessFileClaim
    {
        string FileClaim(string userEmail, ModelClaimHealth modelClaimHealth);
    }
}