using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class DtoGetUserClaims
    {
        public string UserEmail {get; set; }
        public DtoGetUserClaims(string userEmail)
        {
            UserEmail = userEmail;
        }
    }
}