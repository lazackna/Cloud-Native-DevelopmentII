using DataAccess;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Queries
{
    public class GetWeatherHandler : IRequestHandler<GetWeatherRequest, List<ApiWeather>>
    {
        private readonly DataContext _context;

        public GetWeatherHandler(DataContext context)
        {
            _context = context;
        }

        public Task<List<ApiWeather>> Handle(GetWeatherRequest request, CancellationToken cancellationToken)
        {
            return _context.WeatherData.Select(b => new ApiWeather(
                b.Id, b.Temperature, b.WindSpeed, b.WindDirection, b.AtmosPressure)).ToListAsync(cancellationToken);
        }
    }
}
