using Dapper;
using DBContext;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UPC.APIBusiness.DBContext.Interface;
using UPC.APIBusiness.DBEntity.Model;

namespace UPC.APIBusiness.DBContext.Repository
{
    public class HistorialMedicoRepository : BaseRepository, IHistorialMedicoRepository
    {
        public EntityBaseResponse GetHistorial()
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var historial = new List<EntityListHistorial>();
                    const string sql = "ups_ListarHistorial";

                    historial = db.Query<EntityListHistorial>(
                            sql: sql,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (historial.Count > 0)
                    {

                        response.isSuccess = true;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = historial;
                    }
                    else
                    {
                        response.isSuccess = false;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.errorCode = "0001";
                response.errorMessage = ex.Message;
                response.data = null;
            }

            return response;
        }

        public EntityBaseResponse Insert(EntityHistorialMedico historialMedico)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_InsertarHistorialMedico";

                    var p = new DynamicParameters();
                    p.Add(name: "@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@NumExpediente", value: historialMedico.NumExpediente, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Paciente", value: historialMedico.Paciente, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Nacionalidad", value: historialMedico.Nacionalidad, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@TipoDocumento", value: historialMedico.TipoDocumento, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@NumDocumento", value: historialMedico.NumDocumento, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Edad", value: historialMedico.Edad, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@Radiologo", value: historialMedico.Radiologo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@EstadoCivil", value: historialMedico.EstadoCivil, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@Telefono", value: historialMedico.Telefono, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Celular", value: historialMedico.Celular, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Correo", value: historialMedico.Correo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@FechaNacimiento", value: historialMedico.FechaNacimiento, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Ocupacion", value: historialMedico.Ocupacion, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Direccion", value: historialMedico.Direccion, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Distrito", value: historialMedico.Distrito, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@Informe", value: historialMedico.Informe, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Img", value: historialMedico.Img, dbType: DbType.String, direction: ParameterDirection.Input);

                    db.Query<EntityHistorialMedico>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    int idhistorialmedico = p.Get<int>("@Id");

                    if (idhistorialmedico > 0)
                    {
                        response.isSuccess = true;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = new
                        {
                            id = idhistorialmedico,
                            historialMedico = historialMedico.NumExpediente + " " + historialMedico.Paciente + " " + historialMedico.NumDocumento
                        };
                    }
                    else
                    {
                        response.isSuccess = false;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.errorCode = "0001";
                response.errorMessage = ex.Message;
                response.data = null;
            }

            return response;
        }
    }
}
