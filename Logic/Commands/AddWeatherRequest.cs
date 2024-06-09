using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Commands
{
    public class AddWeatherRequest
    {
        public AddWeatherRequest(float temperature, float windSpeed, float windDirection, float atmosPressure)
        {
            this.Temperature = temperature;
            this.WindSpeed = windSpeed;
            this.WindDirection = windDirection;
            this.AtmosPressure = atmosPressure;
        }

        public AddWeatherRequest(ApiWeather weather)
        {
            this.Temperature = weather.Temperature;
            this.WindSpeed = weather.WindSpeed;
            this.WindDirection = weather.WindDirection;
            this.AtmosPressure = weather.AtmosPressure;
        }

        public float Temperature { get; set; }
        public float WindSpeed { get; set; }
        public float WindDirection { get; set; }
        public float AtmosPressure { get; set; }
    }
}
