using System;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
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
        
        [HttpGet(Name="GetAliasByCommandId")]
        public ActionResult<AliasReadDto> GetAliasByCommandId(int id)
        {
            var aliasItem = _aliasesRepo.GetAliasByCommandId(id);
            var mappedAliasItem = _mapper.Map<AliasReadDto>(aliasItem);

            return aliasItem != null ? Ok(mappedAliasItem) : NotFound();
        }

        [HttpPost]
        public ActionResult<AliasReadDto> CreateAlias(Alias newAlias, int id)
        {
            _aliasesRepo.CreateAlias(newAlias);
            _aliasesRepo.SaveChanges();

            var midAlias = _mapper.Map<AliasMidWay>(newAlias);

            Command command;

            try
            {
                command = _commandsRepo.GetDbCommandByIdAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Problem();
            }

            midAlias.Command = command.Line;

            var mappedAlias = _mapper.Map<AliasReadDto>(midAlias);
            
            return command.Line.Length > 0 
                            ? CreatedAtRoute(nameof(GetAliasByCommandId), new { Id = command.Id}, mappedAlias)
                            : Problem(statusCode: 405);
        }
    }
}