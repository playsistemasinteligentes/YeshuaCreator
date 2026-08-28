// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
// </yeshua>

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

namespace Input.Repository.Auditoria
{
    public partial class AuditoriaWriteRepository : IAuditoriaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IAuditoriaQueryWrite _query; 

        public AuditoriaWriteRepository(IUnitOfWork unitOfWork,IAuditoriaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IAuditoriaEntity Auditoria)
        {
            var query = _query.InserirAuditoriaQuery(Auditoria);
        Auditoria.ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IAuditoriaEntity Auditoria)
        {
            var query = _query.UpdateAuditoriaQuery(Auditoria);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IAuditoriaEntity Auditoria)
        {
            var query = _query.DeleteAuditoriaQuery(Auditoria);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDATA(int id, DateTime value)
        {
            var query = _query.UpdateDATA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUSE_ID(int id, int value)
        {
            var query = _query.UpdateUSE_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROTINA(int id, string value)
        {
            var query = _query.UpdateROTINA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateHISTORICO(int id, string value)
        {
            var query = _query.UpdateHISTORICO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCHAVE(int id, string value)
        {
            var query = _query.UpdateCHAVE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int id, int value)
        {
            var query = _query.UpdateTenantID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int id, bool value)
        {
            var query = _query.UpdateDeleted(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int id, DateTime value)
        {
            var query = _query.UpdateChanged(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int id, int value)
        {
            var query = _query.UpdateUserId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration