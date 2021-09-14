using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Models;

namespace Commander.Repositories
{
    public class MockPlatformsRepo : IPlatformsRepo
    {
        public IEnumerable<Platform> GetAllPlatforms()
        {
            return new List<Platform>
            {
                new Platform {Id = 1, Name = "Linux"},
                new Platform {Id = 2, Name = "Dotnet"},
                new Platform {Id = 3, Name = "Pacman"},
                new Platform {Id = 4, Name = "Git"}
            };
        }

        public Task<Platform> GetPlatformByIdAsync(int id)
        {
            var platform = new Platform {Id = 4, Name = "Git"};
            return Task.FromResult(platform);
        }

        public Task CreatePlatformAsync(Platform platform)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePlatformAsync(Platform platform)
        {
            throw new NotImplementedException();
        }

        public void DeletePlatform(Platform platform)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}