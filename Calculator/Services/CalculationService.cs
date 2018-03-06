using System;
using Calculator.Models;

namespace Calculator.Services
{
    public class CalculationService : ICalculationService
    {
        public decimal DoCalculation(CalculationInputs inputs)
        {
            var isValidInput = Decimal.TryParse(inputs.InputValueOne, out var firstValue);
            isValidInput = Decimal.TryParse(inputs.InputValueTwo, out var secondValue);
            isValidInput = Decimal.TryParse(inputs.InputValueThree, out var thirdValue);
            isValidInput = Decimal.TryParse(inputs.InputValueFour, out var fourthValue);

            if (isValidInput)
                return (((firstValue) * (secondValue)) + thirdValue) / fourthValue;
            else if (isValidInput && Decimal.Compare(fourthValue, 0) == 0)
                return 0;

            return 0;
        }
    }
}
