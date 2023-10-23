using AutoMapper;

namespace TaskManager.DataAccess.Entities.Mapping
{
    public class TaskMappingConfiguration : Profile
    {
        public TaskMappingConfiguration()
        {
            CreateMap<CoreTask, EntityTask>()
                .ForMember(t => t.Comments, o => o.MapFrom(t => t.Comments))
                .ForMember(t => t.Project, o => o.MapFrom(t => t.Project))
                .ReverseMap();
        }
    }
}
