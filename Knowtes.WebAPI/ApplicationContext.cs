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
            optionsBuilder.UseSqlite($@"Data source=..\Knowtes.WebAPI\AppData\DataBase.db");
        }

    }
}
