using System;
using System.Collections.Generic;

namespace file_service.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string url { get; set; }
        public List<string> Items { get; set; }
        public DateTime Created { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}