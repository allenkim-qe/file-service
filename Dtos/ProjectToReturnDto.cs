using System;
using System.Collections.Generic;
using file_service.Models;

namespace file_service.Dtos
{
    public class ProjectToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string url { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

    }
}