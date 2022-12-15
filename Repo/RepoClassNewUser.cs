using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Repo
{
    public class RepoClassNewUser : IRepoClassNewUser
    {
        public string NewUser(string email, string firstname, string lastname, string password)
        {
            throw new NotImplementedException();
            // string AzureConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("ConnectionStrings")["RevDatabase"]!;

            // //TODO MAKE a new user
            // //String sql = $"INSERT INTO [dbo].[UserDataClass]([UserName], [UserPassword], [UserRole]) VALUES(@username, @password, 'user')";
            // try
            // {
            //     using (SqlConnection connection = new SqlConnection(AzureConnectionString))
            //     {
            //         connection.Open();
            //         using (SqlCommand command = new SqlCommand(sql, connection))
            //         {
            //             command.Parameters.AddWithValue("@username", username);
            //             command.Parameters.AddWithValue("@password", password);
            //             using (SqlDataReader reader = command.ExecuteReader())
            //             {
            //                 return "User Created";
            //             }
            //         }
            //     }
            // }
            // catch (SqlException e)
            // {
            //     Console.WriteLine(e.ToString());
            //     return "User Name Taken";
            // }
        }
    }
}