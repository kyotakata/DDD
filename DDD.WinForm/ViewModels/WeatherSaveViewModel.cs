using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using DDD.Domain.Helpers;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
using System;
using System.ComponentModel;

namespace DDD.WinForm.ViewModels
{
    public class WeatherSaveViewModel : ViewModelBase
    {
        private IＷeatherRepository _weather;
        private IAreasRepository _areas;

        public WeatherSaveViewModel(
            IＷeatherRepository weather,
            IAreasRepository areas)
        {
            DataDateValue = GetDateTime();
            SelectedCondition = Condition.Sunny.Value;
            TemperatureText = string.Empty;

            _weather = weather;
            _areas = areas;

            foreach (var area in _areas.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }

        }

        // 基本的にViewModelのプロパティの型はコントロールのバインディングする型と合わせる
        public object SelectedAreaId { get; set; }    // ConboBoxのValueプロパティをデータバインドするのでobject型
        public DateTime DataDateValue { get; set; }
        public object SelectedCondition { get; set; }    // ConboBoxのValueプロパティをデータバインドするのでobject型
        public string TemperatureText { get; set; }    // TextBoxのTextプロパティをデータバインドするのでstring型
        public BindingList<AreaEntity> Areas { get; set; }
            = new BindingList<AreaEntity>();
        public BindingList<Condition> Conditions { get; set; }
            = new BindingList<Condition>(Condition.ToList());

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
