using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ApiWeather
    {
        public ApiWeather(int id, float temperature, float windSpeed, float windDirection, float atmosPressure)
        {
            this.Id = id;
            this.Temperature = temperature;
            this.WindSpeed = windSpeed;
            this.WindDirection = windDirection;
            this.AtmosPressure = atmosPressure;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public float Temperature { get; set; }

        [Required]
        public float WindSpeed { get; set; }

        [Required]
        public float WindDirection { get; set; }

        [Required]
        public float AtmosPressure { get; set; }
    }
}