using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Repo;

namespace Business
{
    public class BusinessNewUser : IBusinessNewUser
    {
        private IRepoNewUser _IRepoNewUser;

        public BusinessNewUser(IRepoNewUser irepoNewUser)
        {
            _IRepoNewUser = irepoNewUser;
        }

        public string NewUser(DtoNewUser dtoNewUser)
        {
            return _IRepoNewUser.NewUser(dtoNewUser);
        }
    }
}