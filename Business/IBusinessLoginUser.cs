using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public interface IBusinessLoginUser
    {
        string LoginUser(string email, string password);
    }
}