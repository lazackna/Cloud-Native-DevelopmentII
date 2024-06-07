using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class MeasurementData
    {
        public int Id { get; set; }
        public float Temperature { get; set; }
        public float WindSpeed { get; set; }
        public float WindDirection { get; set; }
        public float AtmosPressure { get; set; }
        public int SeasonId { get; set; }
    }
}
