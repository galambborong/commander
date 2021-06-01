using System.Collections.Generic;
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

    }
}