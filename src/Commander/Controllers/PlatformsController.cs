using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Data;
using Commander.Models;
using Commander.Repositories;
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

        [HttpGet("{id:int}", Name="GetPlatformByIdAsync")]
        public async Task<ActionResult<Platform>> GetPlatformByIdAsync(int id)
        {
            Console.WriteLine($"{id}<<");
            var platformItem = await _repository.GetPlatformByIdAsync(id);
            return platformItem != null ? Ok(platformItem) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Platform>> CreatePlatformAsync(Platform newPlatform)
        {
            await _repository.CreatePlatformAsync(newPlatform);
            await _repository.SaveChangesAsync();

            return CreatedAtRoute(nameof(GetPlatformByIdAsync), new {newPlatform.Id}, newPlatform);
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> PatchPlatform(int id, JsonPatchDocument<Platform> patchedPlatform)
        {
            var platformFromRepo = await _repository.GetPlatformByIdAsync(id);
            if (platformFromRepo == null) return NotFound();
            
            patchedPlatform.ApplyTo(platformFromRepo, ModelState);

            if (!TryValidateModel(platformFromRepo)) return ValidationProblem(ModelState);
            
            await _repository.UpdatePlatformAsync(platformFromRepo);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}