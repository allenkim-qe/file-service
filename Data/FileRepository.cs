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
    public async Task<DirectoryInfo> CreateProjectDirectory(string projectName, string categoryName)
    {
      return await Task.Run(() => Directory.CreateDirectory(Path.Combine(_config.GetConnectionString("BaseFolder"), projectName + "/" + categoryName)));
    }

    public Task<List<string>> GetProjectDirectoryList()
    {
      List<string> projects = new List<string>();
      var directory= new DirectoryInfo(_config.GetConnectionString("BaseFolder"));
 
      return Task.Run(() => {
        directory
        .GetDirectories()
        .Select(dir => dir.Name)
        .ToList().ForEach(dir => projects.Add(dir));
        return projects;
      });
    }
  }
}