using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.APIBusiness.DBEntity.Model
{
    public class EntityListHistorial
    {
        public string NumExpediente { get; set; }
        public string Paciente { get; set; }
        public string NumDocumento { get; set; }
        public int Edad { get; set; }
        public string Radiologo { get; set; }
        public string Informe { get; set; }
    }
}
