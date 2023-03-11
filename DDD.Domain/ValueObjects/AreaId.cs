using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObjects
{
    public sealed class AreaId : ValueObject<AreaId>
    {
        public AreaId(int value)
        {
            Value = value;
        }


        protected override bool EqualsCore(AreaId other)
        {
            return Value == other.Value;
        }

        public int Value { get; }

        public string DisplayValue => Value.ToString().PadLeft(4, '0');
    }
}
