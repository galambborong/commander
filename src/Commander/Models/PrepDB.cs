using System;
using System.Linq;
using Commander.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Commander.Models;

public static class PrepDB
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<CommanderContext>());
        }
    }

    public static void SeedData(CommanderContext context)
    {
        Console.WriteLine("Applying Migrations...");

        context.Database.Migrate();

        if (!context.Platforms.Any())
        {
            Console.WriteLine("Seeding platforms to Platforms table...");
            context.Platforms.AddRange(
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

            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Platforms already has data - not seeding");
        }
    }
}