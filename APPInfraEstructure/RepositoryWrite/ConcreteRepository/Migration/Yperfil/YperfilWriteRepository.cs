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

namespace Input.Repository.yPerfil
{
    public class yPerfilWriteRepository : IyPerfilWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IyPerfilQueryWrite _query; 

        public yPerfilWriteRepository(IUnitOfWork unitOfWork,IyPerfilQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IyPerfilEntity yPerfil)
        {
            var query = _query.InseriryPerfilQuery(yPerfil);
        yPerfil.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IyPerfilEntity yPerfil)
        {
            var query = _query.UpdateyPerfilQuery(yPerfil);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IyPerfilEntity yPerfil)
        {
            var query = _query.DeleteyPerfilQuery(yPerfil);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDescription(IyPerfilEntity entity)
        {
            var query = _query.UpdateDescription(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(IyPerfilEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(IyPerfilEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(IyPerfilEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(IyPerfilEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration