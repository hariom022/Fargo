using CITApplication.Interfaces;
using CITApplication.ViewModels;
using CITDomain.Interfaces;
using CITDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITApplication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserModel> GetUserDetails(string username)
        {
            return new UserVM()
            {
                GetUserDetails = _userRepository.GetUserDetails(username)
            }.GetUserDetails;

        }
    }
}
