using AutoMapper;

namespace TaskManager.DataAccess.Entities.Mapping
{
    public class ProjectMappingConfiguration : Profile
    {
        public ProjectMappingConfiguration()
        {
            CreateMap<CoreProject, EntityProject>()
                .ForMember(p => p.Id, o => o.Ignore())
                .ForMember(p => p.Tasks, o => o.MapFrom(p => p.Tasks))
                .ReverseMap();

        }
    }
}
