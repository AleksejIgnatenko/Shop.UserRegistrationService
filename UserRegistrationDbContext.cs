using Microsoft.EntityFrameworkCore;
using Shop.UserRegistrationService.Entities;

namespace Shop.UserRegistrationService
{
    public class UserRegistrationDbContext : DbContext
    {
        public DbSet<UserRegistrationEntity> UserRegistrations { get; set; }

        public UserRegistrationDbContext(DbContextOptions<UserRegistrationDbContext> options) : base(options)
        {
            Database.EnsureCreated(); // Ensure the database is created
        }
    }
}