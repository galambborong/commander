using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

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

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public void CreatePlatform(Platform newPlatform)
        {
            if (newPlatform == null) throw new ArgumentNullException(nameof(newPlatform));

            _context.Platforms.Add(newPlatform);
        }

        public void UpdatePlatform(Platform platform)
        {
            // do nothing
        }

        public void DeletePlatform(Platform platform)
        {
            if (platform == null) throw new ArgumentNullException(nameof(platform));
            
            _context.Platforms.Remove(platform);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
