using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
        public DbSet<Command> Commands { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Alias> Aliases { get; set; }
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>().HasData(
                new Platform
                {
                    Id = 1,
                    Name = "Linux"
                },
                new Platform
                {
                    Id = 2,
                    Name = "Git"
                },
                new Platform
                {
                    Id = 3,
                    Name = "DotNet"
                }
            );

            modelBuilder.Entity<Command>().HasData(
                new Command
                {
                    Id = 1,
                    Line = "git status",
                    HowTo = "Check git repository status",
                    PlatformId = 2,
                },
                new Command
                {
                    Id = 2,
                    Line = "df -h",
                    HowTo = "Check disk usage",
                    PlatformId = 1,
                }
            );
            
            base.OnModelCreating(modelBuilder);
        }
    }
}