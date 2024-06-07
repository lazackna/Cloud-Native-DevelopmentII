using DataAccess;
using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Commands
{
    public class AddWeatherHandler : IRequestHandler<AddWeatherCommand, Weather>
    {
        private readonly DataContext _context;

        public AddWeatherHandler(DataContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Weather> Handle(AddWeatherCommand request, CancellationToken cancellationToken)
        {
            var dataWeather = new Weather();
            dataWeather.WindSpeed = request.Weather.WindSpeed;
            dataWeather.WindDirection = request.Weather.WindDirection;
            dataWeather.Temperature = request.Weather.Temperature;
            dataWeather.AtmosPressure = request.Weather.AtmosPressure;
            _context.WeatherData.Add(dataWeather);
            await _context.SaveChangesAsync(cancellationToken);

            return _context.WeatherData.ToList().Last();
        }
    }
}
