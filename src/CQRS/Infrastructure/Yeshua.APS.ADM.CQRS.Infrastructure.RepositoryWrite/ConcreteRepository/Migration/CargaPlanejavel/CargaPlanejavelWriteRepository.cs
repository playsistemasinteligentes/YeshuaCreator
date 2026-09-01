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

namespace Input.Repository.CargaPlanejavel
{
    public partial class CargaPlanejavelWriteRepository : ICargaPlanejavelWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ICargaPlanejavelQueryWrite _query; 

        public CargaPlanejavelWriteRepository(IUnitOfWork unitOfWork,ICargaPlanejavelQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ICargaPlanejavelEntity CargaPlanejavel)
        {
            var query = _query.InserirCargaPlanejavelQuery(CargaPlanejavel);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(ICargaPlanejavelEntity CargaPlanejavel)
        {
            var query = _query.UpdateCargaPlanejavelQuery(CargaPlanejavel);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ICargaPlanejavelEntity CargaPlanejavel)
        {
            var query = _query.DeleteCargaPlanejavelQuery(CargaPlanejavel);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(string cargaid, string value)
        {
            var query = _query.UpdateStatus(cargaid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTransportadoraId(string cargaid, string value)
        {
            var query = _query.UpdateTransportadoraId(cargaid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVeiculoId(string cargaid, string value)
        {
            var query = _query.UpdateVeiculoId(cargaid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTipoVeiculoId(string cargaid, int value)
        {
            var query = _query.UpdateTipoVeiculoId(cargaid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePesoTeorico(string cargaid, Decimal value)
        {
            var query = _query.UpdatePesoTeorico(cargaid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVolumeTeorico(string cargaid, Decimal value)
        {
            var query = _query.UpdateVolumeTeorico(cargaid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateInicioJanelaEmbarque(string cargaid, DateTime value)
        {
            var query = _query.UpdateInicioJanelaEmbarque(cargaid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFimJanelaEmbarque(string cargaid, DateTime value)
        {
            var query = _query.UpdateFimJanelaEmbarque(cargaid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmbarqueAlvo(string cargaid, DateTime value)
        {
            var query = _query.UpdateEmbarqueAlvo(cargaid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateQuantidadePedidos(string cargaid, int value)
        {
            var query = _query.UpdateQuantidadePedidos(cargaid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAlertasResumo(string cargaid, string value)
        {
            var query = _query.UpdateAlertasResumo(cargaid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration