using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;

namespace Repo
{
    public class RepoClassNewUser : IRepoClassNewUser
    {
        public string NewUser(NewUserDTO newUserDTO)
        {
            string AzureConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("ConnectionStrings")["RevDatabase"]!;

            //TODO MAKE a new user
            String sql = $"INSERT INTO [dbo].[UserHealthClass]([UserEmail],[UserFirstName],[UserLastName], [UserPassword], [UserRole]) VALUES(@email, @userFname, @userLname, @password, 'user')";
            try
            {
                using (SqlConnection connection = new SqlConnection(AzureConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@email", newUserDTO.Email);
                        command.Parameters.AddWithValue("@userFname", newUserDTO.FirstName);
                        command.Parameters.AddWithValue("@userLname", newUserDTO.LastName);
                        command.Parameters.AddWithValue("@password", newUserDTO.Password);

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