using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MydbServices.Data
{
    public class AreaDbContext : DbContext
    {
        public AreaDbContext(DbContextOptions<AreaDbContext> options): base(options)
        {
        }

        public DbSet<MydbServices.Models.Circle> Circle { get; set; } = default!;
    }
}
