using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class ModelClaimHealth
    {
        public ModelClaimHealth(string claimId, string userId, string claimAmount,string claimType, string claimApproved, string claimPendingStatus)
        {
            ClaimId = claimId;
            UserId = userId;
            ClaimType = claimType;
            ClaimAmount = claimAmount;
            ClaimApproved = claimApproved;
            ClaimPendingStatus = claimPendingStatus;
        }

        public string ClaimId { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimAmount { get; set; }
        public string ClaimApproved { get; set; }
        public string ClaimPendingStatus { get; set; }
    }
}