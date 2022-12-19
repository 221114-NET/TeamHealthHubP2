using Models;
using Repo;

namespace Business;

public class BusinessGetUserClaim : IBusinessGetUserClaim 
{
    private readonly IRepoGetUserClaim iRepoGetUserClaim;

    public BusinessGetUserClaim(IRepoGetUserClaim iRepoGetUserClaim)
    {
        this.iRepoGetUserClaim = iRepoGetUserClaim;
    }
    public List<ModelClaimHealth> GetUserClaims(int userId)
    {
        return iRepoGetUserClaim.GetUserClaims(userId);
    }
}