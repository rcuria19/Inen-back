using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IPacienteRepository
    {
        List<EntityPaciente> GetPacientes();

        EntityBaseResponse Insert(EntityPaciente paciente);
    }
}
