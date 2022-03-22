using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static System.IO.File;

namespace Commander.Controllers;

[Route("/api")]
[ApiController]
public class ApiController : Controller
{
    private readonly ILogger _logger;

    public ApiController(ILogger<ApiController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        const string fileName = "endpoints.json";

        var buffer = ReadAllText(fileName);
        
        _logger.LogInformation($"Buffer is: {buffer}");

        var jsonContents = JsonConvert.DeserializeObject(buffer);

        return Ok(jsonContents);
    }
}