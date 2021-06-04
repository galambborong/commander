using System.Collections.Generic;
using System.Linq;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Data

{
    public interface ICommanderRepo
    {
        bool SaveChanges();
        IEnumerable<PublicCommand> GetAllCommands();
        IQueryable<PublicCommand> GetCommandById(int id);
        
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);

        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);

        IEnumerable<Platform> GetAllPlatforms();
        
    }
}