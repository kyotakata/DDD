using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WinForm.ViewModels
{
    public sealed class WeatherListViewModelWeather
    {
        private WeatherEntity _entity;
        public WeatherListViewModelWeather(WeatherEntity entity)
        {
            _entity = entity;
        }

        public string AreaId => _entity.AreaId.ToString();
        public string AreaName => _entity.AreaName;
        public string DataDate => _entity.DataDate.ToString();
        public string Condition => _entity.Condition.DisplayValue;
        public string Temperature => _entity.Temperature.DisplayValueWithUnitSpace;
    }
}
