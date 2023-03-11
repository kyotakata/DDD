using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WinForm.ViewModels
{
    public class WeatherListViewModel : ViewModelBase
    {
        private IＷeatherRepository _weather;
        public WeatherListViewModel(IＷeatherRepository weather)
        {
            _weather = weather;

            foreach (var entity in _weather.GetData())
            {
                Weathers.Add(new WeatherListViewModelWeather(entity));
            }
        }
        public BindingList<WeatherListViewModelWeather> 
            Weathers { get; set; } = new BindingList<WeatherListViewModelWeather>();
    }
}
