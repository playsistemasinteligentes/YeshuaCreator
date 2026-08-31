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

namespace Input.Repository.CTeParticipanteSnapshot
{
    public partial class CTeParticipanteSnapshotWriteRepository : ICTeParticipanteSnapshotWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ICTeParticipanteSnapshotQueryWrite _query; 

        public CTeParticipanteSnapshotWriteRepository(IUnitOfWork unitOfWork,ICTeParticipanteSnapshotQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ICTeParticipanteSnapshotEntity CTeParticipanteSnapshot)
        {
            var query = _query.InserirCTeParticipanteSnapshotQuery(CTeParticipanteSnapshot);
        CTeParticipanteSnapshot.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ICTeParticipanteSnapshotEntity CTeParticipanteSnapshot)
        {
            var query = _query.UpdateCTeParticipanteSnapshotQuery(CTeParticipanteSnapshot);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ICTeParticipanteSnapshotEntity CTeParticipanteSnapshot)
        {
            var query = _query.DeleteCTeParticipanteSnapshotQuery(CTeParticipanteSnapshot);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCTeSolicitacaoFiscalId(int id, int value)
        {
            var query = _query.UpdateCTeSolicitacaoFiscalId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePapel(int id, string value)
        {
            var query = _query.UpdatePapel(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDocumento(int id, string value)
        {
            var query = _query.UpdateDocumento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNome(int id, string value)
        {
            var query = _query.UpdateNome(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateInscricaoEstadual(int id, string value)
        {
            var query = _query.UpdateInscricaoEstadual(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUF(int id, string value)
        {
            var query = _query.UpdateUF(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMunicipioCodigoIbge(int id, string value)
        {
            var query = _query.UpdateMunicipioCodigoIbge(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEnderecoJson(int id, string value)
        {
            var query = _query.UpdateEnderecoJson(id, value);
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