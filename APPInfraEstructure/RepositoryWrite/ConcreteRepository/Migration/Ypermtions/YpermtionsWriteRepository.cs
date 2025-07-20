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

namespace Input.Repository.Ypermtions
{
    public class YpermtionsWriteRepository : IYpermtionsWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IYpermtionsQueryWrite _query; 

        public YpermtionsWriteRepository(IUnitOfWork unitOfWork,IYpermtionsQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IYpermtionsEntity Ypermtions)
        {
            var query = _query.InserirYpermtionsQuery(Ypermtions);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYpermtionsEntity Ypermtions)
        {
            var query = _query.UpdateYpermtionsQuery(Ypermtions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYpermtionsEntity Ypermtions)
        {
            var query = _query.DeleteYpermtionsQuery(Ypermtions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDescription(IYpermtionsEntity entity)
        {
            var query = _query.UpdateDescription(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration