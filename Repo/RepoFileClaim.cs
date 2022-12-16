using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;

namespace Repo
{
    public class RepoFileClaim : IRepoFileClaim
    {
        public string FileClaim(string userEmail, ModelClaimHealth modelClaimHealth)
        {
            string AzureConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("ConnectionStrings")["RevDatabase"]!;

            string sql = $"INSERT INTO [dbo].[ClaimHealthClass]([UserID], [ClaimType], [ClaimDescription],[ClaimAmount],[ClaimApproved],[ClaimPendingStatus]) VALUES((SELECT UserID From [dbo].[UserHealthClass] WHERE UserEmail = @LogedInUserEmail), @ticketType, @reimbursementAmount, @ReimbursementDescription 0, 1)";
            try
            {
                using (SqlConnection connection = new SqlConnection(AzureConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ticketType", modelClaimHealth.ClaimType);
                        command.Parameters.AddWithValue("@reimbursementAmount", modelClaimHealth.ClaimAmount);
                        command.Parameters.AddWithValue("@LogedInUserName", userEmail);
                        command.Parameters.AddWithValue("@ReimbursementDescription", modelClaimHealth.ClaimDescription);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            return "Reimbursement Requested";
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return "Reimbursement Request Failed";
        }
    }
}