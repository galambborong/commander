using System;
using System.Threading.Tasks;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Repositories
{
    public interface IAliasesRepo
    {
        Task<AliasMidWay> GetAliasByCommandIdAsync(Guid id);
        Task CreateAliasAsync(Alias newAlias);
        Task<bool> SaveChangesAsync();
    }
}