using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ApiWeather
    {
        public ApiWeather(string name) 
        {
            Name = name;
        }
        [Required]
        public string Name { get; set; }
    }
}