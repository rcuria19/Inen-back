using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UPC.APIBusiness.DBEntity.Model;

namespace DBContext
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public List<EntityUser> GetUsers()
        {
            var returnEntity = new List<EntityUser>();
            using (var db = GetSqlConnection())
            {
                const string sql = @"usp_ObtenerDepartamentos";


                returnEntity = db.Query<EntityUser>(sql,
                    commandType: CommandType.StoredProcedure).ToList();
            }
            return returnEntity;
        }

        public EntityBaseResponse Login(EntityLogin login)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var loginresponse = new EntityLoginResponse();
                    const string sql = "usp_userlogin";

                    var p = new DynamicParameters();
                    p.Add(name: "@LOGIN", value: login.correo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@PASSWORD", value: login.clave, dbType: DbType.String, direction: ParameterDirection.Input);

                    loginresponse = db.Query<EntityLoginResponse>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    if (loginresponse != null)
                    {
                        response.isSuccess = true;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = loginresponse;
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
