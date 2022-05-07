using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IEcografiaRepository
    {
        List<EntityEcografia> GetEcografia();

        EntityBaseResponse Insert(EntityEcografia ecografia);
    }
}
