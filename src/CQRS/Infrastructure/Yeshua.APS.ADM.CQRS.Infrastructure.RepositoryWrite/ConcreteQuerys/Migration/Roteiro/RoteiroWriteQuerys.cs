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
    public class RoteiroQueryWrite : QueryBase, IRoteiroQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public RoteiroQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirRoteiroQuery(IRoteiroEntity Roteiro)
        {
            this.Query = $@" INSERT INTO Roteiro (MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId) VALUES(@MaquinaId, @ProdutoId, @SequenciaTransformacao, @GrupoMaquinaId, @PecasPorPulso, @PrioridadeInformada, @Acao, @Performance, @TempoSetup, @TempoSetupAjuste, @ProximaSequenciaTransformacao, @Status, @HierarquiaSequenciaTransformacao, @AvaliaCusto, @Operacoes, @ExcecaoOperacoes, @PercentualInicioPassoAnterior, @LinhaDireta, @TemplateDeTestesId, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MaquinaId = Roteiro.MaquinaId,
                ProdutoId = Roteiro.ProdutoId,
                SequenciaTransformacao = Roteiro.SequenciaTransformacao,
                GrupoMaquinaId = Roteiro.GrupoMaquinaId,
                PecasPorPulso = Roteiro.PecasPorPulso,
                PrioridadeInformada = Roteiro.PrioridadeInformada,
                Acao = Roteiro.Acao,
                Performance = Roteiro.Performance,
                TempoSetup = Roteiro.TempoSetup,
                TempoSetupAjuste = Roteiro.TempoSetupAjuste,
                ProximaSequenciaTransformacao = Roteiro.ProximaSequenciaTransformacao,
                Status = Roteiro.Status,
                HierarquiaSequenciaTransformacao = Roteiro.HierarquiaSequenciaTransformacao,
                AvaliaCusto = Roteiro.AvaliaCusto,
                Operacoes = Roteiro.Operacoes,
                ExcecaoOperacoes = Roteiro.ExcecaoOperacoes,
                PercentualInicioPassoAnterior = Roteiro.PercentualInicioPassoAnterior,
                LinhaDireta = Roteiro.LinhaDireta,
                TemplateDeTestesId = Roteiro.TemplateDeTestesId,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRoteiroQuery(IRoteiroEntity Roteiro)
        {
            this.Query = $@" UPDATE Roteiro SET GrupoMaquinaId = @GrupoMaquinaId, PecasPorPulso = @PecasPorPulso, PrioridadeInformada = @PrioridadeInformada, Acao = @Acao, Performance = @Performance, TempoSetup = @TempoSetup, TempoSetupAjuste = @TempoSetupAjuste, ProximaSequenciaTransformacao = @ProximaSequenciaTransformacao, Status = @Status, HierarquiaSequenciaTransformacao = @HierarquiaSequenciaTransformacao, AvaliaCusto = @AvaliaCusto, Operacoes = @Operacoes, ExcecaoOperacoes = @ExcecaoOperacoes, PercentualInicioPassoAnterior = @PercentualInicioPassoAnterior, LinhaDireta = @LinhaDireta, TemplateDeTestesId = @TemplateDeTestesId, Changed = @Changed, UserId = @UserId WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                GrupoMaquinaId = Roteiro.GrupoMaquinaId,
                PecasPorPulso = Roteiro.PecasPorPulso,
                PrioridadeInformada = Roteiro.PrioridadeInformada,
                Acao = Roteiro.Acao,
                Performance = Roteiro.Performance,
                TempoSetup = Roteiro.TempoSetup,
                TempoSetupAjuste = Roteiro.TempoSetupAjuste,
                ProximaSequenciaTransformacao = Roteiro.ProximaSequenciaTransformacao,
                Status = Roteiro.Status,
                HierarquiaSequenciaTransformacao = Roteiro.HierarquiaSequenciaTransformacao,
                AvaliaCusto = Roteiro.AvaliaCusto,
                Operacoes = Roteiro.Operacoes,
                ExcecaoOperacoes = Roteiro.ExcecaoOperacoes,
                PercentualInicioPassoAnterior = Roteiro.PercentualInicioPassoAnterior,
                LinhaDireta = Roteiro.LinhaDireta,
                TemplateDeTestesId = Roteiro.TemplateDeTestesId,
                Changed = Roteiro.Changed,
                UserId = _executionContext.UserId,
                MaquinaId = Roteiro.MaquinaId,
                ProdutoId = Roteiro.ProdutoId,
                SequenciaTransformacao = Roteiro.SequenciaTransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrupoMaquinaId(string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            this.Query = $@" UPDATE Roteiro SET GrupoMaquinaId = @GrupoMaquinaId WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                GrupoMaquinaId = value,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePecasPorPulso(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET PecasPorPulso = @PecasPorPulso WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                PecasPorPulso = value,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePrioridadeInformada(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET PrioridadeInformada = @PrioridadeInformada WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                PrioridadeInformada = value,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAcao(string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            this.Query = $@" UPDATE Roteiro SET Acao = @Acao WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                Acao = value,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePerformance(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET Performance = @Performance WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                Performance = value,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTempoSetup(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET TempoSetup = @TempoSetup WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                TempoSetup = value,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTempoSetupAjuste(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET TempoSetupAjuste = @TempoSetupAjuste WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                TempoSetupAjuste = value,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProximaSequenciaTransformacao(string maquinaid, string produtoid, int sequenciatransformacao, int value)
        {
            this.Query = $@" UPDATE Roteiro SET ProximaSequenciaTransformacao = @ProximaSequenciaTransformacao WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                ProximaSequenciaTransformacao = value,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            this.Query = $@" UPDATE Roteiro SET Status = @Status WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                Status = value,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateHierarquiaSequenciaTransformacao(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET HierarquiaSequenciaTransformacao = @HierarquiaSequenciaTransformacao WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                HierarquiaSequenciaTransformacao = value,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAvaliaCusto(string maquinaid, string produtoid, int sequenciatransformacao, int value)
        {
            this.Query = $@" UPDATE Roteiro SET AvaliaCusto = @AvaliaCusto WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                AvaliaCusto = value,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOperacoes(string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            this.Query = $@" UPDATE Roteiro SET Operacoes = @Operacoes WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                Operacoes = value,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateExcecaoOperacoes(string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            this.Query = $@" UPDATE Roteiro SET ExcecaoOperacoes = @ExcecaoOperacoes WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                ExcecaoOperacoes = value,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePercentualInicioPassoAnterior(string maquinaid, string produtoid, int sequenciatransformacao, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET PercentualInicioPassoAnterior = @PercentualInicioPassoAnterior WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                PercentualInicioPassoAnterior = value,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLinhaDireta(string maquinaid, string produtoid, int sequenciatransformacao, string value)
        {
            this.Query = $@" UPDATE Roteiro SET LinhaDireta = @LinhaDireta WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                LinhaDireta = value,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTemplateDeTestesId(string maquinaid, string produtoid, int sequenciatransformacao, int value)
        {
            this.Query = $@" UPDATE Roteiro SET TemplateDeTestesId = @TemplateDeTestesId WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                TemplateDeTestesId = value,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string maquinaid, string produtoid, int sequenciatransformacao, int value)
        {
            this.Query = $@" UPDATE Roteiro SET TenantID = @TenantID WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                TenantID = value,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string maquinaid, string produtoid, int sequenciatransformacao, bool value)
        {
            this.Query = $@" UPDATE Roteiro SET Deleted = @Deleted WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                Deleted = value,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string maquinaid, string produtoid, int sequenciatransformacao, DateTime value)
        {
            this.Query = $@" UPDATE Roteiro SET Changed = @Changed WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                Changed = value,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string maquinaid, string produtoid, int sequenciatransformacao, int value)
        {
            this.Query = $@" UPDATE Roteiro SET UserId = @UserId WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                UserId = value,
                MaquinaId = maquinaid,
                ProdutoId = produtoid,
                SequenciaTransformacao = sequenciatransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteRoteiroQuery(IRoteiroEntity Roteiro)
        {
            this.Query = $@" DELETE FROM Roteiro WHERE MaquinaId = @MaquinaId AND ProdutoId = @ProdutoId AND SequenciaTransformacao = @SequenciaTransformacao ";
            this.Parameters = new
            {
                MaquinaId = Roteiro.MaquinaId,
                ProdutoId = Roteiro.ProdutoId,
                SequenciaTransformacao = Roteiro.SequenciaTransformacao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration