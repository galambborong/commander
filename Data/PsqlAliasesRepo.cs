using System;
using System.Linq;
using System.Threading.Tasks;
using Commander.Dtos;
using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class PsqlAliasesRepo : IAliasesRepo
    {
        private readonly CommanderContext _context;

        public PsqlAliasesRepo(CommanderContext context)
        {
            _context = context;
        }

        public async Task<AliasMidWay> GetAliasByCommandIdAsync(int id)
        {
            return await _context.Aliases.Join(_context.Commands, 
                            alias => alias.CommandId, 
                            command => command.Id, 
                            (alias, command) =>
                                            new AliasMidWay
                                            {
                                                            Id = alias.Id,
                                                            Command = command.Line,
                                                            CommandAlias = alias.CommandAlias,
                                                            CommandId = alias.CommandId
                                            
                                            }).FirstOrDefaultAsync(p => p.CommandId == id);
        }

        public async Task CreateAliasAsync(Alias newAlias)
        {
            if (newAlias == null)
            {
                throw new ArgumentNullException(nameof(newAlias));
            }

            await _context.Aliases.AddAsync(newAlias);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}