using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _commandsRepo.GetAllCommands();
            return Ok(commandItems);
        }

        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _commandsRepo.GetCommandById(id);

            return commandItem != null ? Ok(commandItem) : NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _commandsRepo.CreateCommand(commandModel);
            _commandsRepo.SaveChanges();

            var newCommand = _mapper.Map<CommandReadDto>(commandModel);

            var platformName = new Platform();
            
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
                            ? CreatedAtRoute(nameof(GetCommandById), new {Id = newCommand.Id}, newCommand)
                            : Problem(statusCode: 405);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _commandsRepo.GetDbCommandById(id);
            
            if (commandModelFromRepo == null) return NotFound();

            _commandsRepo.DeleteCommand(commandModelFromRepo);
            _commandsRepo.SaveChanges();

            return NoContent();
        }
    }
}
