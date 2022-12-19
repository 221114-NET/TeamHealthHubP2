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
        public List<ModelClaimHealth> GetUserClaims(string userEmail)
        {
            List<ModelClaimHealth> userClaims = new List<ModelClaimHealth>();

            string AzureConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("ConnectionStrings")["RevDatabase"]!;

            string sql = $"Select ClaimID, ClaimHealthClass.UserID, ClaimType, ClaimDescription, ClaimAmount, ClaimApproved, ClaimPendingStatus From ClaimHealthClass Left Join UserHealthClass On UserHealthClass.UserID = ClaimHealthClass.UserID Where UserHealthClass.UserEmail = @UserEmail";

            try
            {
                using (SqlConnection connection = new SqlConnection(AzureConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@UserEmail", userEmail);

                        using (SqlDataReader resultSet = command.ExecuteReader())
                        {
                            while (resultSet.Read())
                            {
                                ModelClaimHealth claim = new ModelClaimHealth();
                                claim.ClaimId = resultSet.GetInt32(0);
                                claim.UserId = resultSet.GetInt32(1);
                                claim.ClaimType = resultSet.GetString(2);
                                claim.ClaimDescription = resultSet.GetString(3);
                                claim.ClaimAmount = resultSet.GetDouble(4);
                                claim.ClaimApproved = resultSet.GetBoolean(5);
                                claim.ClaimPendingStatus = resultSet.GetBoolean(6);
                                userClaims.Add(claim);
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