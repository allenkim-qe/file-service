using System.Threading.Tasks;
using file_service.Helpers;
using file_service.Models;
using file_service.Params;
using Microsoft.EntityFrameworkCore;

namespace file_service.Data
{
  public class ProjectRepository : IProjectRepository
  {
    private readonly DataContext _context;
    public ProjectRepository(DataContext context)
    {
      _context = context;
    }
    public async Task<bool> CreateProject(Project project)
    {
        await _context.Projects.AddAsync(project);

        if (await _context.SaveChangesAsync() > 0)
            return true;

        return false;
    }

    public async Task<bool> ExistProject(string projectName)
    {
      if(await _context.Projects.AnyAsync(p=> p.Name == projectName))
      {
          return true;
      }

      return false;
    }

    public async Task<Project> GetProject(int id)
    {
      var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

      return project;
    }

    public async Task<PagedList<Project>> GetProjects(ProjectParams projectParams)
    {
      var projects = _context.Projects.AsQueryable();

      return await PagedList<Project>.CreateAsync(projects, projectParams.PageNumber, projectParams.PageSize);
    }

    public async Task<bool> SaveAll()
    {
      return await _context.SaveChangesAsync() > 0;
    }
  }
}