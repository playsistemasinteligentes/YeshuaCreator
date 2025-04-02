using Dapper;
using Dominio.Entitys.Y_Perfil;
using Input.Querys.Y_Perfil;
using Repositorio.Inputs.Repositorio.Y_Perfil;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Y_Perfil
{
    public class Y_PerfilWriteRepository : IY_PerfilWriteRepository
    {
        private readonly IDbConnection _Connection;

        public Y_PerfilWriteRepository(SqlFactory factory)
        {
            _Connection = factory.SqlConnection();
        }

        public void Insert(Y_PerfilEntity Y_Perfil)
        {
            var query = new Y_PerfilWriteQuery().InserirY_PerfilQuery(Y_Perfil);
        Y_Perfil.Id =  _Connection.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(Y_PerfilEntity Y_Perfil)
        {
            var query = new Y_PerfilWriteQuery().UpdateY_PerfilQuery(Y_Perfil);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }
        public void Delete(Y_PerfilEntity Y_Perfil)
        {
            var query = new Y_PerfilWriteQuery().DeleteY_PerfilQuery(Y_Perfil);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration