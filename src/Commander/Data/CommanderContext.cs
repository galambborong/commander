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
                },
                new Platform
                {
                    Id = 4,
                    Name = "Shell"
                },
                new Platform
                {
                    Id = 5,
                    Name = "Arduino"
                },
                new Platform
                {
                    Id = 6,
                    Name = "Docker"
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
                },
                new Command
                {
                    Id = 3,
                    Line = "docker run -d --rm -p <ext>:<int> -e Logging__Console__FormatterName=\"\" <namespace>/<image>:<tag>",
                    HowTo = "Run Docker Image in background; removing container once finished; with nice logging format",
                    PlatformId = 6
                },
                new Command
                {
                    Id = 4,
                    Line = "docker ps",
                    HowTo = "List current Docker processes (containers)",
                    PlatformId = 6
                },
                new Command
                {
                    Id = 5,
                    Line = "docker build <pwd> -t <namespace>/<image>:<tag>",
                    HowTo = "Build Docker image from Dockerfile",
                    PlatformId = 6
                }
            );
            
            base.OnModelCreating(modelBuilder);
        }
    }
}