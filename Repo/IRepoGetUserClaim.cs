using Models;
namespace Repo
{
    public interface IRepoGetUserClaim
    {
        public List<ModelClaimHealth> GetUserClaim(ModelClaimHealth modelClaimHealth);
    }
}