using CITDomain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITApplication.Data
{
    public interface ICITDBContext
    {
        public DbSet<UserModel> UserModels {  get; }
    }
}
