using System;
using System.Threading.Tasks;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Repositories
{
    public class MockAliasesRepo : IAliasesRepo
    {
        public async Task<AliasMidWay> GetAliasByCommandIdAsync(int id)
        {
            var alias = new AliasMidWay
            {
                Id = id,
                CommandAlias = "gs",
                Command = "git status",
                CommandId = 11
            };

            return await Task.FromResult(alias);
        }

        public Task CreateAliasAsync(Alias newAlias)
        {
            throw new System.NotImplementedException();
        }


        public Task<bool> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}