using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class DtoGetUserClaims
    {
        public int UserId {get; set;}
        public DtoGetUserClaims(int userId)
        {
            UserId = userId;
        }
    }
}