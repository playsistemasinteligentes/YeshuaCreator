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

namespace Input.Repository.OpcaoPlanejamentoTransporte
{
    public partial class OpcaoPlanejamentoTransporteWriteRepository : IOpcaoPlanejamentoTransporteWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IOpcaoPlanejamentoTransporteQueryWrite _query; 

        public OpcaoPlanejamentoTransporteWriteRepository(IUnitOfWork unitOfWork,IOpcaoPlanejamentoTransporteQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IOpcaoPlanejamentoTransporteEntity OpcaoPlanejamentoTransporte)
        {
            var query = _query.InserirOpcaoPlanejamentoTransporteQuery(OpcaoPlanejamentoTransporte);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IOpcaoPlanejamentoTransporteEntity OpcaoPlanejamentoTransporte)
        {
            var query = _query.UpdateOpcaoPlanejamentoTransporteQuery(OpcaoPlanejamentoTransporte);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IOpcaoPlanejamentoTransporteEntity OpcaoPlanejamentoTransporte)
        {
            var query = _query.DeleteOpcaoPlanejamentoTransporteQuery(OpcaoPlanejamentoTransporte);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGrupoDecisaoId(string opcaoid, string value)
        {
            var query = _query.UpdateGrupoDecisaoId(opcaoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePeso(string opcaoid, Decimal value)
        {
            var query = _query.UpdatePeso(opcaoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVolume(string opcaoid, Decimal value)
        {
            var query = _query.UpdateVolume(opcaoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCustoEstimado(string opcaoid, Decimal value)
        {
            var query = _query.UpdateCustoEstimado(opcaoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAderenciaCubagem(string opcaoid, Decimal value)
        {
            var query = _query.UpdateAderenciaCubagem(opcaoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAderenciaJanelaEntrega(string opcaoid, Decimal value)
        {
            var query = _query.UpdateAderenciaJanelaEntrega(opcaoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRiscoResumo(string opcaoid, string value)
        {
            var query = _query.UpdateRiscoResumo(opcaoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePedidosResumo(string opcaoid, string value)
        {
            var query = _query.UpdatePedidosResumo(opcaoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOpcoesConflitantesResumo(string opcaoid, string value)
        {
            var query = _query.UpdateOpcoesConflitantesResumo(opcaoid, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration