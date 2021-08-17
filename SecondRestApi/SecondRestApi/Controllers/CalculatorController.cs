using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SecondRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string SecondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(SecondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(SecondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Comando Invalido");
        }

        private decimal ConvertToDecimal(string value)
        {
            decimal decimalValue;
            if (decimal.TryParse(value, out decimalValue))
                return decimalValue;
            return 0;
        }

        private bool IsNumeric(string value)
        {
            double number;
            bool isNumber = double.TryParse(
                value, 
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }
    }
}
