using Knowtes.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Platinum.WebAPI.Models;

namespace Platinum.WebAPI
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Achivement> Achivements => Set<Achivement>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Game> Games => Set<Game>();
        public DbSet<User> Users => Set<User>();

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SQL6030.site4now.net;Initial Catalog=db_a9882b_database;User Id=db_a9882b_database_admin;Password=qweasd123");
        }

    }
}
