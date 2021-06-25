using System.Collections;
using System.Linq;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Data
{
    public interface IAliasesRepo
    {
        AliasMidWay GetAliasByCommandId(int id);
        void CreateAlias(Alias newAlias);
        bool SaveChanges();
    }
}