using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Weather
{
    public class AddWeatherRequest : IRequest<Unit>
    {
        public AddWeatherRequest(ApiWeather weather)
            => Weather = weather;

        public ApiWeather Weather { get; }
    }
}
