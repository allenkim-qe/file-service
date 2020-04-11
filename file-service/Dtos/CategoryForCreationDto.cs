using System;
using System.ComponentModel.DataAnnotations;

namespace file_service.Dtos
{
    public class CategoryForCreationDto
    {
        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "You must specify category name between 4 and 20 characters")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public CategoryForCreationDto()
        {
            Created = DateTime.Now;
        }
    }
}