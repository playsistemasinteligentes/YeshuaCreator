using Dapper;
using Dominio.Entitys.Y_Company;
using Input.Querys.Y_Company;
using Repositorio.Inputs.Repositorio.Y_Company;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Y_Company
{
    public class Y_CompanyWriteRepository : IY_CompanyWriteRepository
    {
        private readonly IDbConnection _Connection;

        public Y_CompanyWriteRepository(SqlFactory factory)
        {
            _Connection = factory.SqlConnection();
        }

        public void Insert(Y_CompanyEntity Y_Company)
        {
            var query = new Y_CompanyWriteQuery().InserirY_CompanyQuery(Y_Company);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }

        public void Update(Y_CompanyEntity Y_Company)
        {
            var query = new Y_CompanyWriteQuery().UpdateY_CompanyQuery(Y_Company);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }
        public void Delete(Y_CompanyEntity Y_Company)
        {
            var query = new Y_CompanyWriteQuery().DeleteY_CompanyQuery(Y_Company);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration