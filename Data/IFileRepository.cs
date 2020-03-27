using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using file_service.Helpers;
using file_service.Models;
using file_service.Params;

namespace file_service.Data
{
    public interface IFileRepository
    {
        Task<DirectoryInfo> CreateProjectDirectory(string projectName, string categoryName);
        Task<List<string>> GetProjectDirectoryList();
    }
}