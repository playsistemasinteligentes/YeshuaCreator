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

namespace Input.Repository.CTeRomaneioConsolidado
{
    public partial class CTeRomaneioConsolidadoWriteRepository : ICTeRomaneioConsolidadoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ICTeRomaneioConsolidadoQueryWrite _query; 

        public CTeRomaneioConsolidadoWriteRepository(IUnitOfWork unitOfWork,ICTeRomaneioConsolidadoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ICTeRomaneioConsolidadoEntity CTeRomaneioConsolidado)
        {
            var query = _query.InserirCTeRomaneioConsolidadoQuery(CTeRomaneioConsolidado);
        CTeRomaneioConsolidado.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ICTeRomaneioConsolidadoEntity CTeRomaneioConsolidado)
        {
            var query = _query.UpdateCTeRomaneioConsolidadoQuery(CTeRomaneioConsolidado);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ICTeRomaneioConsolidadoEntity CTeRomaneioConsolidado)
        {
            var query = _query.DeleteCTeRomaneioConsolidadoQuery(CTeRomaneioConsolidado);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEntradaOficialId(int id, int value)
        {
            var query = _query.UpdateEntradaOficialId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCorrelationId(int id, string value)
        {
            var query = _query.UpdateCorrelationId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRomaneioId(int id, string value)
        {
            var query = _query.UpdateRomaneioId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCargaId(int id, string value)
        {
            var query = _query.UpdateCargaId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateConsolidadoEmUtc(int id, DateTime value)
        {
            var query = _query.UpdateConsolidadoEmUtc(id, value);
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
        public void UpdateRotaSnapshotJson(int id, string value)
        {
            var query = _query.UpdateRotaSnapshotJson(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCargaSnapshotJson(int id, string value)
        {
            var query = _query.UpdateCargaSnapshotJson(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePreferenciasFiscaisJson(int id, string value)
        {
            var query = _query.UpdatePreferenciasFiscaisJson(id, value);
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