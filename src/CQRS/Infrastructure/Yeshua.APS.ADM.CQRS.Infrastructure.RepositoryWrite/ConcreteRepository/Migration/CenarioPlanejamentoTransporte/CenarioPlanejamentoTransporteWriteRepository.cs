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

namespace Input.Repository.CenarioPlanejamentoTransporte
{
    public partial class CenarioPlanejamentoTransporteWriteRepository : ICenarioPlanejamentoTransporteWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ICenarioPlanejamentoTransporteQueryWrite _query; 

        public CenarioPlanejamentoTransporteWriteRepository(IUnitOfWork unitOfWork,ICenarioPlanejamentoTransporteQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ICenarioPlanejamentoTransporteEntity CenarioPlanejamentoTransporte)
        {
            var query = _query.InserirCenarioPlanejamentoTransporteQuery(CenarioPlanejamentoTransporte);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(ICenarioPlanejamentoTransporteEntity CenarioPlanejamentoTransporte)
        {
            var query = _query.UpdateCenarioPlanejamentoTransporteQuery(CenarioPlanejamentoTransporte);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ICenarioPlanejamentoTransporteEntity CenarioPlanejamentoTransporte)
        {
            var query = _query.DeleteCenarioPlanejamentoTransporteQuery(CenarioPlanejamentoTransporte);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDescricao(string cenarioid, string value)
        {
            var query = _query.UpdateDescricao(cenarioid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateObjetivo(string cenarioid, string value)
        {
            var query = _query.UpdateObjetivo(cenarioid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateQuantidadeCargas(string cenarioid, int value)
        {
            var query = _query.UpdateQuantidadeCargas(cenarioid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateQuantidadePedidosNaoAtendidos(string cenarioid, int value)
        {
            var query = _query.UpdateQuantidadePedidosNaoAtendidos(cenarioid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCustoTotal(string cenarioid, Decimal value)
        {
            var query = _query.UpdateCustoTotal(cenarioid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAderenciaCubagem(string cenarioid, Decimal value)
        {
            var query = _query.UpdateAderenciaCubagem(cenarioid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAtrasoPrevisto(string cenarioid, Decimal value)
        {
            var query = _query.UpdateAtrasoPrevisto(cenarioid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAlertasResumo(string cenarioid, string value)
        {
            var query = _query.UpdateAlertasResumo(cenarioid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration