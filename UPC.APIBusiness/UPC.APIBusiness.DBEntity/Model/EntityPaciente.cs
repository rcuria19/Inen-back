using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityPaciente
    {
        public int idPaciente { get; set; }
        public int idTipoDoc { get; set; }
        public string NumeroDoc { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int  idEstadoCivil { get; set; }
        public string Fijo { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Ocupación { get; set; }
        public string Dirección { get; set; }
        public int  idDistrito { get; set; }
        public string imagen { get; set; }
    }
}
