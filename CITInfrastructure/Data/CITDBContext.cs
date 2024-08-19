using CITApplication.Data;
using CITDomain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITInfrastructure.Data
{
    public class CITDBContext : DbContext, ICITDBContext
    {
        public CITDBContext(DbContextOptions<CITDBContext> options) : base(options)
        {

        }
        public DbSet<UserModel> UserModels { get; set; }
    }
}
