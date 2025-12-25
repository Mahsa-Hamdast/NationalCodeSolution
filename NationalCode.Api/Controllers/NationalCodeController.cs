using Microsoft.AspNetCore.Mvc;
using NationalCode.Application.Services;

namespace NationalCode.Api.Controllers
{
    [ApiController]
    [Route("api/national-code")]
    public class NationalCodeController : ControllerBase
    {
        [HttpGet("validate")]
        public IActionResult Validate([FromQuery] string nationalCode)
        {
            bool isValid = NationalCodeValidator.IsValid(nationalCode);

            return Ok(new
            {
                nationalCode,
                isValid
            });
        }
    }

}
