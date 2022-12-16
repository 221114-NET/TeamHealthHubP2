using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repo;

namespace Business
{
    public class BusinessClassNewUser : IBusinessClassNewUser
    {
        private IRepoClassNewUser _IRepoClassNewUser;

        public BusinessClassNewUser(IRepoClassNewUser irepoClassNewUser)
        {
            _IRepoClassNewUser = irepoClassNewUser;
        }
        public string NewUser(string email, string firstname, string lastname, string password)
        {
            return _IRepoClassNewUser.NewUser(email, firstname, lastname, password);
        }

        public string LoginUser(string email, string password)
        {
            return _IRepoClassNewUser.LoginUser(email,password);
        }
    }
}