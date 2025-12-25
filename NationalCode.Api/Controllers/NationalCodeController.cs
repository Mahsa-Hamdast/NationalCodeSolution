using Microsoft.AspNetCore.Mvc;
using NationalCode.Application.Services;

namespace NationalCode.Api.Controllers;

[ApiController]
[Route("api/national-code")]
public class NationalCodeController : ControllerBase
{
    private readonly INationalCodeValidator _validator;

    public NationalCodeController(INationalCodeValidator validator)
    {
        _validator = validator;
    }

    [HttpGet("validate")]
    public IActionResult Validate([FromQuery] string nationalCode)
    {
        if (string.IsNullOrWhiteSpace(nationalCode))
            return BadRequest("کد ملی ارسال نشده است");

        bool isValid = _validator.IsValid(nationalCode);

        return Ok(new
        {
            nationalCode,
            isValid
        });
    }
}
