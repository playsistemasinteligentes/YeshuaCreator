using Dapper;
using Dominio.Entitys;
using IRepository.Write;
using IQuery.Write;
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
       private readonly IYtenantQueryWrite _query; 

        public YtenantWriteRepository(IUnitOfWork unitOfWork,IYtenantQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IYtenantEntity Ytenant)
        {
            var query = _query.InserirYtenantQuery(Ytenant);
        Ytenant.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYtenantEntity Ytenant)
        {
            var query = _query.UpdateYtenantQuery(Ytenant);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYtenantEntity Ytenant)
        {
            var query = _query.DeleteYtenantQuery(Ytenant);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateCnpjCpf(IYtenantEntity entity)
        {
            var query = _query.UpdateCnpjCpf(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateNome(IYtenantEntity entity)
        {
            var query = _query.UpdateNome(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateUserIDAdmin(IYtenantEntity entity)
        {
            var query = _query.UpdateUserIDAdmin(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration