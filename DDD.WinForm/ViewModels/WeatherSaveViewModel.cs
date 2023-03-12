using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using DDD.Domain.Helpers;
using DDD.Domain.ValueObjects;
using System;
using System.ComponentModel;

namespace DDD.WinForm.ViewModels
{
    public class WeatherSaveViewModel : ViewModelBase
    {
        private IAreasRepository _areas;

        public WeatherSaveViewModel(IAreasRepository areas)
        {
            DataDateValue = GetDateTime();
            SelectedCondition = Condition.Sunny.Value;
            TemperatureText = string.Empty;
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
            Guard.IsFloat(TemperatureText, "温度の入力に誤りがあります");
        }
    }
}
