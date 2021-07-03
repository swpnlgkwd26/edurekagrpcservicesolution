using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edureka.GrpcServer.Data
{
    public class EdurekaDBContext : DbContext
    {
        public EdurekaDBContext(DbContextOptions<EdurekaDBContext> options)
            : base(options)
        {
        }
        public DbSet<AccountInformation> Accounts { get; set; }
    }
}
