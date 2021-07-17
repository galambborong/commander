using System.Threading.Tasks;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Data
{
    public interface IAliasesRepo
    {
        Task<AliasMidWay> GetAliasByCommandIdAsync(int id);
        Task CreateAliasAsync(Alias newAlias);
        Task<bool> SaveChangesAsync();
    }
}