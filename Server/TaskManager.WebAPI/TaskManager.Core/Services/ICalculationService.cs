namespace TaskManager.Core.Services
{
    public interface ICalculationService
    {
        public TimeSpan Calculate(DateTime start, DateTime cancel);
    }
}
