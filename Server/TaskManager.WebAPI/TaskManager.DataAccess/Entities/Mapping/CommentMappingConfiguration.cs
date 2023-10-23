using AutoMapper;

namespace TaskManager.DataAccess.Entities.Mapping
{
    public class CommentMappingConfiguration : Profile
    {
        public CommentMappingConfiguration()
        {
            CreateMap<CoreComment, EntityComment>()
                .ForMember(c => c.Task, o => o.Ignore());
        }
    }
}
