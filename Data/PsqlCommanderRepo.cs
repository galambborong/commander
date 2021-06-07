using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Commander.Dtos;
using Commander.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Commander.Data
{
    public class PsqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public PsqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<PublicCommand> GetAllCommands()
        {
            return (_context.Commands.Join(_context.Platforms,
                            command => command.PlatformId,
                            platform => platform.Id,
                            (command, platform) => new PublicCommand 
                            {
                                            Id = command.Id,
                                            HowTo = command.HowTo,
                                            Line = command.Line,
                                            Platform = platform.Name,
                                            AdminPrivilegesRequired = command.AdminPrivilegesRequired
                            })).AsEnumerable();
            
        }

        public PublicCommand GetCommandById(int id)
        {
            return _context.Commands.Join(_context.Platforms,
                            command => command.PlatformId,
                            platform => platform.Id,
                            (command, platform) => new PublicCommand
                            {
                                            Id = command.Id,
                                            HowTo = command.HowTo,
                                            Line = command.Line,
                                            Platform = platform.Name,
                                            AdminPrivilegesRequired = command.AdminPrivilegesRequired
                            }).Where(p => p.Id == id).FirstOrDefault(p => p.Id == id);
        }

        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            
            // var platform = _context.Platforms.FirstOrDefault(p => p.Id == cmd.PlatformId);
            //
            // if (platform == null) throw new Exception("PlatformId not found");
            
            _context.Commands.Add(cmd);
        }

        public void UpdateCommand(Command cmd)
        {
            // Do nothing... this is counter intuitive...
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Remove(cmd);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(p => p.Id == id);
        }
    }
}