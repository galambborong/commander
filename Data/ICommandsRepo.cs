using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Data

{
    public interface ICommandsRepo
    {
        Task<bool> SaveChangesAsync();
        Task<IAsyncEnumerable<CommandReadDto>> GetAllCommandsAsync();
        Task<CommandReadDto> GetCommandByIdAsync(int id);
        Task<Command> GetDbCommandByIdAsync(int id);
        
        Task CreateCommandAsync(Command cmd);
        void UpdateCommandAsync(Command cmd);
        void DeleteCommandAsync(Command cmd);
    }
}