using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using Dapper;
using DBEntity;

namespace DBContext
{
    public class PacienteRepository : BaseRepository, IPacienteRepository
    {
        public List<EntityPaciente> GetPacientes()
        {
            var returnEntity = new List<EntityPaciente>();
            using (var db = GetSqlConnection())
            {
                const string sql = @"usp_Paciente_Listar";


                returnEntity = db.Query<EntityPaciente>(sql,
                    commandType: CommandType.StoredProcedure).ToList();
            }
            return returnEntity;
        }

        public EntityBaseResponse Insert(EntityPaciente paciente)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_Paciente_Inserta";

                    var p = new DynamicParameters();
                    p.Add(name: "@idPaciente", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@idTipoDoc", value: paciente.idTipoDoc, dbType: DbType.Int32, direction: ParameterDirection.Input);                  
                    p.Add(name: "@NumeroDoc", value: paciente.NumeroDoc, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Nombres", value: paciente.Nombres, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Apellidos", value: paciente.Apellidos, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@idEstadoCivil", value: paciente.idEstadoCivil, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@Fijo", value: paciente.Fijo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Celular", value: paciente.Celular, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Correo", value: paciente.Correo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@FechaNacimiento", value: paciente.FechaNacimiento, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add(name: "@Ocupación", value: paciente.Ocupación, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Dirección", value: paciente.Dirección, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@idDistrito", value: paciente.idDistrito, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@imagen", value: paciente.imagen, dbType: DbType.String, direction: ParameterDirection.Input);

                    db.Query<EntityPaciente>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    int idPaciente = p.Get<int>("@idPaciente");

                    if (idPaciente > 0)
                    {
                        response.isSuccess = true;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = new
                        {
                            id = idPaciente,
                            nombre = paciente.Nombres
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
