using Microsoft.EntityFrameworkCore;
using ProgramData.Models;

namespace BondCalculatorData
{
    public class BondCalculatorDbContext : DbContext
    {
        public BondCalculatorDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Calculation> Calculations { get; set; }
    }
}