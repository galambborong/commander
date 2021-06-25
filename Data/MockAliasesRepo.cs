using Commander.Dtos;
using Commander.Models;

namespace Commander.Data
{
    public class MockAliasesRepo : IAliasesRepo
    {
        public AliasMidWay GetAliasByCommandId(int id)
        {
            return new AliasMidWay
            {
                            Id = 1,
                            CommandAlias = "gs",
                            Command = "git status",
                            CommandId = 45
            };
        }

        public void CreateAlias(Alias newAlias)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}