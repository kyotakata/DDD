using DDD.WinForm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObjects
{
    public sealed class Temperature
    {
        // constは無条件にstaticメンバ扱いとなるので、明示的にstatic修飾子を指定する必要がない。
        public const int DecimalPoint = 2;
        public const string UnitName = "℃";

        //private readonly float _value;
        public Temperature(float value)
        {
            //_value= value;
            Value = value;
        }

        //public float Value
        //{
        //    get 
        //    { 
        //        return _value;
        //    }
        //}
        public float Value { get; }
        public string DisplayValue
        {
            get
            {
                return CommonFunc.RoundString(Value, 2) + UnitName;
            }

        }

        public override bool Equals(object obj)
        {
            if (obj is Temperature vo)
            {
                return Value == vo.Value;
            }
            return false;
        }

        public static bool operator ==(Temperature vo1, Temperature vo2)
        {
            return Equals(vo1, vo2);
        }

        public static bool operator !=(Temperature vo1, Temperature vo2)
        {
            return !Equals(vo1, vo2);
        }

    }
}
