using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IDistritoRepository
    {
        List<EntityDistrito> GetDistritos();
    }
}
