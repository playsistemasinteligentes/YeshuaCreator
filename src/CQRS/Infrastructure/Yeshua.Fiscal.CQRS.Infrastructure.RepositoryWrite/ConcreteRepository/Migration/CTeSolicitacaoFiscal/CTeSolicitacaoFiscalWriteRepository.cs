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

namespace Input.Repository.CTeSolicitacaoFiscal
{
    public partial class CTeSolicitacaoFiscalWriteRepository : ICTeSolicitacaoFiscalWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ICTeSolicitacaoFiscalQueryWrite _query; 

        public CTeSolicitacaoFiscalWriteRepository(IUnitOfWork unitOfWork,ICTeSolicitacaoFiscalQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ICTeSolicitacaoFiscalEntity CTeSolicitacaoFiscal)
        {
            var query = _query.InserirCTeSolicitacaoFiscalQuery(CTeSolicitacaoFiscal);
        CTeSolicitacaoFiscal.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ICTeSolicitacaoFiscalEntity CTeSolicitacaoFiscal)
        {
            var query = _query.UpdateCTeSolicitacaoFiscalQuery(CTeSolicitacaoFiscal);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ICTeSolicitacaoFiscalEntity CTeSolicitacaoFiscal)
        {
            var query = _query.DeleteCTeSolicitacaoFiscalQuery(CTeSolicitacaoFiscal);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEntradaOficialId(int id, int value)
        {
            var query = _query.UpdateEntradaOficialId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRomaneioConsolidadoId(int id, int value)
        {
            var query = _query.UpdateRomaneioConsolidadoId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCorrelationId(int id, string value)
        {
            var query = _query.UpdateCorrelationId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAmbiente(int id, int value)
        {
            var query = _query.UpdateAmbiente(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUFEmitente(int id, string value)
        {
            var query = _query.UpdateUFEmitente(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmitenteDocumento(int id, string value)
        {
            var query = _query.UpdateEmitenteDocumento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProdutoFiscal(int id, int value)
        {
            var query = _query.UpdateProdutoFiscal(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTipoCTe(int id, int value)
        {
            var query = _query.UpdateTipoCTe(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTipoServico(int id, int value)
        {
            var query = _query.UpdateTipoServico(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateModal(int id, int value)
        {
            var query = _query.UpdateModal(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGlobalizado(int id, int value)
        {
            var query = _query.UpdateGlobalizado(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUFInicio(int id, string value)
        {
            var query = _query.UpdateUFInicio(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUFFim(int id, string value)
        {
            var query = _query.UpdateUFFim(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMunicipioInicioCodigoIbge(int id, string value)
        {
            var query = _query.UpdateMunicipioInicioCodigoIbge(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMunicipioFimCodigoIbge(int id, string value)
        {
            var query = _query.UpdateMunicipioFimCodigoIbge(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateValorServico(int id, Decimal value)
        {
            var query = _query.UpdateValorServico(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateValorCarga(int id, Decimal value)
        {
            var query = _query.UpdateValorCarga(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePreferenciasManifestoJson(int id, string value)
        {
            var query = _query.UpdatePreferenciasManifestoJson(id, value);
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