using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityEcografia
    {
        public int idEcografia{ get; set; }
        public int idPaciente { get; set; }
        public string detalleEcografia { get; set; }
        public string tituloEcografia { get; set; }
        public string imagen { get; set; }
    }
}
