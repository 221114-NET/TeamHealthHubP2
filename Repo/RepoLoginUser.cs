using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;

namespace Repo
{
    public class RepoLoginUser : IRepoLoginUser
    {
        public string LoginUser(DtoLogin dtoLogin)
        {
            string AzureConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("ConnectionStrings")["RevDatabase"]!;

            //Login a user
            string sql = $"Select UserRole From [dbo].[UserHealthClass] Where UserEmail = @UserEmail AND UserPassword = @UserPassword";

            try
            {
                using (SqlConnection connection = new SqlConnection(AzureConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@UserEmail", dtoLogin.email);
                        command.Parameters.AddWithValue("@UserPassword", dtoLogin.password);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return reader.GetString(0);
                            }
                            return "false";
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return "false";
            }
        }
    }
}