using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class DtoNewFileClaim
    {
         public DtoNewFileClaim(string claimType,string claimDescription, double claimAmount)
        {
            this.claimtype = claimType;
            this.claimdescription = claimDescription;
            this.claimamount = claimAmount;
        }

        public string? claimtype { get; set; }
        public string? claimdescription { get; set; }
        public double claimamount { get; set; }
    }
}