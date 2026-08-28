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
    public class FeedbackQueryWrite : QueryBase, IFeedbackQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public FeedbackQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirFeedbackQuery(IFeedbackEntity Feedback)
        {
            this.Query = $@" INSERT INTO Feedback (DataInicial, Datafinal, MaquinaId, OcorrenciaId, TurnoId, TurmaId, UsuarioId, OrderId, ProdutoId, Observacoes, Grupo, DiaTurma, SequenciaTransformacao, SequenciaRepeticao, QuantidadePulsos, QuantidadePecasPorPulso, FEE_QTD_TOTAL_PRODUCAO_AJUSTADA, BOL_ID, COR_SEQUENCIA, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@DataInicial, @Datafinal, @MaquinaId, @OcorrenciaId, @TurnoId, @TurmaId, @UsuarioId, @OrderId, @ProdutoId, @Observacoes, @Grupo, @DiaTurma, @SequenciaTransformacao, @SequenciaRepeticao, @QuantidadePulsos, @QuantidadePecasPorPulso, @FEE_QTD_TOTAL_PRODUCAO_AJUSTADA, @BOL_ID, @COR_SEQUENCIA, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                DataInicial = Feedback.DataInicial,
                Datafinal = Feedback.Datafinal,
                MaquinaId = Feedback.MaquinaId,
                OcorrenciaId = Feedback.OcorrenciaId,
                TurnoId = Feedback.TurnoId,
                TurmaId = Feedback.TurmaId,
                UsuarioId = Feedback.UsuarioId,
                OrderId = Feedback.OrderId,
                ProdutoId = Feedback.ProdutoId,
                Observacoes = Feedback.Observacoes,
                Grupo = Feedback.Grupo,
                DiaTurma = Feedback.DiaTurma,
                SequenciaTransformacao = Feedback.SequenciaTransformacao,
                SequenciaRepeticao = Feedback.SequenciaRepeticao,
                QuantidadePulsos = Feedback.QuantidadePulsos,
                QuantidadePecasPorPulso = Feedback.QuantidadePecasPorPulso,
                FEE_QTD_TOTAL_PRODUCAO_AJUSTADA = Feedback.FEE_QTD_TOTAL_PRODUCAO_AJUSTADA,
                BOL_ID = Feedback.BOL_ID,
                COR_SEQUENCIA = Feedback.COR_SEQUENCIA,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFeedbackQuery(IFeedbackEntity Feedback)
        {
            this.Query = $@" UPDATE Feedback SET DataInicial = @DataInicial, Datafinal = @Datafinal, MaquinaId = @MaquinaId, OcorrenciaId = @OcorrenciaId, TurnoId = @TurnoId, TurmaId = @TurmaId, UsuarioId = @UsuarioId, OrderId = @OrderId, ProdutoId = @ProdutoId, Observacoes = @Observacoes, Grupo = @Grupo, DiaTurma = @DiaTurma, SequenciaTransformacao = @SequenciaTransformacao, SequenciaRepeticao = @SequenciaRepeticao, QuantidadePulsos = @QuantidadePulsos, QuantidadePecasPorPulso = @QuantidadePecasPorPulso, FEE_QTD_TOTAL_PRODUCAO_AJUSTADA = @FEE_QTD_TOTAL_PRODUCAO_AJUSTADA, BOL_ID = @BOL_ID, COR_SEQUENCIA = @COR_SEQUENCIA, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                DataInicial = Feedback.DataInicial,
                Datafinal = Feedback.Datafinal,
                MaquinaId = Feedback.MaquinaId,
                OcorrenciaId = Feedback.OcorrenciaId,
                TurnoId = Feedback.TurnoId,
                TurmaId = Feedback.TurmaId,
                UsuarioId = Feedback.UsuarioId,
                OrderId = Feedback.OrderId,
                ProdutoId = Feedback.ProdutoId,
                Observacoes = Feedback.Observacoes,
                Grupo = Feedback.Grupo,
                DiaTurma = Feedback.DiaTurma,
                SequenciaTransformacao = Feedback.SequenciaTransformacao,
                SequenciaRepeticao = Feedback.SequenciaRepeticao,
                QuantidadePulsos = Feedback.QuantidadePulsos,
                QuantidadePecasPorPulso = Feedback.QuantidadePecasPorPulso,
                FEE_QTD_TOTAL_PRODUCAO_AJUSTADA = Feedback.FEE_QTD_TOTAL_PRODUCAO_AJUSTADA,
                BOL_ID = Feedback.BOL_ID,
                COR_SEQUENCIA = Feedback.COR_SEQUENCIA,
                Changed = Feedback.Changed,
                UserId = _executionContext.UserId,
                Id = Feedback.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataInicial(int id, DateTime value)
        {
            this.Query = $@" UPDATE Feedback SET DataInicial = @DataInicial WHERE Id = @Id ";
            this.Parameters = new
            {
                DataInicial = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDatafinal(int id, DateTime value)
        {
            this.Query = $@" UPDATE Feedback SET Datafinal = @Datafinal WHERE Id = @Id ";
            this.Parameters = new
            {
                Datafinal = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMaquinaId(int id, string value)
        {
            this.Query = $@" UPDATE Feedback SET MaquinaId = @MaquinaId WHERE Id = @Id ";
            this.Parameters = new
            {
                MaquinaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOcorrenciaId(int id, string value)
        {
            this.Query = $@" UPDATE Feedback SET OcorrenciaId = @OcorrenciaId WHERE Id = @Id ";
            this.Parameters = new
            {
                OcorrenciaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTurnoId(int id, string value)
        {
            this.Query = $@" UPDATE Feedback SET TurnoId = @TurnoId WHERE Id = @Id ";
            this.Parameters = new
            {
                TurnoId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTurmaId(int id, string value)
        {
            this.Query = $@" UPDATE Feedback SET TurmaId = @TurmaId WHERE Id = @Id ";
            this.Parameters = new
            {
                TurmaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUsuarioId(int id, int value)
        {
            this.Query = $@" UPDATE Feedback SET UsuarioId = @UsuarioId WHERE Id = @Id ";
            this.Parameters = new
            {
                UsuarioId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOrderId(int id, string value)
        {
            this.Query = $@" UPDATE Feedback SET OrderId = @OrderId WHERE Id = @Id ";
            this.Parameters = new
            {
                OrderId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProdutoId(int id, string value)
        {
            this.Query = $@" UPDATE Feedback SET ProdutoId = @ProdutoId WHERE Id = @Id ";
            this.Parameters = new
            {
                ProdutoId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateObservacoes(int id, string value)
        {
            this.Query = $@" UPDATE Feedback SET Observacoes = @Observacoes WHERE Id = @Id ";
            this.Parameters = new
            {
                Observacoes = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrupo(int id, Decimal value)
        {
            this.Query = $@" UPDATE Feedback SET Grupo = @Grupo WHERE Id = @Id ";
            this.Parameters = new
            {
                Grupo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDiaTurma(int id, string value)
        {
            this.Query = $@" UPDATE Feedback SET DiaTurma = @DiaTurma WHERE Id = @Id ";
            this.Parameters = new
            {
                DiaTurma = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSequenciaTransformacao(int id, int value)
        {
            this.Query = $@" UPDATE Feedback SET SequenciaTransformacao = @SequenciaTransformacao WHERE Id = @Id ";
            this.Parameters = new
            {
                SequenciaTransformacao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSequenciaRepeticao(int id, int value)
        {
            this.Query = $@" UPDATE Feedback SET SequenciaRepeticao = @SequenciaRepeticao WHERE Id = @Id ";
            this.Parameters = new
            {
                SequenciaRepeticao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateQuantidadePulsos(int id, Decimal value)
        {
            this.Query = $@" UPDATE Feedback SET QuantidadePulsos = @QuantidadePulsos WHERE Id = @Id ";
            this.Parameters = new
            {
                QuantidadePulsos = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateQuantidadePecasPorPulso(int id, Decimal value)
        {
            this.Query = $@" UPDATE Feedback SET QuantidadePecasPorPulso = @QuantidadePecasPorPulso WHERE Id = @Id ";
            this.Parameters = new
            {
                QuantidadePecasPorPulso = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFEE_QTD_TOTAL_PRODUCAO_AJUSTADA(int id, Decimal value)
        {
            this.Query = $@" UPDATE Feedback SET FEE_QTD_TOTAL_PRODUCAO_AJUSTADA = @FEE_QTD_TOTAL_PRODUCAO_AJUSTADA WHERE Id = @Id ";
            this.Parameters = new
            {
                FEE_QTD_TOTAL_PRODUCAO_AJUSTADA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_ID(int id, string value)
        {
            this.Query = $@" UPDATE Feedback SET BOL_ID = @BOL_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                BOL_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_SEQUENCIA(int id, int value)
        {
            this.Query = $@" UPDATE Feedback SET COR_SEQUENCIA = @COR_SEQUENCIA WHERE Id = @Id ";
            this.Parameters = new
            {
                COR_SEQUENCIA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Feedback SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Feedback SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Feedback SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Feedback SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteFeedbackQuery(IFeedbackEntity Feedback)
        {
            this.Query = $@" DELETE FROM Feedback WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Feedback.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration