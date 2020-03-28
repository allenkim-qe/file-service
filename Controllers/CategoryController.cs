using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using file_service.Data;
using file_service.Dtos;
using file_service.Helpers;
using file_service.Models;
using file_service.Params;
using Microsoft.AspNetCore.Mvc;

namespace file_service.Controllers
{
    [ApiController]
    [Route("api/project/{projectId}/[Controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepo;
        public CategoryController(ICategoryRepository repo, IProjectRepository projectRepo, IFileRepository fileRepository, IMapper mapper)
        {
            _projectRepo = projectRepo;
            _mapper = mapper;
            _fileRepository = fileRepository;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories(int projectId, [FromQuery]CategoryParams categoryParams)
        {
            var categoriesForRepo = await _repo.GetCategories(projectId, categoryParams);
            var categoryToReturn = _mapper.Map<IEnumerable<CategoryToReturnDto>>(categoriesForRepo);

            return Ok(categoryToReturn);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<IActionResult> GetCategory(int projectId, int id)
        {
            if (!await _projectRepo.ExistProject(projectId))
            {
                return Unauthorized();
            }

            var category = _repo.GetCategory(id);

            var categoryToReturn = _mapper.Map<CategoryToReturnDto>(category);

            return Ok(categoryToReturn);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(int projectId, CategoryForCreationDto categoryForCreationDto)
        {
            if (!await _projectRepo.ExistProject(projectId))
            {
                return Unauthorized();
            }

            if (await _repo.ExistCategory(categoryForCreationDto.Name))
            {
                return BadRequest("Category already exists");
            }

            var projectFromRepo = await _projectRepo.GetProject(projectId);
            var categoryToCreate = _mapper.Map<Category>(categoryForCreationDto);

            var categoryDirectoryInfo = await _fileRepository.CreateCategoryDirectory(projectFromRepo.Name, categoryToCreate.Name);
            categoryToCreate.Path = categoryDirectoryInfo.ToString();


            if (await _repo.CreateCategory(projectId, categoryToCreate))
            {
                var categoryToReturn = _mapper.Map<CategoryToReturnDto>(categoryToCreate);
                return CreatedAtRoute("GetCategory", new { projectId, id = categoryToCreate.Id }, categoryToReturn);
            }

            throw new System.Exception("Creating the category failed");
        }
    }
}