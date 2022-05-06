using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using Dapper;
using DBEntity;

namespace DBContext
{
    public class DistritoRepository : BaseRepository, IDistritoRepository
    {
        public List<EntityDistrito> GetDistritos()
        {
            var returnEntity = new List<EntityDistrito>();
            using (var db = GetSqlConnection())
            {
                const string sql = @"usp_Listar_Distritos";


                returnEntity = db.Query<EntityDistrito>(sql,
                    commandType: CommandType.StoredProcedure).ToList();
            }
            return returnEntity;
        }
    }
}
