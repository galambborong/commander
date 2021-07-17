using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using static System.IO.File;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Commander.Controllers
{
    [Route("/api")]
    [ApiController]
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            const string fileName = "endpoints.json";
 
            // TODO Look into returning the file properly, so it as actual JSON
            return Ok(ReadAllText(fileName));
        }
    }
}