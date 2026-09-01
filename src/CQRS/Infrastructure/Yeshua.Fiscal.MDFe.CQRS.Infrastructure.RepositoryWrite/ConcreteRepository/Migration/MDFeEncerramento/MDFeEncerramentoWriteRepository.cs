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

namespace Input.Repository.MDFeEncerramento
{
    public partial class MDFeEncerramentoWriteRepository : IMDFeEncerramentoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IMDFeEncerramentoQueryWrite _query; 

        public MDFeEncerramentoWriteRepository(IUnitOfWork unitOfWork,IMDFeEncerramentoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IMDFeEncerramentoEntity MDFeEncerramento)
        {
            var query = _query.InserirMDFeEncerramentoQuery(MDFeEncerramento);
        MDFeEncerramento.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IMDFeEncerramentoEntity MDFeEncerramento)
        {
            var query = _query.UpdateMDFeEncerramentoQuery(MDFeEncerramento);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IMDFeEncerramentoEntity MDFeEncerramento)
        {
            var query = _query.DeleteMDFeEncerramentoQuery(MDFeEncerramento);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMDFeId(int id, int value)
        {
            var query = _query.UpdateMDFeId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChaveAcesso(int id, string value)
        {
            var query = _query.UpdateChaveAcesso(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUfCarregamento(int id, string value)
        {
            var query = _query.UpdateUfCarregamento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUfDescarregamento(int id, string value)
        {
            var query = _query.UpdateUfDescarregamento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePlacaVeiculo(int id, string value)
        {
            var query = _query.UpdatePlacaVeiculo(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSolicitadoEm(int id, DateTime value)
        {
            var query = _query.UpdateSolicitadoEm(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAutorizadoEm(int id, DateTime value)
        {
            var query = _query.UpdateAutorizadoEm(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProtocolo(int id, string value)
        {
            var query = _query.UpdateProtocolo(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCodigoRetorno(int id, string value)
        {
            var query = _query.UpdateCodigoRetorno(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMensagemRetorno(int id, string value)
        {
            var query = _query.UpdateMensagemRetorno(id, value);
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