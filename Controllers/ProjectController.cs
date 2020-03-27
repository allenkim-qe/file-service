using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using file_service.Data;
using file_service.Dtos;
using file_service.Params;
using file_service.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using file_service.Models;

namespace file_service.Controllers
{
  [ApiController]
  [Route("api/[Controller]")]
  public class ProjectController : ControllerBase
  {
    private readonly IConfiguration _config;
    private readonly IProjectRepository _repo;
    private readonly IMapper _mapper;
    public ProjectController(IConfiguration config, IProjectRepository repo, IMapper mapper)
    {
      _mapper = mapper;
      _repo = repo;
      _config = config;
    }

    [HttpGet]
    public async Task<IActionResult> GetProjects([FromQuery]ProjectParams projectParams)
    {
      var projectFromRepo = await _repo.GetProjects(projectParams);
      var projectToReturnDto = _mapper.Map<IEnumerable<ProjectToReturnDto>>(projectFromRepo);

      return Ok(projectToReturnDto);
    }

    [HttpGet("{id}", Name = "GetProject")]
    public async Task<IActionResult> GetProject(int id)
    {
      var project = await _repo.GetProject(id);
      var projectToReturn = _mapper.Map<ProjectToReturnDto>(project);

      return Ok(projectToReturn);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateProject(ProjectForCreationDto projectForCreationDto)
    {
      if(await _repo.ExistProject(projectForCreationDto.Name))
      {
        return BadRequest("Project already exists");
      }

      var projectToCreate = _mapper.Map<Project>(projectForCreationDto);

      if (await _repo.CreateProject(projectToCreate))
      {
        var projectToReturn = _mapper.Map<ProjectToReturnDto>(projectToCreate);

        return CreatedAtRoute("GetProject", new { id = projectToCreate.Id }, projectToReturn);
      }

      throw new System.Exception("Creating the Project failed");
    }
  }
}