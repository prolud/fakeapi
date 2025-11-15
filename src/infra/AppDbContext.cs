using System.Security.Authentication;
using domain.Entities;
using domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace infra
{
    public class AppDbContext(DbContextOptions options, IConfiguration configuration) : DbContext(options)
    {
        public DbSet<DbUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = configuration.GetConnectionString("MySql") ?? throw new InvalidCredentialException("MySql connection string not found.");
            optionsBuilder.UseMySQL(connectionString);
        }
    }
}