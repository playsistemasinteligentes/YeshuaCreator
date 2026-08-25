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
            this.Query = $@" INSERT INTO Roteiro (MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@MaquinaId, @ProdutoId, @SequenciaTransformacao, @GrupoMaquinaId, @PecasPorPulso, @PrioridadeInformada, @Acao, @Performance, @TempoSetup, @TempoSetupAjuste, @ProximaSequenciaTransformacao, @Status, @HierarquiaSequenciaTransformacao, @AvaliaCusto, @Operacoes, @ExcecaoOperacoes, @PercentualInicioPassoAnterior, @LinhaDireta, @TemplateDeTestesId, @TenantID, @Deleted, @Changed, @UserId) ";
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
            this.Query = $@" UPDATE Roteiro SET MaquinaId = @MaquinaId, ProdutoId = @ProdutoId, SequenciaTransformacao = @SequenciaTransformacao, GrupoMaquinaId = @GrupoMaquinaId, PecasPorPulso = @PecasPorPulso, PrioridadeInformada = @PrioridadeInformada, Acao = @Acao, Performance = @Performance, TempoSetup = @TempoSetup, TempoSetupAjuste = @TempoSetupAjuste, ProximaSequenciaTransformacao = @ProximaSequenciaTransformacao, Status = @Status, HierarquiaSequenciaTransformacao = @HierarquiaSequenciaTransformacao, AvaliaCusto = @AvaliaCusto, Operacoes = @Operacoes, ExcecaoOperacoes = @ExcecaoOperacoes, PercentualInicioPassoAnterior = @PercentualInicioPassoAnterior, LinhaDireta = @LinhaDireta, TemplateDeTestesId = @TemplateDeTestesId, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
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
                Changed = Roteiro.Changed,
                UserId = _executionContext.UserId,
                Id = Roteiro.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMaquinaId(int id, string value)
        {
            this.Query = $@" UPDATE Roteiro SET MaquinaId = @MaquinaId WHERE Id = @Id ";
            this.Parameters = new
            {
                MaquinaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProdutoId(int id, string value)
        {
            this.Query = $@" UPDATE Roteiro SET ProdutoId = @ProdutoId WHERE Id = @Id ";
            this.Parameters = new
            {
                ProdutoId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSequenciaTransformacao(int id, int value)
        {
            this.Query = $@" UPDATE Roteiro SET SequenciaTransformacao = @SequenciaTransformacao WHERE Id = @Id ";
            this.Parameters = new
            {
                SequenciaTransformacao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrupoMaquinaId(int id, string value)
        {
            this.Query = $@" UPDATE Roteiro SET GrupoMaquinaId = @GrupoMaquinaId WHERE Id = @Id ";
            this.Parameters = new
            {
                GrupoMaquinaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePecasPorPulso(int id, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET PecasPorPulso = @PecasPorPulso WHERE Id = @Id ";
            this.Parameters = new
            {
                PecasPorPulso = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePrioridadeInformada(int id, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET PrioridadeInformada = @PrioridadeInformada WHERE Id = @Id ";
            this.Parameters = new
            {
                PrioridadeInformada = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAcao(int id, string value)
        {
            this.Query = $@" UPDATE Roteiro SET Acao = @Acao WHERE Id = @Id ";
            this.Parameters = new
            {
                Acao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePerformance(int id, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET Performance = @Performance WHERE Id = @Id ";
            this.Parameters = new
            {
                Performance = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTempoSetup(int id, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET TempoSetup = @TempoSetup WHERE Id = @Id ";
            this.Parameters = new
            {
                TempoSetup = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTempoSetupAjuste(int id, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET TempoSetupAjuste = @TempoSetupAjuste WHERE Id = @Id ";
            this.Parameters = new
            {
                TempoSetupAjuste = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProximaSequenciaTransformacao(int id, int value)
        {
            this.Query = $@" UPDATE Roteiro SET ProximaSequenciaTransformacao = @ProximaSequenciaTransformacao WHERE Id = @Id ";
            this.Parameters = new
            {
                ProximaSequenciaTransformacao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, string value)
        {
            this.Query = $@" UPDATE Roteiro SET Status = @Status WHERE Id = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateHierarquiaSequenciaTransformacao(int id, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET HierarquiaSequenciaTransformacao = @HierarquiaSequenciaTransformacao WHERE Id = @Id ";
            this.Parameters = new
            {
                HierarquiaSequenciaTransformacao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAvaliaCusto(int id, int value)
        {
            this.Query = $@" UPDATE Roteiro SET AvaliaCusto = @AvaliaCusto WHERE Id = @Id ";
            this.Parameters = new
            {
                AvaliaCusto = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOperacoes(int id, string value)
        {
            this.Query = $@" UPDATE Roteiro SET Operacoes = @Operacoes WHERE Id = @Id ";
            this.Parameters = new
            {
                Operacoes = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateExcecaoOperacoes(int id, string value)
        {
            this.Query = $@" UPDATE Roteiro SET ExcecaoOperacoes = @ExcecaoOperacoes WHERE Id = @Id ";
            this.Parameters = new
            {
                ExcecaoOperacoes = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePercentualInicioPassoAnterior(int id, Decimal value)
        {
            this.Query = $@" UPDATE Roteiro SET PercentualInicioPassoAnterior = @PercentualInicioPassoAnterior WHERE Id = @Id ";
            this.Parameters = new
            {
                PercentualInicioPassoAnterior = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLinhaDireta(int id, string value)
        {
            this.Query = $@" UPDATE Roteiro SET LinhaDireta = @LinhaDireta WHERE Id = @Id ";
            this.Parameters = new
            {
                LinhaDireta = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTemplateDeTestesId(int id, int value)
        {
            this.Query = $@" UPDATE Roteiro SET TemplateDeTestesId = @TemplateDeTestesId WHERE Id = @Id ";
            this.Parameters = new
            {
                TemplateDeTestesId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Roteiro SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Roteiro SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Roteiro SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Roteiro SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteRoteiroQuery(IRoteiroEntity Roteiro)
        {
            this.Query = $@" DELETE FROM Roteiro WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Roteiro.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration