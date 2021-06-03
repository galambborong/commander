using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data

{
    public interface ICommanderRepo
    {
        bool SaveChanges();
        IEnumerable<ReturnCommand> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);

        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);

        IEnumerable<Platform> GetAllPlatforms();
        
    }
}