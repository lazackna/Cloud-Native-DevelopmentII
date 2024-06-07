using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Commands
{
    public class AddWeatherCommand : IRequest<Weather>
    {
        public Weather Weather { get; }

        public AddWeatherCommand(Weather weather)
        {
            Weather = weather;
        }
    }
}
