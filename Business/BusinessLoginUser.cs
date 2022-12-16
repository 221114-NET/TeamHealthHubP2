using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Repo;

namespace Business
{
    public class BusinessLoginUser : IBusinessLoginUser
    {
        private readonly IRepoLoginUser _IRepoLoginUser;

        public BusinessLoginUser(IRepoLoginUser irepoLoginUser)
        {
            _IRepoLoginUser = irepoLoginUser;
        }

        public string LoginUser(DtoLogin dtoLogin)
        {
            return _IRepoLoginUser.LoginUser(dtoLogin);
        }
    }
}