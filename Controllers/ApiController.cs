using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("/api")]
    [ApiController]
    public class ApiController : Controller
    {
        // GET
        public IActionResult Index()
        {
            string response = "hello";
            return Ok(response);
        }
    }
}