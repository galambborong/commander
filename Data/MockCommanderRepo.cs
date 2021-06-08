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
            var commands = new List<CommandReadDto>
            {
                new CommandReadDto {Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "AUR"},
                new CommandReadDto {Id = 1, HowTo = "Cut bread", Line = "Get a knife", Platform = "Jack"},
                new CommandReadDto {Id = 2, HowTo = "Make a cup of tea", Line = "Pour boiling water over bag", Platform ="Hello"},
            };

            return commands;
        }

        public CommandReadDto GetCommandById(int id)
        {
            throw new NotImplementedException();
            // return new PublicCommand {Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Woo"};
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
        
        public IEnumerable<Platform> GetAllPlatforms()
        {
            var platforms = new List<Platform>
            {
                            new Platform {Id = 1, Name = "Linux"},
                            new Platform {Id = 2, Name = "Dotnet"},
                            new Platform {Id = 3, Name = "Pacman"}
            };

            return platforms;
        }

        public Platform GetPlatformById(int id)
        {
            throw new NotImplementedException();
        }

        public void CreatePlatform(Platform platform)
        {
            throw new NotImplementedException();
        }
    }
}