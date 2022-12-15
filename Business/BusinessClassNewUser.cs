using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
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

        public string NewUser(NewUserDTO newUserDTO)
        {
            return _IRepoClassNewUser.NewUser(newUserDTO);
        }
    }
}