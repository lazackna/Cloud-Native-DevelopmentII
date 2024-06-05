using Domain;
using Logic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

		private readonly ILogger<WeatherForecastController> _logger;
		private IMediator _mediator;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator m)
		{
			_logger = logger;
			_mediator = m;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(List<ApiWeather>))]
		public async Task<IActionResult> GetAllWeatherAsync(CancellationToken cancellationToken)
		{
			return Ok(await _mediator.Send(new GetWeatherRequest(), cancellationToken));
		}
	}
}