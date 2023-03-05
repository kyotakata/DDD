using DDD.Domain.ValueObjects;
using System;

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
            Condition= new Condition(condition);
            Temperature= new Temperature(temperature);
        }

        public int AreaId { get; }
        public DateTime DataDate { get; }
        public Condition Condition { get; }
        public Temperature Temperature { get; }
    }
}
