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

namespace Input.Repository.MDFeCondutor
{
    public partial class MDFeCondutorWriteRepository : IMDFeCondutorWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IMDFeCondutorQueryWrite _query; 

        public MDFeCondutorWriteRepository(IUnitOfWork unitOfWork,IMDFeCondutorQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IMDFeCondutorEntity MDFeCondutor)
        {
            var query = _query.InserirMDFeCondutorQuery(MDFeCondutor);
        MDFeCondutor.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IMDFeCondutorEntity MDFeCondutor)
        {
            var query = _query.UpdateMDFeCondutorQuery(MDFeCondutor);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IMDFeCondutorEntity MDFeCondutor)
        {
            var query = _query.DeleteMDFeCondutorQuery(MDFeCondutor);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMDFeSolicitacaoFiscalId(int id, int value)
        {
            var query = _query.UpdateMDFeSolicitacaoFiscalId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNome(int id, string value)
        {
            var query = _query.UpdateNome(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDocumento(int id, string value)
        {
            var query = _query.UpdateDocumento(id, value);
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