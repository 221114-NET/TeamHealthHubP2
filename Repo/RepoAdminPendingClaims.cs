using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;

namespace Repo
{
    public class RepoAdminPendingClaims : IRepoAdminPendingClaims
    {
        public List<ModelClaimHealth> AdminPendingClaims()
        {
            List<ModelClaimHealth> modelClaimHealthList = new List<ModelClaimHealth>();

            string AzureConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("ConnectionStrings")["RevDatabase"]!;

            string sql = $"Select * From [dbo].[ClaimHealthClass] Where ClaimPendingStatus= 0";

            try
            {
                using (SqlConnection connection = new SqlConnection(AzureConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader resultSet = command.ExecuteReader())
                        {
                            while (resultSet.Read())
                            {
                                modelClaimHealthList.Add(new ModelClaimHealth(resultSet.GetInt32(0),resultSet.GetInt32(1),resultSet.GetString(2),resultSet.GetString(3),resultSet.GetDouble(4),resultSet.GetBoolean(5),resultSet.GetBoolean(6)));
                                
                            }
                            return modelClaimHealthList;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return modelClaimHealthList;
            }
        }
    }
}