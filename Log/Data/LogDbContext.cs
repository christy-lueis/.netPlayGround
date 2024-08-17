using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log.Models;
using Microsoft.EntityFrameworkCore;

namespace Log.Data
{

    public class LogDbContext : DbContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> options): base(options)
        {
        }

        public DbSet<LoggingDS> Logs { get; set; } = default!;
    }
}
