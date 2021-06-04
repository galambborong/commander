using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
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
            return Ok(_mapper.Map<IEnumerable<PublicCommand>>(commandItems));
        }

        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<PublicCommand> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            Console.WriteLine("{0}", commandItem);
            return Ok(commandItem);
        }

        // [HttpPost]
        // public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        // {
        //     var commandModel = _mapper.Map<Command>(commandCreateDto);
        //     _repository.CreateCommand(commandModel);
        //     _repository.SaveChanges();
        //
        //     var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
        //     
        //     return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);
        // }
    }
}