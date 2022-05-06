using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.APIBusiness.DBEntity.Model
{
    public class EntityHistorialMedico
    {
        public int Id { get; set; }
        public string NumExpediente { get; set; }
        public string Paciente { get; set; }
        public string Nacionalidad { get; set; }
        public int TipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public int Edad { get; set; }
        public string Radiologo { get; set; }
        public int EstadoCivil { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string FechaNacimiento { get; set; }
        public string Ocupacion { get; set; }
        public string Direccion { get; set; }
        public int Distrito { get; set; }
        public string Informe { get; set; }
        public string Img { get; set; }
    }
}
