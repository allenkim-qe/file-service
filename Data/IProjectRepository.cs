using System.Threading.Tasks;
using file_service.Helpers;
using file_service.Models;
using file_service.Params;

namespace file_service.Data
{
    public interface IProjectRepository
    {
        Task<PagedList<Project>> GetProjects(ProjectParams projectParams);

        Task<Project> GetProject(int id);
        Task<bool> CreateProject(Project project);
        Task<bool> ExistProject(string projectName);
        Task<bool> SaveAll();
    }
}