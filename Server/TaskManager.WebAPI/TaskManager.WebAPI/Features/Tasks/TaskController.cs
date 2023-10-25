using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.WebAPI.Features.Tasks
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : MediatrController
    {
        public TaskController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("calc")]
        public async Task<TimeSpan> GetAmountTime(DateTime start, DateTime cancelDate)
        {
            return await _mediator.Send(new CalculateTimeAmount.Command(start, cancelDate));
        }
    }
}
