using System.Linq;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Data
{
    public class MockAliasesRepo : IAliasesRepo
    {
        public AliasMidWay GetAliasByCommandId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}