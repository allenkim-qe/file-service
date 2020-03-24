using System.Threading.Tasks;
using file_service.Data;
using file_service.Params;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace file_service.Controllers
{
  [ApiController]
  [Route("api/[Controller]")]
  public class ProjectController : ControllerBase
  {
    private readonly IConfiguration _config;
    private readonly IFileRepository _repo;
    public ProjectController(IConfiguration config, IFileRepository repo)
    {
      _repo = repo;
      _config = config;
    }

    [HttpGet]
    public async Task<IActionResult> GetProjects()
    {
      var projectFromRepo = await _repo.GetProjects(new ProjectParams());

      return Ok(projectFromRepo);
    }
  }
}