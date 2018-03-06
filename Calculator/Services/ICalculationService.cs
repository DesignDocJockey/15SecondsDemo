using Calculator.Models;

namespace Calculator.Services
{
    public interface ICalculationService
    {
        decimal DoCalculation(CalculationInputs inputs);
    }
}
