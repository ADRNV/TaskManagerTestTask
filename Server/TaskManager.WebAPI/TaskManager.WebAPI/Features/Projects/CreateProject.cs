using MediatR;
using TaskManager.Core.Services;

namespace TaskManager.WebAPI.Features.Projects
{
    public class CreateProject
    {
        public record Command(CoreProject Project) : IRequest<Guid>;

        public class Handler : IRequestHandler<Command, Guid>
        {
            public IService<CoreProject> _projectsService;

            public Handler(IService<CoreProject> projectsService)
            {
                _projectsService = projectsService;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken) =>
               await _projectsService.Create(request.Project);
        }
    }
}
