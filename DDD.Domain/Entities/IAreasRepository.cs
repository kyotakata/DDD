using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Entities
{
    public interface IAreasRepository
    {
        IReadOnlyList<AreaEntity> GetData();
    }
}
