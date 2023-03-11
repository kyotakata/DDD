using DDD.Domain.Entities;
using System.Collections.Generic;

namespace DDD.Domain.Repositories
{
    public interface IＷeatherRepository
    {
        WeatherEntity GetLatest(int areaId);
        IReadOnlyList<WeatherEntity> GetData(); 
    }
}
