using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class DtoNewUser
    {
        public DtoNewUser(string email, string firstname, string lastname, string password)
        {
            this.email = email;
            this.firstname = firstname;
            this.lastname = lastname;
            this.password = password;
        }
        
        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("firstname")]
        public string firstname { get; set; }

        [JsonPropertyName("lastname")]
        public string lastname { get; set; }

        [JsonPropertyName("password")]
        public string password { get; set; }
    }
}