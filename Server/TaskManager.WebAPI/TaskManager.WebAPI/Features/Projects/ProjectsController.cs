using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.WebAPI.Features.Projects
{
    /// <summary>
    /// CRUD controller for projects
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : MediatrController
    {
        public ProjectsController(IMediator mediator) : base(mediator)
        {
            
        }

        /// <summary>
        /// Gets projects page
        /// </summary>
        /// <param name="page">page number</param>
        /// <param name="size">items on page</param>
        /// <returns>List of projects</returns>
        [HttpGet("page")]
        public Task<IEnumerable<CoreProject>> GetPage(int page, int size) =>
            _mediator.Send(new GetProjects.Command(page, size));

        /// <summary>
        /// Create projects
        /// </summary>
        /// <param name="project">Projects</param>
        /// <returns>Id of project</returns>
        [HttpPost("create")]
        public async Task<Guid> Create(CoreProject project) =>
            await _mediator.Send(new CreateProject.Command(project));

        /// <summary>
        /// Update project
        /// </summary>
        /// <param name="coreProject">Project</param>
        /// <returns>Id of changed project</returns>
        [HttpPut("update")]
        public async Task<Guid> Update(CoreProject coreProject) =>
            await _mediator.Send(new UpdateProject.Command(coreProject));
    }
}
