using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using Dapper;
using DBEntity;

namespace DBContext
{
    public class EcografiaRepository : BaseRepository, IEcografiaRepository
    {
        public List<EntityEcografia> GetEcografia()
        {
            var returnEntity = new List<EntityEcografia>();
            using (var db = GetSqlConnection())
            {
                const string sql = @"usp_Paciente_Ecografia";


                returnEntity = db.Query<EntityEcografia>(sql,
                    commandType: CommandType.StoredProcedure).ToList();
            }
            return returnEntity;
        }

        public EntityBaseResponse Insert(EntityEcografia ecografia)
        {
            throw new NotImplementedException();
        }

        /*public List<EntityEcografia> GetEcografias()
        {
           
        }*/
        /*
        public EntityBaseResponse Insert(EntityEcografia ecografia)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_Ecografia_Inserta";

                    var p = new DynamicParameters();
                    p.Add(name: "@idEcografia", dbType: DbType.Int32, ecografia: ParameterEcografia.Output);
                    p.Add(name: "@idPaciente", dbType: DbType.Int32, paciente: ParameterPaciente.Output);
                    p.Add(name: "@detalleEcografia", value: detalleEcografia.detalle, dbType: DbType.String, direction: ParameterEcografia.Input);
                    p.Add(name: "@tituloEcografia", value: tituloEcografia.titulo, dbType: DbType.String, direction: ParameterEcografia.Input);
                    p.Add(name: "@imagen", value: ecografia.imagen, dbType: DbType.String, direction: ParameterEcografia.Input);

                    db.Query<EntityEcografia>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    int idEcografia = p.Get<int>("@idEcografia");

                    if (idEcografia > 0)
                    {
                        response.isSuccess = true;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = new
                        {
                            id = idEcografia,
                            nombre = tituloEcografia.titulo
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
        }*/
    }
}
