using DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Commands
{
    public class DeleteWeatherHandler : IRequestHandler<DeleteWeatherCommand, bool>
    {
        private readonly DataContext _context;

        public DeleteWeatherHandler(DataContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> Handle(DeleteWeatherCommand request, CancellationToken cancellationToken)
        {
            var weatherToDelete = await _context.WeatherData.FindAsync(request.Id);

            if (weatherToDelete == null)
            {
                // The Weather entity with the specified Id does not exist
                return false;
            }

            // Remove the Weather entity from the Weather DbSet
            _context.WeatherData.Remove(weatherToDelete);

            // Save changes to the database
            await _context.SaveChangesAsync(cancellationToken);

            // Return true to indicate successful deletion
            return true;
        }
    }
}
