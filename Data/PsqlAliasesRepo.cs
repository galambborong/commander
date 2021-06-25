using System;
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

        public AliasMidWay GetAliasByCommandId(int id)
        {
            return _context.Aliases.Join(_context.Commands, 
                            alias => alias.CommandId, 
                            command => command.Id, 
                            (alias, command) =>
                            new AliasMidWay
                            {
                                            Id = alias.Id,
                                            Command = command.Line,
                                            CommandAlias = alias.CommandAlias,
                                            CommandId = alias.CommandId
                                            
                            }).FirstOrDefault(p => p.CommandId == id);
        }

        public void CreateAlias(Alias newAlias)
        {
            if (newAlias == null)
            {
                throw new ArgumentNullException(nameof(newAlias));
            }

            _context.Aliases.Add(newAlias);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}