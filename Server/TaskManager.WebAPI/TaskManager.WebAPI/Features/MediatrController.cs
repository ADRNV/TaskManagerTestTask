using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.WebAPI.Features
{
    public class MediatrController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public MediatrController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
