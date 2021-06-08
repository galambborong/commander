using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Dtos;
using Commander.Models;


namespace Commander.Data
{
    public class PsqlCommandsRepo : ICommandsRepo
    {
        private readonly CommanderContext _context;

        public PsqlCommandsRepo(CommanderContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<CommandReadDto> GetAllCommands()
        {
            return (_context.Commands.Join(_context.Platforms,
                            command => command.PlatformId,
                            platform => platform.Id,
                            (command, platform) => new CommandReadDto 
                            {
                                            Id = command.Id,
                                            HowTo = command.HowTo,
                                            Line = command.Line,
                                            Platform = platform.Name,
                                            AdminPrivilegesRequired = command.AdminPrivilegesRequired
                            })).AsEnumerable();
            
        }

        public CommandReadDto GetCommandById(int id)
        {
            return _context.Commands.Join(_context.Platforms,
                            command => command.PlatformId,
                            platform => platform.Id,
                            (command, platform) => new CommandReadDto
                            {
                                            Id = command.Id,
                                            HowTo = command.HowTo,
                                            Line = command.Line,
                                            Platform = platform.Name,
                                            AdminPrivilegesRequired = command.AdminPrivilegesRequired
                            }).Where(p => p.Id == id).FirstOrDefault(p => p.Id == id);
        }

        public Command GetDbCommandById(int id)
        {
            return _context.Commands.FirstOrDefault((p => p.Id == id));
        }

        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

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
    }
}