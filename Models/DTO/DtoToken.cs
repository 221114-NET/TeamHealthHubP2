using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class DtoToken
    {
        public DtoToken(string token)
        {
            mytoken = token;
        }
        public string mytoken { get; set; }
    }
}