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
            SelectedCondition = Condition.Sunny.Value;
            TemperatureText = string.Empty;

            _weather = weather;
            _areasRepository = areas;

            foreach (var area in _areasRepository.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }

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
            throw new NotImplementedException();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            throw new NotImplementedException();
        }



        // 基本的にViewModelのプロパティの型はコントロールのバインディングする型と合わせる
        public object SelectedAreaId { get; set; }    // ConboBoxのValueプロパティをデータバインドするのでobject型
        public DateTime DataDateValue { get; set; }
        public object SelectedCondition { get; set; }    // ConboBoxのValueプロパティをデータバインドするのでobject型
        public string TemperatureText { get; set; }    // TextBoxのTextプロパティをデータバインドするのでstring型

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

        public void Save()
        {
            Guard.IsNull(SelectedAreaId, "エリアを選択してください");
            var temperature
                = Guard.IsFloat(TemperatureText, "温度の入力に誤りがあります");

            var entity = new WeatherEntity(
                Convert.ToInt32(SelectedAreaId),
                DataDateValue,
                Convert.ToInt32(SelectedCondition),
                temperature
                );

            _weather.Save(entity);
        }

    }
}
