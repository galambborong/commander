using System;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Commander.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("/api/commands/{id:int}/alias")]
    [ApiController]
    public class AliasesController : ControllerBase
    {
        private readonly IAliasesRepo _aliasesRepo;
        private readonly IMapper _mapper;
        private readonly ICommandsRepo _commandsRepo;

        public AliasesController(IAliasesRepo aliasesRepo, IMapper mapper, ICommandsRepo commandsRepo)
        {
            _mapper = mapper;
            _aliasesRepo = aliasesRepo;
            _commandsRepo = commandsRepo;
        }

        [HttpGet(Name = "GetAliasByCommandIdAsync")]
        public async Task<ActionResult<AliasReadDto>> GetAliasByCommandIdAsync(int id)
        {
            var aliasItem = await _aliasesRepo.GetAliasByCommandIdAsync(id);
            var mappedAliasItem = _mapper.Map<AliasReadDto>(aliasItem);

            return aliasItem != null ? Ok(mappedAliasItem) : NotFound();
        }

        [HttpPost]
        public async Task<ObjectResult> CreateAlias(Alias newAlias, int id)
        {
            await _aliasesRepo.CreateAliasAsync(newAlias);
            await _aliasesRepo.SaveChangesAsync();

            var midAlias = _mapper.Map<AliasMidWay>(newAlias);

            Command command;

            try
            {
                command = await _commandsRepo.GetDbCommandByIdAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Problem();
            }

            midAlias.Command = command.Line;

            var mappedAlias = _mapper.Map<AliasReadDto>(midAlias);

            return command.Line.Length > 0
                ? CreatedAtRoute(nameof(GetAliasByCommandIdAsync), new {Id = command.Id}, mappedAlias)
                : Problem(statusCode: 405);
        }
    }
}