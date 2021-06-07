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
        public ActionResult<IEnumerable<PublicCommand>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(commandItems);
        }

        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<PublicCommand> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            return commandItem != null ? Ok(commandItem) : NotFound();
        }

        [HttpPost]
        public ActionResult<PublicCommand> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var newCommand = _mapper.Map<PublicCommand>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new {Id = newCommand.Id}, newCommand);
        }
    }
}
