using System.Linq;
using System.Runtime.InteropServices;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Data
{
    public class PsqlAliasesRepo : IAliasesRepo
    {
        private readonly CommanderContext _context;

        public PsqlAliasesRepo(CommanderContext context)
        {
            _context = context;
        }

        public AliasMidWayDto GetAliasByCommandId(int id)
        {
            return _context.Aliases.Join(_context.Commands, 
                            alias => alias.CommandId, 
                            command => command.Id, 
                            (alias, command) =>
                            new AliasMidWayDto
                            {
                                            Id = alias.Id,
                                            Command = command.Line,
                                            CommandAlias = alias.CommandAlias,
                                            CommandId = alias.CommandId
                                            
                            }).Where(p => id == p.CommandId).FirstOrDefault(p => p.CommandId == id);
        }
    }
}