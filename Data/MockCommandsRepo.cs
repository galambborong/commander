using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommandsRepo : ICommandsRepo
    {
        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IAsyncEnumerable<CommandReadDto>> GetAllCommandsAsync()
        {
            return new List<CommandReadDto>
            {
                new CommandReadDto {Id = 0, HowTo = "Add DB migrations", Line = "dotnet ef migrations add <NAME>", Platform = "Entity"},
                new CommandReadDto {Id = 1, HowTo = "Switch branch", Line = "git checkout <BRANCH>", Platform = "Git"},
                new CommandReadDto {Id = 2, HowTo = "Update AUR packages", Line = "paru -Sua", Platform ="AUR", AdminPrivilegesRequired = true},
            };
        }

        public async Task<CommandReadDto> GetCommandByIdAsync(int id)
        {
            return new CommandReadDto
            {
                            Id = 2, HowTo = "Update AUR packages", Line = "paru -Sua", Platform = "AUR", AdminPrivilegesRequired = true
            };
        }

        public async Task<Command> GetDbCommandByIdAsync(int id)
        {
            return new Command
                            {Id = 2, HowTo = "Update AUR packages", Line = "paru -Sua", PlatformId = 5, AdminPrivilegesRequired = true};
        }

        public async Task CreateCommandAsync(Command cmd)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCommandAsync(Command cmd)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCommandAsync(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}