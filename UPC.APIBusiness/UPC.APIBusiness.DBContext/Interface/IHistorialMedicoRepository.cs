using System;
using System.Collections.Generic;
using System.Text;
using UPC.APIBusiness.DBEntity.Model;
using DBEntity;

namespace UPC.APIBusiness.DBContext.Interface
{
    public interface IHistorialMedicoRepository
    {
        EntityBaseResponse Insert(EntityHistorialMedico historialMedico);
        EntityBaseResponse GetHistorial();
    }
}
