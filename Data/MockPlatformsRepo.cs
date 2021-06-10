using System;
using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
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

        public Platform GetPlatformById(int id)
        {
            return new Platform {Id = 4, Name = "Git"};
        }

        public void CreatePlatform(Platform platform)
        {
            throw new NotImplementedException();
        }

        public void UpdatePlatform(Platform platform)
        {
            throw new NotImplementedException();
        }

        public void DeletePlatform(Platform platform)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}