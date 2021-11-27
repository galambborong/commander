using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Repositories
{
    public class PsqlCommandsRepo : ICommandsRepo
    {
        private readonly CommanderContext _context;

        public PsqlCommandsRepo(CommanderContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public IAsyncEnumerable<CommandReadDto> GetAllCommands()
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
                })).AsAsyncEnumerable();
        }

        public async Task<CommandReadDto> GetCommandByIdAsync(Guid id)
        {
            return await _context.Commands.Join(_context.Platforms,
                command => command.PlatformId,
                platform => platform.Id,
                (command, platform) => new CommandReadDto
                {
                    Id = command.Id,
                    HowTo = command.HowTo,
                    Line = command.Line,
                    Platform = platform.Name,
                    AdminPrivilegesRequired = command.AdminPrivilegesRequired
                }).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Command> GetDbCommandByIdAsync(Guid id)
        {
            return await _context.Commands.FirstOrDefaultAsync((p => p.Id == id));
        }

        public async Task CreateCommandAsync(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            await _context.Commands.AddAsync(cmd);
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