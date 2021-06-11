using System.Linq;
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
        public IQueryable<Alias> GetAliasByCommandId(int id)
        {
            return _context.Aliases.Join(_context.Commands, alias => alias.CommandId, command => command.Id, (alias, command) =>
                            new Alias()
                            {
                                            Id = alias.Id,
                                            CommandId = command.Id,
                                            CommandAlias = alias.CommandAlias
                            }).Where(p => id == p.CommandId);
            
        }
    }
}