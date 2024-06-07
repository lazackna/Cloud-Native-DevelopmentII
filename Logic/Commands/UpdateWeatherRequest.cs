using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Commands
{
    public class UpdateWeatherRequest
    {
        public UpdateWeatherRequest(float temperature, float windSpeed, float windDirection, float atmosPressure)
        {
            this.Temperature = temperature;
            this.WindSpeed = windSpeed;
            this.WindDirection = windDirection;
            this.AtmosPressure = atmosPressure;
        }

        public float Temperature { get; set; }
        public float WindSpeed { get; set; }
        public float WindDirection { get; set; }
        public float AtmosPressure { get; set; }
    }
}
