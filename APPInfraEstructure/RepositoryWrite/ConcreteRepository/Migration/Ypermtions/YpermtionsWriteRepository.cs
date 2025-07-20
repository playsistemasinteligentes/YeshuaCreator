using Dapper;
using Dominio.Entitys;
using Input.Querys.Ypermtions;
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

namespace Input.Repository.Ypermtions
{
    public class YpermtionsWriteRepository : IYpermtionsWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;

        public YpermtionsWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(IYpermtionsEntity Ypermtions)
        {
            var query = new YpermtionsWriteQuery().InserirYpermtionsQuery(Ypermtions);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYpermtionsEntity Ypermtions)
        {
            var query = new YpermtionsWriteQuery().UpdateYpermtionsQuery(Ypermtions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYpermtionsEntity Ypermtions)
        {
            var query = new YpermtionsWriteQuery().DeleteYpermtionsQuery(Ypermtions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDescription(IYpermtionsEntity entity)
        {
            var query = new YpermtionsWriteQuery().UpdateDescription(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration