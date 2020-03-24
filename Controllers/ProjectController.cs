using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using file_service.Data;
using file_service.Dtos;
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
    private readonly IMapper _mapper;
    public ProjectController(IConfiguration config, IFileRepository repo, IMapper mapper)
    {
      _mapper = mapper;
      _repo = repo;
      _config = config;
    }

    [HttpGet]
    public async Task<IActionResult> GetProjects()
    {
      var projectFromRepo = await _repo.GetProjects(new ProjectParams());
      var projectDto = _mapper.Map<IEnumerable<ProjectDto>>(projectFromRepo);
      return Ok(projectDto);
    }
  }
}