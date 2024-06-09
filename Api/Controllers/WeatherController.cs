using Domain;
using Logic.Commands;
using Logic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherController : ControllerBase
	{

		private readonly ILogger<WeatherController> _logger;
		private IMediator _mediator;

		public WeatherController(ILogger<WeatherController> logger, IMediator m)
		{
			_logger = logger;
			_mediator = m;
		}

        /// <summary>
        /// Used to retrieve all entries
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
		[HttpGet]
		[ProducesResponseType(200, Type = typeof(List<ApiWeather>))]
		public async Task<IActionResult> GetAllWeatherAsync(CancellationToken cancellationToken)
		{
			return Ok(await _mediator.Send(new GetWeatherRequest(), cancellationToken));
		}

        /// <summary>
        /// Used to delete a specific entry by sending an ID
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteWeatherAsync([FromBody]DeleteWeatherCommand request, CancellationToken cancellationToken)
        {
            // Pass the command to the corresponding command handler to perform the deletion
            var result = await _mediator.Send(request, cancellationToken);

            if (result)
            {
                // Return 204 No Content if the deletion was successful
                return NoContent();
            }
            else
            {
                // Return 404 Not Found if the Weather entity with the specified id does not exist
                return NotFound();
            }
        }

        /// <summary>
        /// Used to create a new entry to be saved in the database
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateWeatherAsync([FromBody] AddWeatherRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var command = new AddWeatherCommand(
                new DataAccess.Entities.Weather(
                    -1,
                    request.Temperature,
                    request.WindSpeed,
                    request.WindDirection,
                    request.AtmosPressure
                    )
            );

            var result = await _mediator.Send(command, cancellationToken);

            if (result == null)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return Ok(result);
        }

        /// <summary>
        /// Used to update the data of a specific entry with the given ID
        /// If id is not valid nothing will happen
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeatherAsync(int id, [FromBody] UpdateWeatherRequest request, CancellationToken cancellationToken)
        {
            if (request == null || id <= 0)
            {
                return BadRequest("Invalid request"); // Invalid request
            }

            var result = await _mediator.Send(new UpdateWeatherCommand(id, request), cancellationToken);

            if (result)
            {
                return NoContent(); // Successfully updated
            }
            else
            {
                return NotFound(); // Weather entity with the specified Id not found
            }
        }
    }
}