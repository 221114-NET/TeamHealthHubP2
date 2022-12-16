using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;

namespace Repo
{
    public class RepoNewUser : IRepoNewUser
    {
        public string NewUser(DtoNewUser dtoNewUser)
        {
            string AzureConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("ConnectionStrings")["RevDatabase"]!;

            String sql = $"INSERT INTO [dbo].[UserHealthClass]([UserEmail],[UserFirstName],[UserLastName], [UserPassword], [UserRole]) VALUES(@email, @userFname, @userLname, @password, 'user')";
            try
            {
                using (SqlConnection connection = new SqlConnection(AzureConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@email", dtoNewUser.email);
                        command.Parameters.AddWithValue("@userFname", dtoNewUser.firstname);
                        command.Parameters.AddWithValue("@userLname", dtoNewUser.lastname);
                        command.Parameters.AddWithValue("@password", dtoNewUser.password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            return "User Created";
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return "User Name Taken";
            }
        }
    }
}