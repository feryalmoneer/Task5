using Microsoft.EntityFrameworkCore;
using Task5.Models;

namespace Task5.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Accounts { get; set; }

    }
}
