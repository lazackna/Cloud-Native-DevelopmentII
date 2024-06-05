using DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Weather
{
    public class AddWeatherHandler : IRequestHandler<AddWeatherRequest, Unit>
    {
        private readonly DataContext _context;
        public AddWeatherHandler(DataContext context)
        {
            _context = context;
        }
        public Task<Unit> Handle(AddWeatherRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private static void Validate(AddWeatherRequest request)
        {

        }
    }
}
