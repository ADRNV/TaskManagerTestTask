using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Core.Services;

namespace TaskManager.WebAPI.Features.Tasks
{
    public class CalculateTimeAmount
    { 
        public record Command(DateTime Start, DateTime Cancel) : IRequest<TimeSpan>;

        public class Handler : IRequestHandler<Command, TimeSpan>
        {
            private readonly ICalculationService _calculationService;

            public Handler(ICalculationService calculationService)
            {
                _calculationService = calculationService;
            }

            public async Task<TimeSpan> Handle(Command request, CancellationToken cancellationToken) =>
               await Task.FromResult(_calculationService.Calculate(request.Start, request.Cancel));
        }
    }
}
