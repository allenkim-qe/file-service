using System;
using System.ComponentModel.DataAnnotations;

namespace file_service.Dtos
{
    public class ProjectForCreationDto
    {
        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "You must specify project name between 4 and 20 characters")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public ProjectForCreationDto()
        {
            Created = DateTime.Now;
        }
    }
}