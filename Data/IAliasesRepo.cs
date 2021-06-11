using System.Collections;
using System.Linq;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Data
{
    public interface IAliasesRepo
    {
        IQueryable<Alias> GetAliasByCommandId(int id);
    }
}