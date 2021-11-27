using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Repositories
{
    public class MockCommandsRepo : ICommandsRepo
    {
        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<CommandReadDto> GetAllCommands()
        {
            //     var commands = new List<CommandReadDto>
            //     {
            //         new CommandReadDto {Id = 0, HowTo = "Add DB migrations", Line = "dotnet ef migrations add <NAME>", Platform = "Entity"},
            //         new CommandReadDto {Id = 1, HowTo = "Switch branch", Line = "git checkout <BRANCH>", Platform = "Git"},
            //         new CommandReadDto {Id = 2, HowTo = "Update AUR packages", Line = "paru -Sua", Platform ="AUR", AdminPrivilegesRequired = true},
            //     };


            throw new NotImplementedException();
        }

        public async Task<CommandReadDto> GetCommandByIdAsync(Guid id)
        {
            var command = new CommandReadDto
            {
                Id = Guid.NewGuid(), HowTo = "Update AUR packages", Line = "paru -Sua", Platform = "AUR",
                AdminPrivilegesRequired = true
            };

            return await Task.FromResult(command);
        }

        public async Task<Command> GetDbCommandByIdAsync(Guid id)
        {
            var commands = new Command
            {
                Id = Guid.NewGuid(), HowTo = "Update AUR packages", Line = "paru -Sua", PlatformId = Guid.NewGuid(),
                AdminPrivilegesRequired = true
            };
            return await Task.FromResult(commands);
        }

#pragma warning disable 1998
        public async Task CreateCommandAsync(Command cmd)
#pragma warning restore 1998
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Task<Command> cmd)
        {
            throw new NotImplementedException();
        }
    }
}