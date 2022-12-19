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
    public List<ModelClaimHealth> GetUserClaim(ModelClaimHealth modelClaimHealth)
    {
        return iRepoGetUserClaim.GetUserClaim(modelClaimHealth);
    }
}