using System;
using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockPlatformsRepo : IPlatformsRepo
    {
        public IEnumerable<Platform> GetAllPlatforms()
        {
            var platforms = new List<Platform>
            {
                            new Platform {Id = 1, Name = "Linux"},
                            new Platform {Id = 2, Name = "Dotnet"},
                            new Platform {Id = 3, Name = "Pacman"}
            };

            return platforms;
        }

        public Platform GetPlatformById(int id)
        {
            throw new NotImplementedException();
        }

        public void CreatePlatform(Platform platform)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}