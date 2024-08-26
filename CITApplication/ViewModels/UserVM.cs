using CITDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITApplication.ViewModels
{
    public class UserVM
    {
        public UserModel Usermodel { get; set; }
        public Task<UserModel> GetUserDetails { get; set; }
    }
}
