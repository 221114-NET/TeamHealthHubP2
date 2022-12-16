using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class DtoNewFileClaim
    {
         public DtoNewFileClaim(string claimType, double claimAmount)
        {
            ClaimType = claimType;
            ClaimAmount = claimAmount;
        }

        public string ClaimType { get; set; }
        public double ClaimAmount { get; set; }
    }
}