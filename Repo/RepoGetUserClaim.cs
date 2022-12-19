using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;

namespace Repo
{
    public class RepoGetUserClaim : IRepoGetUserClaim
    {
        public List<ModelClaimHealth> GetUserClaim(ModelClaimHealth modelClaimHealth)
        {
            List<ModelClaimHealth> userClaims = new List<ModelClaimHealth>();

            string AzureConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("ConnectionStrings")["RevDatabase"]!;

            string sql = $"Select * From [dbo].[ClaimHealthClass] Where UserID = @UserID";

            try
            {
                using (SqlConnection connection = new SqlConnection(AzureConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", modelClaimHealth.UserId);
                        using (SqlDataReader resultSet = command.ExecuteReader())
                        {
                            while (resultSet.Read())
                            {
                                modelClaimHealth.ClaimId = resultSet.GetInt32(0);
                                modelClaimHealth.ClaimType = resultSet.GetString(2);
                                modelClaimHealth.ClaimDescription = resultSet.GetString(3);
                                modelClaimHealth.ClaimAmount = resultSet.GetDouble(4);
                                modelClaimHealth.ClaimApproved = resultSet.GetBoolean(5);
                                modelClaimHealth.ClaimPendingStatus = resultSet.GetBoolean(6);
                                userClaims.Add(modelClaimHealth);
                            }
                            return userClaims;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return userClaims;
            }
        }
    }
}