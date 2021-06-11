using Commander.Dtos;

namespace Commander.Data
{
    public class MockAliasesRepo : IAliasesRepo
    {
        public AliasReadDto GetAliasByCommandId(int id)
        {
            return new AliasReadDto {Id = 1, Command = "git status", CommandAlias = "gs"};
        }
    }
}