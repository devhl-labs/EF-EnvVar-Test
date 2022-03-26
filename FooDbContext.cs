using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_EnvVar_Test
{
    public class FooDbContext : DbContext
    {
        public FooDbContext(DbContextOptions<FooDbContext> options) : base(options)
        {

        }
    }
}
