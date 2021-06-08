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
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(commandItems);
        }

        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            return commandItem != null ? Ok(commandItem) : NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var newCommand = _mapper.Map<CommandReadDto>(commandModel);

            var platformName = new Platform();
            
            try
            {
                platformName = _repository.GetPlatformById(commandModel.PlatformId);
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
    }
}
