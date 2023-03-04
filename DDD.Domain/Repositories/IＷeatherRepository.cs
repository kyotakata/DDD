using DDD.Domain.Entities;

namespace DDD.Domain.Repositories
{
    public interface IＷeatherRepository
    {
        WeatherEntity GetLatest(int areaId);
    }
}
