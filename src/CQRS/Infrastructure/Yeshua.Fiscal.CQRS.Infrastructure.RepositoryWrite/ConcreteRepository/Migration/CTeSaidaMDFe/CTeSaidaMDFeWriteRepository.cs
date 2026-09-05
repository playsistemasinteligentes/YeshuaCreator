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

namespace Input.Repository.CTeSaidaMDFe
{
    public partial class CTeSaidaMDFeWriteRepository : ICTeSaidaMDFeWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ICTeSaidaMDFeQueryWrite _query; 

        public CTeSaidaMDFeWriteRepository(IUnitOfWork unitOfWork,ICTeSaidaMDFeQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ICTeSaidaMDFeEntity CTeSaidaMDFe)
        {
            var query = _query.InserirCTeSaidaMDFeQuery(CTeSaidaMDFe);
        CTeSaidaMDFe.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ICTeSaidaMDFeEntity CTeSaidaMDFe)
        {
            var query = _query.UpdateCTeSaidaMDFeQuery(CTeSaidaMDFe);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ICTeSaidaMDFeEntity CTeSaidaMDFe)
        {
            var query = _query.DeleteCTeSaidaMDFeQuery(CTeSaidaMDFe);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCTeTentativaEmissaoId(int id, int value)
        {
            var query = _query.UpdateCTeTentativaEmissaoId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCorrelationId(int id, string value)
        {
            var query = _query.UpdateCorrelationId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChaveAcessoCTe(int id, string value)
        {
            var query = _query.UpdateChaveAcessoCTe(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSnapshotHash(int id, string value)
        {
            var query = _query.UpdateSnapshotHash(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOutboxMessageId(int id, string value)
        {
            var query = _query.UpdateOutboxMessageId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePublicadoEmUtc(int id, DateTime value)
        {
            var query = _query.UpdatePublicadoEmUtc(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUltimoErro(int id, string value)
        {
            var query = _query.UpdateUltimoErro(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(int id, int value)
        {
            var query = _query.UpdateStatus(id, value);
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