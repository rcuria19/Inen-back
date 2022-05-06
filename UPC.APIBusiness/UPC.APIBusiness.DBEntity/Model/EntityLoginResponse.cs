using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.APIBusiness.DBEntity.Model
{
    public class EntityLoginResponse
    {
        public int idusuario { get; set; }
        public string correo { get; set; }
        public int idPerfil { get; set; }
        public string nombres { get; set; }
        public string documentoidentidad { get; set; }
        public string token { get; set; }
    }
}
