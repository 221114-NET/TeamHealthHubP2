using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repo
{
    public interface IRepoClassNewUser
    {
        string NewUser(string email, string firstname,string lastname, string password);
        string LoginUser(string email, string password);
    }
}