using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("/api/platforms")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        // private readonly IMapper _mapper;

        public PlatformsController(ICommanderRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Platform>> GetAllPlatforms()
        {
            var platformItems = _repository.GetAllPlatforms();
            
            return Ok(platformItems);
        }

        [HttpGet("{id}")]
        public ActionResult<Platform> GetPlatformById(int id)
        {
            var platformItem = _repository.GetPlatformById(id);
            return platformItem != null ? Ok(platformItem) : NotFound();
        }

    }
}