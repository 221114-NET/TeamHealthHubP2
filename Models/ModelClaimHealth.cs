using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class ModelClaimHealth
    {
        public ModelClaimHealth(int claimId, int userId, string claimType,string claimDescription, double claimAmount, bool claimApproved, bool claimPendingStatus)
        {
            ClaimId = claimId;
            UserId = userId;
            ClaimType = claimType;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            ClaimApproved = claimApproved;
            ClaimPendingStatus = claimPendingStatus;
        }
        public ModelClaimHealth()
        {

        }

        public int ClaimId { get; set; }
        public int UserId { get; set; }
        public string? ClaimType { get; set; }
        public string? ClaimDescription { get; set; }
        public double ClaimAmount { get; set; }
        public bool ClaimApproved { get; set; }
        public bool ClaimPendingStatus { get; set; }
    }
}