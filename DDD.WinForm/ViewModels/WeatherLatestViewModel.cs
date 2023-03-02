using DDD.Domain.Repositories;
using DDD.WinForm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var dt = _ｗeather.GetLatest(Convert.ToInt32(AreaIdText));
            if (dt.Rows.Count > 0)
            {
                DataDateText = dt.Rows[0]["DataDate"].ToString();
                ConditionText = dt.Rows[0]["Condition"].ToString();
                TemperatureText = CommonFunc.RoundString(Convert.ToSingle(dt.Rows[0]["Temperature"]),
                    CommonConst.TemperatureDecimalPoint) + " "
                    + CommonConst.TemperatureUnitName;
            }

        }
    }
}
