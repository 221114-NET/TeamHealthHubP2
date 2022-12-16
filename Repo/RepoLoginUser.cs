using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Repo
{
    public class RepoLoginUser : IRepoLoginUser
    {
        public string LoginUser(string email, string password)
        {
            string AzureConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("ConnectionStrings")["RevDatabase"]!;

            //Login a user
            string sql = $"Select UserID, UserFirstName, UserLastName, UserRole From [dbo].[UserDataClass] Where UserEmail = @UserEmail AND UserPassword = @UserPassword";

            try
            {
                using (SqlConnection connection = new SqlConnection(AzureConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@UserEmail", email);
                        command.Parameters.AddWithValue("@UserPassword", password);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            return "Login Successful";
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return "Invalid Email/Password combination";
            }
        }
    }
}