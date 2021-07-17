using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class PsqlPlatformsRepo : IPlatformsRepo
    {
        private readonly CommanderContext _context;

        public PsqlPlatformsRepo(CommanderContext context)
        {
            _context = context;
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public async Task<Platform> GetPlatformByIdAsync(int id)
        {
            return await _context.Platforms.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreatePlatformAsync(Platform newPlatform)
        {
            if (newPlatform == null) throw new ArgumentNullException(nameof(newPlatform));

            await _context.Platforms.AddAsync(newPlatform);
        }

        public async Task UpdatePlatformAsync(Platform platform)
        {
            // do nothing
        }

        public void DeletePlatform(Platform platform)
        {
            if (platform == null) throw new ArgumentNullException(nameof(platform));
            
            _context.Platforms.Remove(platform);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
