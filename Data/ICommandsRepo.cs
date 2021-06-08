using System.Collections.Generic;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Data

{
    public interface ICommandRepo
    {
        bool SaveChanges();
        IEnumerable<CommandReadDto> GetAllCommands();
        CommandReadDto GetCommandById(int id);
        
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);


    }
}