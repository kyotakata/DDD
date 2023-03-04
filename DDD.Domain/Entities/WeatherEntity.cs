using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Entities
{
    public class WeatherEntity
    {
        public WeatherEntity(int areaId, 
            DateTime dataDate, 
            int condition,
            float temperature)
        {
            AreaId= areaId;
            DataDate = dataDate;
            Condition= condition;
            Temperature= temperature;
        }

        public int AreaId { get; }
        public DateTime DataDate { get; }
        public int Condition { get; }
        public float Temperature { get; }
    }
}
