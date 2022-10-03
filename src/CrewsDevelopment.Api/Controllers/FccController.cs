using CrewsDevelopment.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrewsDevelopment.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FccController : ControllerBase
{
	private readonly ILogger<FccController> _logger;

	public FccController(ILogger<FccController> logger) => _logger = logger;

	[HttpGet("timestamp/api/{input}")]
	public IActionResult TimestampMicroservice(string? input = default)
	{
		try
		{
			DateTime dateTime = DateTime.Now;
			if (input != default)
			{
				if (Int64.TryParse(input, out Int64 numericInput))
				{
					return Ok(new TimestampModel(numericInput));
				}
				dateTime = DateTime.Parse(input);

				// Adjust for time zone
				dateTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime, TimeZoneInfo.Local);
				return Ok(new TimestampModel(dateTime));
			}
			return Ok(new TimestampModel());
		}
		catch (Exception)
		{
			return BadRequest(new TimestampError());
		}
	}
}
