using CITDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITDomain.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserModel> GetUserDetails(string username);
    }
}
