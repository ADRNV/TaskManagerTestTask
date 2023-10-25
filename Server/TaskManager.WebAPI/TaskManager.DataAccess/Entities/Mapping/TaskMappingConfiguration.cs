using AutoMapper;

namespace TaskManager.DataAccess.Entities.Mapping
{
    public class TaskMappingConfiguration : Profile
    {
        public TaskMappingConfiguration()
        {
            CreateMap<CoreTask, EntityTask>()
                .ForMember(t => t.Id, o => o.Ignore())
                .ForMember(t => t.Comments, o => o.MapFrom(t => t.Comments))
                .ReverseMap();
        }
    }
}
