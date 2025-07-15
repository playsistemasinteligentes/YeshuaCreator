using Dapper;
using Dominio.Entitys;
using Input.Querys.YperfilPermitions;
using Repositorio.Inputs.Repositorio.YperfilPermitions;
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

        public YperfilPermitionsWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(IYperfilPermitionsEntity YperfilPermitions)
        {
            var query = new YperfilPermitionsWriteQuery().InserirYperfilPermitionsQuery(YperfilPermitions);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYperfilPermitionsEntity YperfilPermitions)
        {
            var query = new YperfilPermitionsWriteQuery().UpdateYperfilPermitionsQuery(YperfilPermitions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYperfilPermitionsEntity YperfilPermitions)
        {
            var query = new YperfilPermitionsWriteQuery().DeleteYperfilPermitionsQuery(YperfilPermitions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdatePerfilId(IYperfilPermitionsEntity entity)
        {
            var query = new YperfilPermitionsWriteQuery().UpdatePerfilId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdatePermitionsId(IYperfilPermitionsEntity entity)
        {
            var query = new YperfilPermitionsWriteQuery().UpdatePermitionsId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration