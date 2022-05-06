using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using Dapper;
using DBEntity;

namespace DBContext
{
    public class TipoDocumentoRepository : BaseRepository, ITipoDocumentoRepository
    {
        public List<EntityTipoDocumento> GetTipoDocumentos()
        {
            var returnEntity = new List<EntityTipoDocumento>();
            using (var db = GetSqlConnection())
            {
                const string sql = @"usp_Listar_Tipos_Documento";


                returnEntity = db.Query<EntityTipoDocumento>(sql,
                    commandType: CommandType.StoredProcedure).ToList();
            }
            return returnEntity;
        }
    }


}
