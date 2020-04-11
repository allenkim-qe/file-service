using System;
using System.Collections.Generic;

namespace file_service.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public ICollection<Category> Category { get; set; }
        public DateTime Created { get; set; }
    }
}