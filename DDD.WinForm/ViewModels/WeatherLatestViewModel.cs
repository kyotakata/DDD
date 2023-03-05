using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
using DDD.Infrastructure.SQLite;
using System;
using System.ComponentModel;

namespace DDD.WinForm.ViewModels
{
    public class WeatherLatestViewModel : INotifyPropertyChanged
    {
        private IＷeatherRepository _ｗeather;

        /// <summary>
        /// コンストラクタ(本番コード用)
        /// </summary>
        public WeatherLatestViewModel()
            : this(new WeatherSQLite())
        {
        }

        /// <summary>
        /// コンストラクタ(テストコード用でもある)
        /// </summary>
        /// <param name="ｗeather">テストコードの時直接引数指定</param>
        public WeatherLatestViewModel(IＷeatherRepository ｗeather)
        {
            _ｗeather = ｗeather;
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
                if (_areaIdText == value) // 値が同じ場合はなにもしない
                    return;

                _areaIdText = value;
                OnPropertyChanged(nameof(AreaIdText));
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
                if (_dataDateText == value) // 値が同じ場合はなにもしない
                    return;

                _dataDateText = value;
                OnPropertyChanged(nameof(DataDateText));
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
                if (_conditionText == value) // 値が同じ場合はなにもしない
                    return;

                _conditionText = value;
                OnPropertyChanged(nameof(ConditionText));

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
                if (_temperatureText == value) // 値が同じ場合はなにもしない
                    return;

                _temperatureText = value;
                OnPropertyChanged(nameof(TemperatureText));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Search()
        {
            var entity = _ｗeather.GetLatest(Convert.ToInt32(AreaIdText));
            if (entity != null)
            {
                DataDateText = entity.DataDate.ToString();
                ConditionText = entity.Condition.DisplayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }

            //OnPropertyChanged("");    // propertyNameを空文字にすると全てのプロパティに適用される
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }

    }
}
