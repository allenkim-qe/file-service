using AutoMapper;
using file_service.Dtos;
using file_service.Models;

namespace file_service.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Project, ProjectToReturnDto>();
            CreateMap<ProjectForCreationDto, Project>();
        }
    }
}