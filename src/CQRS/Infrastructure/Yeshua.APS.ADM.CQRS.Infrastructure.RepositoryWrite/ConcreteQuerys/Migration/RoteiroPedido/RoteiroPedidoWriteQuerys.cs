// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Dominio.Entitys;
using Shered.DB;
using Command.Write;
using IQuery.Write;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Write
{
    public class RoteiroPedidoQueryWrite : QueryBase, IRoteiroPedidoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public RoteiroPedidoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirRoteiroPedidoQuery(IRoteiroPedidoEntity RoteiroPedido)
        {
            this.Query = $@" INSERT INTO RoteiroPedido (PedidoId, MaquinaId, ProdutoId, SequenciaTransformacao, StatusCadastro, TipoPlanejamento, CalendarioId, HierarquiaSequenciaTransformacao, ProximaSequenciaTransformacao, Performance, TempoSetup, TempoSetupAjuste, PecasPorPulso, PrioridadeInformada, Status, Operacoes, ExcecaoOperacoes, LinhaDireta, AvaliaCusto, PercentualInicioPassoAnterior, MaquinaLarguraUtil, GrupoTipo, GrupoPerformanceMetroLinear) VALUES(@PedidoId, @MaquinaId, @ProdutoId, @SequenciaTransformacao, @StatusCadastro, @TipoPlanejamento, @CalendarioId, @HierarquiaSequenciaTransformacao, @ProximaSequenciaTransformacao, @Performance, @TempoSetup, @TempoSetupAjuste, @PecasPorPulso, @PrioridadeInformada, @Status, @Operacoes, @ExcecaoOperacoes, @LinhaDireta, @AvaliaCusto, @PercentualInicioPassoAnterior, @MaquinaLarguraUtil, @GrupoTipo, @GrupoPerformanceMetroLinear) ";
            this.Parameters = new
            {
                PedidoId = RoteiroPedido.PedidoId,
                MaquinaId = RoteiroPedido.MaquinaId,
                ProdutoId = RoteiroPedido.ProdutoId,
                SequenciaTransformacao = RoteiroPedido.SequenciaTransformacao,
                StatusCadastro = RoteiroPedido.StatusCadastro,
                TipoPlanejamento = RoteiroPedido.TipoPlanejamento,
                CalendarioId = RoteiroPedido.CalendarioId,
                HierarquiaSequenciaTransformacao = RoteiroPedido.HierarquiaSequenciaTransformacao,
                ProximaSequenciaTransformacao = RoteiroPedido.ProximaSequenciaTransformacao,
                Performance = RoteiroPedido.Performance,
                TempoSetup = RoteiroPedido.TempoSetup,
                TempoSetupAjuste = RoteiroPedido.TempoSetupAjuste,
                PecasPorPulso = RoteiroPedido.PecasPorPulso,
                PrioridadeInformada = RoteiroPedido.PrioridadeInformada,
                Status = RoteiroPedido.Status,
                Operacoes = RoteiroPedido.Operacoes,
                ExcecaoOperacoes = RoteiroPedido.ExcecaoOperacoes,
                LinhaDireta = RoteiroPedido.LinhaDireta,
                AvaliaCusto = RoteiroPedido.AvaliaCusto,
                PercentualInicioPassoAnterior = RoteiroPedido.PercentualInicioPassoAnterior,
                MaquinaLarguraUtil = RoteiroPedido.MaquinaLarguraUtil,
                GrupoTipo = RoteiroPedido.GrupoTipo,
                GrupoPerformanceMetroLinear = RoteiroPedido.GrupoPerformanceMetroLinear,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRoteiroPedidoQuery(IRoteiroPedidoEntity RoteiroPedido)
        {
            this.Query = $@" UPDATE RoteiroPedido SET StatusCadastro = @StatusCadastro, TipoPlanejamento = @TipoPlanejamento, CalendarioId = @CalendarioId, HierarquiaSequenciaTransformacao = @HierarquiaSequenciaTransformacao, ProximaSequenciaTransformacao = @ProximaSequenciaTransformacao, Performance = @Performance, TempoSetup = @TempoSetup, TempoSetupAjuste = @TempoSetupAjuste, PecasPorPulso = @PecasPorPulso, PrioridadeInformada = @PrioridadeInformada, Status = @Status, Operacoes = @Operacoes, ExcecaoOperacoes = @ExcecaoOperacoes, LinhaDireta = @LinhaDireta, AvaliaCusto = @AvaliaCusto, PercentualInicioPassoAnterior = @PercentualInicioPassoAnterior, MaquinaLarguraUtil = @MaquinaLarguraUtil, GrupoTipo = @GrupoTipo, GrupoPerformanceMetroLinear = @GrupoPerformanceMetroLinear WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                StatusCadastro = RoteiroPedido.StatusCadastro,
                TipoPlanejamento = RoteiroPedido.TipoPlanejamento,
                CalendarioId = RoteiroPedido.CalendarioId,
                HierarquiaSequenciaTransformacao = RoteiroPedido.HierarquiaSequenciaTransformacao,
                ProximaSequenciaTransformacao = RoteiroPedido.ProximaSequenciaTransformacao,
                Performance = RoteiroPedido.Performance,
                TempoSetup = RoteiroPedido.TempoSetup,
                TempoSetupAjuste = RoteiroPedido.TempoSetupAjuste,
                PecasPorPulso = RoteiroPedido.PecasPorPulso,
                PrioridadeInformada = RoteiroPedido.PrioridadeInformada,
                Status = RoteiroPedido.Status,
                Operacoes = RoteiroPedido.Operacoes,
                ExcecaoOperacoes = RoteiroPedido.ExcecaoOperacoes,
                LinhaDireta = RoteiroPedido.LinhaDireta,
                AvaliaCusto = RoteiroPedido.AvaliaCusto,
                PercentualInicioPassoAnterior = RoteiroPedido.PercentualInicioPassoAnterior,
                MaquinaLarguraUtil = RoteiroPedido.MaquinaLarguraUtil,
                GrupoTipo = RoteiroPedido.GrupoTipo,
                GrupoPerformanceMetroLinear = RoteiroPedido.GrupoPerformanceMetroLinear,
                PedidoId = RoteiroPedido.PedidoId,
                MaquinaId = RoteiroPedido.MaquinaId,
                ProdutoId = RoteiroPedido.ProdutoId,
                SequenciaTransformacao = RoteiroPedido.SequenciaTransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatusCadastro(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            this.Query = $@" UPDATE RoteiroPedido SET StatusCadastro = @StatusCadastro WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                StatusCadastro = value,
                PedidoId = pedidoid,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoPlanejamento(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            this.Query = $@" UPDATE RoteiroPedido SET TipoPlanejamento = @TipoPlanejamento WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                TipoPlanejamento = value,
                PedidoId = pedidoid,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCalendarioId(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, int value)
        {
            this.Query = $@" UPDATE RoteiroPedido SET CalendarioId = @CalendarioId WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                CalendarioId = value,
                PedidoId = pedidoid,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateHierarquiaSequenciaTransformacao(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            this.Query = $@" UPDATE RoteiroPedido SET HierarquiaSequenciaTransformacao = @HierarquiaSequenciaTransformacao WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                HierarquiaSequenciaTransformacao = value,
                PedidoId = pedidoid,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProximaSequenciaTransformacao(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, int value)
        {
            this.Query = $@" UPDATE RoteiroPedido SET ProximaSequenciaTransformacao = @ProximaSequenciaTransformacao WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                ProximaSequenciaTransformacao = value,
                PedidoId = pedidoid,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePerformance(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            this.Query = $@" UPDATE RoteiroPedido SET Performance = @Performance WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                Performance = value,
                PedidoId = pedidoid,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTempoSetup(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            this.Query = $@" UPDATE RoteiroPedido SET TempoSetup = @TempoSetup WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                TempoSetup = value,
                PedidoId = pedidoid,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTempoSetupAjuste(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            this.Query = $@" UPDATE RoteiroPedido SET TempoSetupAjuste = @TempoSetupAjuste WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                TempoSetupAjuste = value,
                PedidoId = pedidoid,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePecasPorPulso(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            this.Query = $@" UPDATE RoteiroPedido SET PecasPorPulso = @PecasPorPulso WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                PecasPorPulso = value,
                PedidoId = pedidoid,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePrioridadeInformada(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            this.Query = $@" UPDATE RoteiroPedido SET PrioridadeInformada = @PrioridadeInformada WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                PrioridadeInformada = value,
                PedidoId = pedidoid,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            this.Query = $@" UPDATE RoteiroPedido SET Status = @Status WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                Status = value,
                PedidoId = pedidoid,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOperacoes(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            this.Query = $@" UPDATE RoteiroPedido SET Operacoes = @Operacoes WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                Operacoes = value,
                PedidoId = pedidoid,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateExcecaoOperacoes(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            this.Query = $@" UPDATE RoteiroPedido SET ExcecaoOperacoes = @ExcecaoOperacoes WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                ExcecaoOperacoes = value,
                PedidoId = pedidoid,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLinhaDireta(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            this.Query = $@" UPDATE RoteiroPedido SET LinhaDireta = @LinhaDireta WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                LinhaDireta = value,
                PedidoId = pedidoid,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAvaliaCusto(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, int value)
        {
            this.Query = $@" UPDATE RoteiroPedido SET AvaliaCusto = @AvaliaCusto WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                AvaliaCusto = value,
                PedidoId = pedidoid,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePercentualInicioPassoAnterior(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            this.Query = $@" UPDATE RoteiroPedido SET PercentualInicioPassoAnterior = @PercentualInicioPassoAnterior WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                PercentualInicioPassoAnterior = value,
                PedidoId = pedidoid,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMaquinaLarguraUtil(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            this.Query = $@" UPDATE RoteiroPedido SET MaquinaLarguraUtil = @MaquinaLarguraUtil WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                MaquinaLarguraUtil = value,
                PedidoId = pedidoid,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrupoTipo(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            this.Query = $@" UPDATE RoteiroPedido SET GrupoTipo = @GrupoTipo WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                GrupoTipo = value,
                PedidoId = pedidoid,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrupoPerformanceMetroLinear(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            this.Query = $@" UPDATE RoteiroPedido SET GrupoPerformanceMetroLinear = @GrupoPerformanceMetroLinear WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                GrupoPerformanceMetroLinear = value,
                PedidoId = pedidoid,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteRoteiroPedidoQuery(IRoteiroPedidoEntity RoteiroPedido)
        {
            this.Query = $@" DELETE FROM RoteiroPedido WHERE PedidoId = @PedidoId AND MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                PedidoId = RoteiroPedido.PedidoId,
                MaquinaId = RoteiroPedido.MaquinaId,
                ProdutoId = RoteiroPedido.ProdutoId,
                SequenciaTransformacao = RoteiroPedido.SequenciaTransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration