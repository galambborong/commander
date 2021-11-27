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
                new Platform {Id = Guid.NewGuid(), Name = "Linux"},
                new Platform {Id = Guid.NewGuid(), Name = "Dotnet"},
                new Platform {Id = Guid.NewGuid(), Name = "Pacman"},
                new Platform {Id = Guid.NewGuid(), Name = "Git"}
            };
        }

        public Task<Platform> GetPlatformByIdAsync(Guid id)
        {
            var platform = new Platform {Id = Guid.NewGuid(), Name = "Git"};
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