using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WinForm.ViewModels
{
    public class WeatherSaveViewModel : ViewModelBase
    {
        public WeatherSaveViewModel()
        {
            DataDateValue = DateTime.Now;
        }

        // 基本的にViewModelのプロパティの型はコントロールのバインディングする型と合わせる
        public object SelectedAreaId { get; set; }    // ConboBoxのValueプロパティをデータバインドするのでobject型
        public DateTime DataDateValue { get; set; }
        public object SelectedCondition { get; set; }    // ConboBoxのValueプロパティをデータバインドするのでobject型
        public string TemperatureText { get; set; }    // TextBoxのTextプロパティをデータバインドするのでstring型
    }
}
