using MediatR;
using TaskManager.Core.Models;
using TaskManager.Core.Services;

namespace TaskManager.WebAPI.Features.Projects
{
    public class GetProjects
    {
        public record Command(int Page, int Size) : IRequest<IEnumerable<Project>>;

        public class Handler : IRequestHandler<Command, IEnumerable<Project>>
        {
            private readonly IService<Project> _projectsService;

            public Handler(IService<Project> projectsService)
            {
                _projectsService = projectsService;
            }

            public async Task<IEnumerable<Project>> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _projectsService.Get(request.Page, request.Size);
            }
        }
    }
}
