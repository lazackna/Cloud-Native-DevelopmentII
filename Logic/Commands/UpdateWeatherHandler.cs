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
    public class UpdateWeatherHandler : IRequestHandler<UpdateWeatherCommand, bool>
    {
        private readonly DataContext _context;

        public UpdateWeatherHandler(DataContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> Handle(UpdateWeatherCommand request, CancellationToken cancellationToken)
        {
            var weatherToUpdate = await _context.WeatherData.FindAsync(request.Id);

            if (weatherToUpdate == null)
            {
                return false; // Weather entity not found
            }

            // Update properties
            weatherToUpdate.Temperature = request.Temperature;
            weatherToUpdate.WindSpeed = request.WindSpeed;
            weatherToUpdate.WindDirection = request.WindDirection;
            weatherToUpdate.AtmosPressure = request.AtmosPressure;

            await _context.SaveChangesAsync(cancellationToken);

            return true; // Successfully updated
        }
    }
}
