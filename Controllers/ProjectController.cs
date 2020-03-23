using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace file_service.Controllers
{
  [ApiController]
  [Route("api/[Controller]")]
  public class ProjectController : ControllerBase
  {
    private readonly IConfiguration _config;
    public ProjectController(IConfiguration config)
    {
      _config = config;
    }

    [HttpGet]
    public async Task<IActionResult> GetProjects()
    {

    }
  }
}