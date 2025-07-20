using Dapper;
using Dominio.Entitys;
using Input.Querys.Ytenant;
using IRepository.Write;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Ytenant
{
    public class YtenantWriteRepository : IYtenantWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;

        public YtenantWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(IYtenantEntity Ytenant)
        {
            var query = new YtenantWriteQuery().InserirYtenantQuery(Ytenant);
        Ytenant.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYtenantEntity Ytenant)
        {
            var query = new YtenantWriteQuery().UpdateYtenantQuery(Ytenant);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYtenantEntity Ytenant)
        {
            var query = new YtenantWriteQuery().DeleteYtenantQuery(Ytenant);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateCnpjCpf(IYtenantEntity entity)
        {
            var query = new YtenantWriteQuery().UpdateCnpjCpf(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateNome(IYtenantEntity entity)
        {
            var query = new YtenantWriteQuery().UpdateNome(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateUserIDAdmin(IYtenantEntity entity)
        {
            var query = new YtenantWriteQuery().UpdateUserIDAdmin(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration