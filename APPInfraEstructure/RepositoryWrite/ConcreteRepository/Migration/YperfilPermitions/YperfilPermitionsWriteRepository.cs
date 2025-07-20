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

namespace Input.Repository.YperfilPermitions
{
    public class YperfilPermitionsWriteRepository : IYperfilPermitionsWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IYperfilPermitionsQueryWrite _query; 

        public YperfilPermitionsWriteRepository(IUnitOfWork unitOfWork,IYperfilPermitionsQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IYperfilPermitionsEntity YperfilPermitions)
        {
            var query = _query.InserirYperfilPermitionsQuery(YperfilPermitions);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYperfilPermitionsEntity YperfilPermitions)
        {
            var query = _query.UpdateYperfilPermitionsQuery(YperfilPermitions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYperfilPermitionsEntity YperfilPermitions)
        {
            var query = _query.DeleteYperfilPermitionsQuery(YperfilPermitions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdatePerfilId(IYperfilPermitionsEntity entity)
        {
            var query = _query.UpdatePerfilId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdatePermitionsId(IYperfilPermitionsEntity entity)
        {
            var query = _query.UpdatePermitionsId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration