using DDD.WinForm.Common;

namespace DDD.Domain.ValueObjects
{
    public sealed class Temperature : ValueObject<Temperature>
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
                return CommonFunc.RoundString(Value, 2);
            }

        }

        public string DisplayValueWithUnit
        {
            get
            {
                return CommonFunc.RoundString(Value, 2) + UnitName;
            }

        }

        public string DisplayValueWithUnitSpace
        {
            get
            {
                return CommonFunc.RoundString(Value, 2) +" "+ UnitName;
            }

        }

        protected override bool EqualsCore(Temperature other)
        {
            return Value == other.Value;
        }
    }
}
