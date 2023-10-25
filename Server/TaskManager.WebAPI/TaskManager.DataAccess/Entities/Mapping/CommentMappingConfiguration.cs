using AutoMapper;
using System.Text;

namespace TaskManager.DataAccess.Entities.Mapping
{
    public class CommentMappingConfiguration : Profile
    {
        public CommentMappingConfiguration()
        {
            CreateMap<CoreComment, EntityComment>()
                .ForMember(c => c.Id, o => o.Ignore())
                .ForMember(c => c.Task, o => o.Ignore())
                .ForMember(c => c.Content, o => o.MapFrom(c => Encoding.ASCII.GetBytes(c.Content)));

            CreateMap<EntityComment, CoreComment>()
                .ForMember(c => c.Id, o => o.Ignore())
                .ForMember(c => c.Content, o => o.MapFrom(c => Encoding.ASCII.GetString(c.Content)));
        }
    }
}
