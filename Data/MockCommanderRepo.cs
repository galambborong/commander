using System;
using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command {Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle and Pan"},
                new Command {Id = 1, HowTo = "Cut bread", Line = "Get a knife", Platform = "knife and chopping board"},
                new Command {Id = 2, HowTo = "Make a cup of tea", Line = "Pour boiling water over bag", Platform = "Tea bag and kettle"},
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle and Pan"};
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

        public User GetAllUsers(int id)
        {
            return new User {Id = 3, Username = "galambborong"};
        }
    }
}