using CITApplication.Data;
using CITDomain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITInfrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ICITDBContext _citcontext;
        private readonly ICITDbConnection _dbconnection;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;
        public UserRepository(ICITDBContext citcontext, ICITDbConnection dbconnection, IHttpContextAccessor contextAccessor, IConfiguration configuration)
        {
            _citcontext = citcontext;
            _dbconnection = dbconnection;
            _contextAccessor = contextAccessor;
            _configuration = configuration;
        }
    }
}
