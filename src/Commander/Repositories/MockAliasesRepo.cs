using System;
using System.Threading.Tasks;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Repositories
{
    public class MockAliasesRepo : IAliasesRepo
    {
        public async Task<AliasMidWay> GetAliasByCommandIdAsync(Guid id)
        {
            var alias = new AliasMidWay
            {
                Id = Guid.NewGuid(),
                CommandAlias = "gs",
                Command = "git status",
                CommandId = Guid.NewGuid()
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