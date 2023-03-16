using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DDD.WPF.ViewModels
{
    public class WeatherLatestViewModel : ViewModelBase
    {
        private IＷeatherRepository _ｗeather;
        private IAreasRepository _areasRepository;

        /// <summary>
        /// コンストラクタ(本番コード用)
        /// </summary>
        public WeatherLatestViewModel()
            : this(new WeatherSQLite(), new AreasSQLite())
        {
        }

        /// <summary>
        /// コンストラクタ(テストコード用でもある)
        /// </summary>
        /// <param name="ｗeather">テストコードの時直接引数指定</param>
        public WeatherLatestViewModel(IＷeatherRepository ｗeather, IAreasRepository areas)
        {
            _ｗeather = ｗeather;
            _areasRepository = areas;

            foreach (var area in _areasRepository.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }

            LatestButton = new DelegateCommand(LatestButtonExecute);
        }

        public AreaEntity _selectedArea;
        public AreaEntity SelectedArea
        {
            get
            {
                return _selectedArea;
            }
            set
            {
                SetProperty(ref _selectedArea, value);
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

        public DelegateCommand LatestButton { get; }

        private ObservableCollection<AreaEntity> _areas = new ObservableCollection<AreaEntity>();

        public ObservableCollection<AreaEntity> Areas 
        {
            get { return _areas; }
            set
            {
                SetProperty(ref _areas, value);
            }
        }

        private void LatestButtonExecute()
        {
            if(SelectedArea == null)
            {
                throw new InputException("地域を選択してください");
            }

            var entity = _ｗeather.GetLatest(SelectedArea.AreaId);
            if (entity == null)
            {
                DataDateText = string.Empty;
                ConditionText = string.Empty;
                TemperatureText = string.Empty;
            }
            else
            {
                DataDateText = entity.DataDate.ToString();
                ConditionText = entity.Condition.DisplayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }
        }
    }
}
