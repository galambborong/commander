using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommandsRepo : ICommandsRepo
    {
        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommandReadDto> GetAllCommands()
        {
            return new List<CommandReadDto>
            {
                new CommandReadDto {Id = 0, HowTo = "Add DB migrations", Line = "dotnet ef migrations add <NAME>", Platform = "Entity"},
                new CommandReadDto {Id = 1, HowTo = "Switch branch", Line = "git checkout <BRANCH>", Platform = "Git"},
                new CommandReadDto {Id = 2, HowTo = "Update AUR packages", Line = "paru -Sua", Platform ="AUR", AdminPrivilegesRequired = true},
            };
        }

        public CommandReadDto GetCommandById(int id)
        {
            return new CommandReadDto
            {
                            Id = 2, HowTo = "Update AUR packages", Line = "paru -Sua", Platform = "AUR", AdminPrivilegesRequired = true
            };
        }

        public Command GetDbCommandById(int id)
        {
            return new Command
                            {Id = 2, HowTo = "Update AUR packages", Line = "paru -Sua", PlatformId = 5, AdminPrivilegesRequired = true};
        }

        public void CreateCommand(Command cmd)
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
        
       
    }
}