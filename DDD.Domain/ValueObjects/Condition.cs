using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObjects
{
    public sealed class Condition : ValueObject<Condition>
    {
        public Condition(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public string DisplayValue
        {
            get
            {
                if (this.Value == 1)
                    return "晴れ";
                else if (this.Value == 2)
                    return "曇り";
                else if (this.Value == 3)
                    return "雨";

                return "不明";

            }
        }

        protected override bool EqualsCore(Condition other)
        {
            return other.Value == Value;// 自分のValueと比較
        }
    }
}
