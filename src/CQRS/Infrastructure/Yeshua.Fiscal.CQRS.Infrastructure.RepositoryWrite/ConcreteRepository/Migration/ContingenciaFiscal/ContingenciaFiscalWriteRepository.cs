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

namespace Input.Repository.ContingenciaFiscal
{
    public partial class ContingenciaFiscalWriteRepository : IContingenciaFiscalWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IContingenciaFiscalQueryWrite _query; 

        public ContingenciaFiscalWriteRepository(IUnitOfWork unitOfWork,IContingenciaFiscalQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IContingenciaFiscalEntity ContingenciaFiscal)
        {
            var query = _query.InserirContingenciaFiscalQuery(ContingenciaFiscal);
        ContingenciaFiscal.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IContingenciaFiscalEntity ContingenciaFiscal)
        {
            var query = _query.UpdateContingenciaFiscalQuery(ContingenciaFiscal);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IContingenciaFiscalEntity ContingenciaFiscal)
        {
            var query = _query.DeleteContingenciaFiscalQuery(ContingenciaFiscal);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmissaoFiscalTransporteId(int id, int value)
        {
            var query = _query.UpdateEmissaoFiscalTransporteId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEntradaFiscalContingenciaId(int id, int value)
        {
            var query = _query.UpdateEntradaFiscalContingenciaId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCorrelationId(int id, string value)
        {
            var query = _query.UpdateCorrelationId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCargaId(int id, string value)
        {
            var query = _query.UpdateCargaId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTipoSolicitante(int id, int value)
        {
            var query = _query.UpdateTipoSolicitante(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAmbiente(int id, int value)
        {
            var query = _query.UpdateAmbiente(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmitenteDocumento(int id, string value)
        {
            var query = _query.UpdateEmitenteDocumento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTomadorDocumento(int id, string value)
        {
            var query = _query.UpdateTomadorDocumento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTransportadorDocumento(int id, string value)
        {
            var query = _query.UpdateTransportadorDocumento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateQuantidadeDocumentos(int id, int value)
        {
            var query = _query.UpdateQuantidadeDocumentos(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateQuantidadeCTe(int id, int value)
        {
            var query = _query.UpdateQuantidadeCTe(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateQuantidadeMDFe(int id, int value)
        {
            var query = _query.UpdateQuantidadeMDFe(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateValorCarga(int id, Decimal value)
        {
            var query = _query.UpdateValorCarga(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePesoBruto(int id, Decimal value)
        {
            var query = _query.UpdatePesoBruto(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUltimaMensagem(int id, string value)
        {
            var query = _query.UpdateUltimaMensagem(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCriadoEmUtc(int id, DateTime value)
        {
            var query = _query.UpdateCriadoEmUtc(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAtualizadoEmUtc(int id, DateTime value)
        {
            var query = _query.UpdateAtualizadoEmUtc(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateConcluidoEmUtc(int id, DateTime value)
        {
            var query = _query.UpdateConcluidoEmUtc(id, value);
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