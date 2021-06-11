using System.Collections;
using Commander.Dtos;

namespace Commander.Data
{
    public interface IAliasesRepo
    {
        AliasReadDto GetAliasByCommandId(int id);
    }
}