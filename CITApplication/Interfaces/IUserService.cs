using CITDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITApplication.Interfaces
{
    public interface IUserService
    {
        public Task<UserModel> GetUserDetails(string username, string UserEmail);
    }
}
