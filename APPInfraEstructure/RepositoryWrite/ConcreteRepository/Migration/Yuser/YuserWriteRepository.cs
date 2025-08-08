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

namespace Input.Repository.yUser
{
    public class yUserWriteRepository : IyUserWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IyUserQueryWrite _query; 

        public yUserWriteRepository(IUnitOfWork unitOfWork,IyUserQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IyUserEntity yUser)
        {
            var query = _query.InseriryUserQuery(yUser);
        yUser.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IyUserEntity yUser)
        {
            var query = _query.UpdateyUserQuery(yUser);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IyUserEntity yUser)
        {
            var query = _query.DeleteyUserQuery(yUser);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateNome(IyUserEntity entity)
        {
            var query = _query.UpdateNome(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateEmail(IyUserEntity entity)
        {
            var query = _query.UpdateEmail(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateSenha(IyUserEntity entity)
        {
            var query = _query.UpdateSenha(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTenantID(IyUserEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDeleted(IyUserEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateChanged(IyUserEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration