using Models;
namespace Repo
{
    public interface IRepoGetUserClaim
    {
        public List<ModelClaimHealth> GetUserClaims(int userId);
    }
}