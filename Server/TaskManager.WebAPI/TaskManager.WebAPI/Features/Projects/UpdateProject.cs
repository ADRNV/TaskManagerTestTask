using MediatR;
using TaskManager.Core.Services;

namespace TaskManager.WebAPI.Features.Projects
{
    public class UpdateProject
    {
        public record Command(CoreProject Project) : IRequest<Guid>;

        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly IService<CoreProject> _projectsService;

            public Handler(IService<CoreProject> projectsService)
            {
                _projectsService = projectsService;
            }

            public Task<Guid> Handle(Command request, CancellationToken cancellationToken) =>
                _projectsService.Update(request.Project);
        }
    }
}
