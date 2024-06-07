using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Commands
{
    public class UpdateWeatherCommand : IRequest<bool>
    {
        public UpdateWeatherCommand(int id, float temperature, float windSpeed, float windDirection, float atmosPressure)
        {
            this.Id = id;
            this.Temperature = temperature;
            this.WindSpeed = windSpeed;
            this.WindDirection = windDirection;
            this.AtmosPressure = atmosPressure;
        }

        public UpdateWeatherCommand(int id, UpdateWeatherRequest request)
        {
            this.Id = id;
            this.Temperature = request.Temperature;
            this.WindSpeed = request.WindSpeed;
            this.WindDirection = request.WindDirection;
            this.AtmosPressure = request.AtmosPressure;
        }

        public int Id { get; set; }
        public float Temperature { get; set; }
        public float WindSpeed { get; set; }
        public float WindDirection { get; set; }
        public float AtmosPressure { get; set; }
    }
}
