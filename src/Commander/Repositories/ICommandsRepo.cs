using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Repositories

{
    public interface ICommandsRepo
    {
        Task<bool> SaveChangesAsync();
        IAsyncEnumerable<CommandReadDto> GetAllCommands();
        Task<CommandReadDto> GetCommandByIdAsync(Guid id);
        Task<Command> GetDbCommandByIdAsync(Guid id);

        Task CreateCommandAsync(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }
}