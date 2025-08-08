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

namespace Input.Repository.yPerfilGrant
{
    public class yPerfilGrantWriteRepository : IyPerfilGrantWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IyPerfilGrantQueryWrite _query; 

        public yPerfilGrantWriteRepository(IUnitOfWork unitOfWork,IyPerfilGrantQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IyPerfilGrantEntity yPerfilGrant)
        {
            var query = _query.InseriryPerfilGrantQuery(yPerfilGrant);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IyPerfilGrantEntity yPerfilGrant)
        {
            var query = _query.UpdateyPerfilGrantQuery(yPerfilGrant);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IyPerfilGrantEntity yPerfilGrant)
        {
            var query = _query.DeleteyPerfilGrantQuery(yPerfilGrant);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdatePerfilId(IyPerfilGrantEntity entity)
        {
            var query = _query.UpdatePerfilId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateGrantId(IyPerfilGrantEntity entity)
        {
            var query = _query.UpdateGrantId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateGrant(IyPerfilGrantEntity entity)
        {
            var query = _query.UpdateGrant(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateCreate(IyPerfilGrantEntity entity)
        {
            var query = _query.UpdateCreate(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateRead(IyPerfilGrantEntity entity)
        {
            var query = _query.UpdateRead(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateUpdate(IyPerfilGrantEntity entity)
        {
            var query = _query.UpdateUpdate(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDelete(IyPerfilGrantEntity entity)
        {
            var query = _query.UpdateDelete(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateValidUntil(IyPerfilGrantEntity entity)
        {
            var query = _query.UpdateValidUntil(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTenantID(IyPerfilGrantEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDeleted(IyPerfilGrantEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateChanged(IyPerfilGrantEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateUserId(IyPerfilGrantEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration