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
                                userClaims.Add(new ModelClaimHealth(resultSet.GetInt32(0),resultSet.GetInt32(1),resultSet.GetString(2),resultSet.GetString(3),resultSet.GetDouble(4),resultSet.GetBoolean(5),resultSet.GetBoolean(6)));
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