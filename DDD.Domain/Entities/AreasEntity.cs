using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Entities
{
    public sealed class AreasEntity
    {
        public AreasEntity(int areaId, string areaName)
        {
            AreaId = areaId;
            AreaName = areaName;
        }

        public int AreaId { get; }
        public string AreaName { get; }
    }
}
