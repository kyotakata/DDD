using DDD.Domain.ValueObjects;
using System;

namespace DDD.WinForm.ViewModels
{
    public class WeatherSaveViewModel : ViewModelBase
    {
        public WeatherSaveViewModel()
        {
            DataDateValue = GetDateTime();
            SelectedCondition = Condition.Sunny.Value;
            TemperatureText = string.Empty;
        }

        // 基本的にViewModelのプロパティの型はコントロールのバインディングする型と合わせる
        public object SelectedAreaId { get; set; }    // ConboBoxのValueプロパティをデータバインドするのでobject型
        public DateTime DataDateValue { get; set; }
        public object SelectedCondition { get; set; }    // ConboBoxのValueプロパティをデータバインドするのでobject型
        public string TemperatureText { get; set; }    // TextBoxのTextプロパティをデータバインドするのでstring型

    }
}
