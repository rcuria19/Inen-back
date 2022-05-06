using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using Dapper;
using DBEntity;

namespace DBContext
{
    public class EstadoCivilRepository : BaseRepository, IEstadoCivilRepository
    {
        public List<EntityEstadoCivil> GetEstadoCivil()
        {
            var returnEntity = new List<EntityEstadoCivil>();
            using (var db = GetSqlConnection())
            {
                const string sql = @"usp_Listar_Estado_Civil";


                returnEntity = db.Query<EntityEstadoCivil>(sql,
                    commandType: CommandType.StoredProcedure).ToList();
            }
            return returnEntity;
        }
    }
}
