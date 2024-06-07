using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Weather
    {
        public Weather(int id, float temperature, float windSpeed, float windDirection, float atmosPressure)
        {
            this.Id = id;
            this.Temperature = temperature;
            this.WindSpeed = windSpeed;
            this.WindDirection = windDirection;
            this.AtmosPressure = atmosPressure;
        }

        public Weather()
        {
        }

        public int Id { get; set; }
        public float Temperature { get; set; }
        public float WindSpeed { get; set; }
        public float WindDirection { get; set; }
        public float AtmosPressure { get; set; }
    }
}
