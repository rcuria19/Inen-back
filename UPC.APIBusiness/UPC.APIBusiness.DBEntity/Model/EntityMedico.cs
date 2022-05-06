using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityMedico
    {
        public string idCentroMedicoPaciente { get; set; }
        public int idSede { get; set; }
        public string nombreCompleto { get; set; }
        public string apellidos { get; set; }
        public string DNI { get; set; }
        public string correo { get; set; }
        public DateTime FifechaNacimiento { get; set; }
        public int idDistrito { get; set; }
        public string formacionAcademica { get; set; }
        public string numeroColegiatura { get; set; }
        public int idEspecialidad { get; set; }
        public int idUsario { get; set; }
        public int celular { get; set; }
        public int idSexo { get; set; }
    }
}
