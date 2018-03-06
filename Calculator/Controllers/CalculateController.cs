
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Calculator.Models;
using Calculator.Services;

namespace Calculator.Controllers
{
    [Route("api/[controller]")]
    [EnableCors(CORsPolicyNames.AllowSpecificOrigin)]
    public class CalculateController : Controller
    {
        private readonly ICalculationService _CalculationService;

        public CalculateController(ICalculationService calculationService)
        {
            _CalculationService = calculationService;
        }

        [HttpPost]
        public string Post([FromBody] CalculationInputs model)
        {
            return this._CalculationService.DoCalculation(model).ToString();
        }
    }
}
