using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Models;

namespace Commander.Repositories
{
    public interface IPlatformsRepo
    {
        IEnumerable<Platform> GetAllPlatforms();
        Task<Platform> GetPlatformByIdAsync(int id);
        Task CreatePlatformAsync(Platform platform);
        Task UpdatePlatformAsync(Platform platform);
        void DeletePlatform(Platform platform);
        Task<bool> SaveChangesAsync();
    }
}