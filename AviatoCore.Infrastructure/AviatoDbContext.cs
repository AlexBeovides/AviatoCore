using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AviatoCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AviatoCore.Infrastructure
{
    public class AviatoDbContext : DbContext
    {
        public AviatoDbContext(DbContextOptions<AviatoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        // Add other DbSets for your other entities
    }
}
