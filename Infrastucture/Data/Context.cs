using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<ZusStatement> ZusStatement { get; set; }
        public DbSet<PersonalData> PersonalData { get; set; } 
        public DbSet<Location> Location { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}
