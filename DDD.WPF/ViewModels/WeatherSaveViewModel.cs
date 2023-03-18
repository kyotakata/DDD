using DDD.Domain.Entities;
using DDD.Domain.Helpers;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
using DDD.Infrastructure.SQLite;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DDD.WPF.ViewModels
{
	public class WeatherSaveViewModel : ViewModelBase, IDialogAware
	{
        private IＷeatherRepository _weather;
        private IAreasRepository _areasRepository;

        public WeatherSaveViewModel() : this(new WeatherSQLite(), new AreasSQLite())
        {
        }

        public WeatherSaveViewModel(
            IＷeatherRepository weather,
            IAreasRepository areas)
        {
            DataDateValue = GetDateTime();
            SelectedCondition = Condition.Sunny;
            TemperatureText = string.Empty;

            _weather = weather;
            _areasRepository = areas;

            foreach (var area in _areasRepository.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }
            SaveButton = new DelegateCommand(SaveButtonExecute);
        }

        public string Title => "登録画面";

        /// <summary>
        /// 画面閉じられたときのイベントハンドラ
        /// </summary>
        public event Action<IDialogResult> RequestClose;

        /// <summary>
        /// 画面閉じることができるか
        /// </summary>
        /// <returns>trueだと閉じることができる</returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }



        // 基本的にViewModelのプロパティの型はコントロールのバインディングする型と合わせる
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
        public DateTime? DataDateValue { get; set; }

        public Condition _selectedCondition;
        public Condition SelectedCondition
        {
            get
            {
                return _selectedCondition;
            }
            set
            {
                SetProperty(ref _selectedCondition, value);

            }
        }

        private string _temperatureText;

        public string TemperatureText    // TextBoxのTextプロパティをデータバインドするのでstring型
        {
            get { return _temperatureText; }
            set
            {
                SetProperty(ref _temperatureText, value);
            }
        }


        private ObservableCollection<AreaEntity> _areas = new ObservableCollection<AreaEntity>();

        public ObservableCollection<AreaEntity> Areas
        {
            get { return _areas; }
            set
            {
                SetProperty(ref _areas, value);
            }
        }

        private ObservableCollection<Condition> _conditions = new ObservableCollection<Condition>(Condition.ToList());

        public ObservableCollection<Condition> Conditions
        {
            get { return _conditions; }
            set
            {
                SetProperty(ref _conditions, value);
            }
        }

        public string TemperatureUnitName => Temperature.UnitName;

        public DelegateCommand SaveButton { get; }

        private void SaveButtonExecute()
        {
            Guard.IsNull(SelectedArea, "エリアを選択してください");
            Guard.IsNull(DataDateValue, "日時を入力してください");
            var temperature
                = Guard.IsFloat(TemperatureText, "温度の入力に誤りがあります");

            var entity = new WeatherEntity(
                SelectedArea.AreaId,
                DataDateValue.Value,
                SelectedCondition.Value,
                temperature
                );

            _weather.Save(entity);
        }

    }
}
