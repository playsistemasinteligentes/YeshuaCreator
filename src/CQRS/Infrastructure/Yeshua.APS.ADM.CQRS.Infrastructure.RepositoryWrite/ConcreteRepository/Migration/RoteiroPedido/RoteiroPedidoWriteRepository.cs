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

namespace Input.Repository.RoteiroPedido
{
    public partial class RoteiroPedidoWriteRepository : IRoteiroPedidoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IRoteiroPedidoQueryWrite _query; 

        public RoteiroPedidoWriteRepository(IUnitOfWork unitOfWork,IRoteiroPedidoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IRoteiroPedidoEntity RoteiroPedido)
        {
            var query = _query.InserirRoteiroPedidoQuery(RoteiroPedido);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IRoteiroPedidoEntity RoteiroPedido)
        {
            var query = _query.UpdateRoteiroPedidoQuery(RoteiroPedido);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IRoteiroPedidoEntity RoteiroPedido)
        {
            var query = _query.DeleteRoteiroPedidoQuery(RoteiroPedido);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatusCadastro(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            var query = _query.UpdateStatusCadastro(pedidoid, maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTipoPlanejamento(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            var query = _query.UpdateTipoPlanejamento(pedidoid, maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCalendarioId(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, int value)
        {
            var query = _query.UpdateCalendarioId(pedidoid, maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateHierarquiaSequenciaTransformacao(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            var query = _query.UpdateHierarquiaSequenciaTransformacao(pedidoid, maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProximaSequenciaTransformacao(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, int value)
        {
            var query = _query.UpdateProximaSequenciaTransformacao(pedidoid, maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePerformance(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            var query = _query.UpdatePerformance(pedidoid, maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTempoSetup(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            var query = _query.UpdateTempoSetup(pedidoid, maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTempoSetupAjuste(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            var query = _query.UpdateTempoSetupAjuste(pedidoid, maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePecasPorPulso(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            var query = _query.UpdatePecasPorPulso(pedidoid, maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePrioridadeInformada(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            var query = _query.UpdatePrioridadeInformada(pedidoid, maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            var query = _query.UpdateStatus(pedidoid, maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOperacoes(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            var query = _query.UpdateOperacoes(pedidoid, maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateExcecaoOperacoes(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            var query = _query.UpdateExcecaoOperacoes(pedidoid, maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLinhaDireta(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            var query = _query.UpdateLinhaDireta(pedidoid, maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAvaliaCusto(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, int value)
        {
            var query = _query.UpdateAvaliaCusto(pedidoid, maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePercentualInicioPassoAnterior(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            var query = _query.UpdatePercentualInicioPassoAnterior(pedidoid, maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMaquinaLarguraUtil(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            var query = _query.UpdateMaquinaLarguraUtil(pedidoid, maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGrupoTipo(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            var query = _query.UpdateGrupoTipo(pedidoid, maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGrupoPerformanceMetroLinear(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            var query = _query.UpdateGrupoPerformanceMetroLinear(pedidoid, maquinaid, produtoid, sequenciatransformacao, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration