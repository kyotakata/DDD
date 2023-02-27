using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WinForm.Common
{
    public static class CommonConst
    {
        // constは無条件にstaticメンバ扱いとなるので、明示的にstatic修飾子を指定する必要がない。
        public const int TemperatureDecimalPoint = 2;
        public const string TemperatureUnitName = "℃";
        public const string ConnectionString = @"Data Source=C:\Users\kyota\source\repos\DDD\DDD.db;Version=3;";

    }
}
