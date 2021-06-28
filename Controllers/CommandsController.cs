using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("/api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandsRepo _commandsRepo;
        private readonly IPlatformsRepo _platformsRepo;
        private readonly IMapper _mapper;

        public CommandsController(ICommandsRepo commandsRepo, IMapper mapper, IPlatformsRepo platformsRepo)
        {
            _commandsRepo = commandsRepo;
            _mapper = mapper;
            _platformsRepo = platformsRepo;
        }

        [HttpGet]
        public ActionResult<IAsyncEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _commandsRepo.GetAllCommands();
            return Ok(commandItems);
        }

        [HttpGet("{id:int}", Name="GetCommandById")]
        public async Task<ActionResult<CommandReadDto>> GetCommandByIdAsync(int id)
        {
            var commandItem = await _commandsRepo.GetCommandByIdAsync(id);

            return commandItem != null ? Ok(commandItem) : NotFound();
        }

        [HttpPost]
        public async Task<ObjectResult> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            await _commandsRepo.CreateCommandAsync(commandModel);
            await _commandsRepo.SaveChangesAsync();

            var newCommand = _mapper.Map<CommandReadDto>(commandModel);

            Platform platformName;
            
            try
            {
                platformName = _platformsRepo.GetPlatformById(commandModel.PlatformId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem();
            }
            
            newCommand.Platform = platformName.Name;

            return platformName.Name.Length > 0
                            ? CreatedAtRoute(nameof(GetCommandByIdAsync), new {newCommand.Id}, newCommand)
                            : Problem(statusCode: 405);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCommand(int id)
        {
            var commandModelFromRepoAsync = await _commandsRepo.GetDbCommandByIdAsync(id);

            if (commandModelFromRepoAsync == null) return NotFound();

            _commandsRepo.DeleteCommand(commandModelFromRepoAsync);
            await _commandsRepo.SaveChangesAsync();

            return NoContent();
        }
    }
}
