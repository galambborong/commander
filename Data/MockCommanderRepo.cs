using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PublicCommand> GetAllCommands()
        {
            var commands = new List<PublicCommand>
            {
                new PublicCommand {Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "AUR"},
                new PublicCommand {Id = 1, HowTo = "Cut bread", Line = "Get a knife", Platform = "Jack"},
                new PublicCommand {Id = 2, HowTo = "Make a cup of tea", Line = "Pour boiling water over bag", Platform ="Hello"},
            };

            return commands;
        }

        public PublicCommand GetCommandById(int id)
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

        public IEnumerable<User> GetAllUsers()
        {
            DateTime now = DateTime.Now;
            DateTime dt = new DateTime(2019, 2, 22, 14, 0, 0);
            var users = new List<User>
            {
                            new User {Id = 1, FirstName = "James", LastName = "Bond", Username = "007"},
                            new User {Id = 2, FirstName = "Jack", LastName = "Reacher", Username = "Reach123"},
                            new User {Id = 3, Username = "galambborong"},
            };

            return users;
        }

        public User GetUserById(int id)
        {
            return new User {Id = 3, Username = "galambborong"};
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
    }
}