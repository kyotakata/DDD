using DDD.Domain.Helpers;

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
                return Value.RoundString(DecimalPoint);
            }

        }

        public string DisplayValueWithUnit
        {
            get
            {
                return Value.RoundString(DecimalPoint) + UnitName;
            }

        }

        public string DisplayValueWithUnitSpace
        {
            get
            {
                return Value.RoundString(DecimalPoint) +" "+ UnitName;
            }

        }

        protected override bool EqualsCore(Temperature other)
        {
            return Value == other.Value;
        }
    }
}
