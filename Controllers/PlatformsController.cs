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
        private readonly IPlatformsRepo _repository;
        // private readonly IMapper _mapper;

        public PlatformsController(IPlatformsRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Platform>> GetAllPlatforms()
        {
            var platformItems = _repository.GetAllPlatforms();
            
            return Ok(platformItems);
        }

        [HttpGet("{id}", Name="GetPlatformById")]
        public ActionResult<Platform> GetPlatformById(int id)
        {
            var platformItem = _repository.GetPlatformById(id);
            return platformItem != null ? Ok(platformItem) : NotFound();
        }

        [HttpPost]
        public ActionResult<Platform> CreatePlatform(Platform newPlatform)
        {
            _repository.CreatePlatform(newPlatform);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetPlatformById), new {Id = newPlatform.Id}, newPlatform);
        }

    }
}