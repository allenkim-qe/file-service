using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using file_service.Helpers;
using file_service.Models;
using file_service.Params;
using Microsoft.Extensions.Configuration;

namespace file_service.Data
{

  public class FileRepository : IFileRepository
  {
    private readonly IConfiguration _config;
    public FileRepository(IConfiguration config)
    {
      _config = config;

    }
    public async Task<DirectoryInfo> CreateProject(string projectName, string categoryName)
    {
      return await Task.Run(() => Directory.CreateDirectory(Path.Combine(_config.GetConnectionString("BaseFolder"), projectName + "/" + categoryName)));
    }

    public async Task<PagedList<Project>> GetProjects(ProjectParams projectParams)
    {
      List<Project> projects = new List<Project>();
      var directory= new DirectoryInfo(_config.GetConnectionString("BaseFolder"));
      
      directory
        .GetDirectories()
        .Select(dir => dir.Name)
        .ToList().ForEach(dir => projects.Add(new Project {
          Name = dir
        }));
 
      return await PagedList<Project>.CreateAsync(projects, projectParams.PageNumber, projectParams.PageSize);
    }
  }
}