using TaskManager.Core.Services;

namespace TaskManager.Domain
{
    public class CalculationService : ICalculationService
    {
        public TimeSpan Calculate(DateTime start, DateTime cancel) =>
            cancel.TimeOfDay - start.TimeOfDay;
    }
}
