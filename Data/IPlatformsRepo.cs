using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface IPlatformsRepo
    {
                IEnumerable<Platform> GetAllPlatforms();
                Platform GetPlatformById(int id);
                void CreatePlatform(Platform platform);
    }
}