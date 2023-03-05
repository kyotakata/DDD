﻿using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
using DDD.WinForm.Common;
using System;

namespace DDD.WinForm.ViewModels
{
    public class WeatherLatestViewModel
    {
        private IＷeatherRepository _ｗeather;

        public WeatherLatestViewModel(IＷeatherRepository ｗeather)
        {
            _ｗeather = ｗeather;
        }

        public string AreaIdText { get; set; } = string.Empty;
        public string DataDateText { get; set; } = string.Empty;
        public string ConditionText { get; set; } = string.Empty;
        public string TemperatureText { get; set; } = string.Empty;

        public void Search()
        {
            var entity = _ｗeather.GetLatest(Convert.ToInt32(AreaIdText));
            if (entity != null)
            {
                DataDateText = entity.DataDate.ToString();
                ConditionText = entity.Condition.ToString();
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }

        }
    }
}
