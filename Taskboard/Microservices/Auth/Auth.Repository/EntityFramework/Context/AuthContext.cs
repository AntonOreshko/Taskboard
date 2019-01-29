using Auth.DomainModels.Models;
using Auth.Repository.EntityFramework.Context.Configurators;
using Microsoft.EntityFrameworkCore;

namespace Auth.Repository.EntityFramework.Context
{
    public class AuthContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfigurator());
        }
    }
}
