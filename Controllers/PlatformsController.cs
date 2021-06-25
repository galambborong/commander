using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("/api/platforms")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformsRepo _repository;
        // TODO: Set up mapping for Platform
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

        [HttpGet("{id:int}", Name="GetPlatformById")]
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

            return CreatedAtRoute(nameof(GetPlatformById), new {newPlatform.Id}, newPlatform);
        }

        [HttpPatch("{id:int}")]
        public ActionResult PatchPlatform(int id, JsonPatchDocument<Platform> patchedPlatform)
        {
            var platformFromRepo = _repository.GetPlatformById(id);
            if (platformFromRepo == null) return NotFound();
            
            patchedPlatform.ApplyTo(platformFromRepo, ModelState);

            if (!TryValidateModel(platformFromRepo)) return ValidationProblem(ModelState);
            
            _repository.UpdatePlatform(platformFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}