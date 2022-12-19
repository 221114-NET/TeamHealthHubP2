using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class DtoPendingClaims
    {
        public DtoPendingClaims(string claimId, bool claimApproved)
        {
            this.claimId= claimId;
            this.claimApproved= claimApproved;

        }

        public string? claimId { get; set; }
        bool claimApproved { get; set; }
        
    }
}