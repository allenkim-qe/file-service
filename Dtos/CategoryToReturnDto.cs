using System;

namespace file_service.Dtos
{
    public class CategoryToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    }
}