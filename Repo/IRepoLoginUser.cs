using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repo
{
    public interface IRepoLoginUser
    {
        string LoginUser(string email, string password);
    }
}