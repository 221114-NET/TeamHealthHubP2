using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class NewUserDTO
    {
        public NewUserDTO(string email, string firstname, string lastname, string password)
        {
            Email = email;
            FirstName = firstname;
            LastName = lastname;
            Password = password;
        }
        
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}