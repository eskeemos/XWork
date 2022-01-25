using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<PersonalData> PersonalData { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Client> Client { get; set; }
    }
}
