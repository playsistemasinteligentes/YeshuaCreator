using Dapper;
using Dominio.Entitys;
using Input.Querys.Y_Company;
using Repositorio.Inputs.Repositorio.Y_Company;
using RepositoryInterfaces.Patterns.UnitOfWork;
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
        private readonly IUnitOfWork _UnitOfWork;

        public Y_CompanyWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(Y_CompanyEntity Y_Company)
        {
            var query = new Y_CompanyWriteQuery().InserirY_CompanyQuery(Y_Company);
        Y_Company.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(Y_CompanyEntity Y_Company)
        {
            var query = new Y_CompanyWriteQuery().UpdateY_CompanyQuery(Y_Company);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }
        public void Delete(Y_CompanyEntity Y_Company)
        {
            var query = new Y_CompanyWriteQuery().DeleteY_CompanyQuery(Y_Company);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration