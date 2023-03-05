using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using System;
using System.ComponentModel;

namespace DDD.WinForm.ViewModels
{
    public class WeatherLatestViewModel : ViewModelBase
    {
        private IＷeatherRepository _ｗeather;
        private IAreasRepository _areas;

        /// <summary>
        /// コンストラクタ(本番コード用)
        /// </summary>
        public WeatherLatestViewModel()
            : this(new WeatherSQLite(), null)
        {
        }

        /// <summary>
        /// コンストラクタ(テストコード用でもある)
        /// </summary>
        /// <param name="ｗeather">テストコードの時直接引数指定</param>
        public WeatherLatestViewModel(IＷeatherRepository ｗeather, IAreasRepository areas)
        {
            _ｗeather = ｗeather;
            _areas = areas;

            foreach (var area in _areas.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }
        }

        public string _areaIdText = string.Empty;
        public string AreaIdText
        {
            get
            {
                return _areaIdText;
            }
            set
            {
                SetProperty(ref _areaIdText, value);
            }
        }

        public string _dataDateText = string.Empty;
        public string DataDateText
        {
            get
            {
                return _dataDateText;
            }
            set
            {
                SetProperty(ref _dataDateText, value);
            }
        }

        public string _conditionText = string.Empty;
        public string ConditionText
        {
            get
            {
                return _conditionText;
            }
            set
            {
                SetProperty(ref _conditionText, value);

            }
        }

        public string _temperatureText = string.Empty;
        public string TemperatureText
        {
            get
            {
                return _temperatureText;
            }
            set
            {
                SetProperty(ref _temperatureText, value);
            }
        }

        public BindingList<AreaEntity> Areas { get; set; }
            = new BindingList<AreaEntity>();

        public void Search()
        {
            var entity = _ｗeather.GetLatest(Convert.ToInt32(AreaIdText));
            if (entity != null)
            {
                DataDateText = entity.DataDate.ToString();
                ConditionText = entity.Condition.DisplayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }
        }

    }
}
