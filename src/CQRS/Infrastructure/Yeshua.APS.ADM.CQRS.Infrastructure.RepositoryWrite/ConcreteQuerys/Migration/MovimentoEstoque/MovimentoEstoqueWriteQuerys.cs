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
    public class MovimentoEstoqueQueryWrite : QueryBase, IMovimentoEstoqueQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public MovimentoEstoqueQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirMovimentoEstoqueQuery(IMovimentoEstoqueEntity MovimentoEstoque)
        {
            this.Query = $@" INSERT INTO MovimentoEstoque (ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@ProdutoId, @OrderId, @Tipo, @TurnoId, @TurmaId, @Quantidade, @MOV_PESO_UNITARIO, @DataHoraCriacao, @DataHoraEmissao, @DiaTurma, @Lote, @SubLote, @MaquinaId, @USE_ID, @Observacao, @OcorrenciaId, @Armazem, @Endereco, @Estorno, @SequenciaTransformacao, @SequenciaRepeticao, @ObsOpParcial, @OcoIdOpParcial, @MOV_ID_INTEGRACAO, @MOV_ID_INTEGRACAO_ERP, @CAR_ID, @MOV_ID_DESTINO, @PRO_ID_DESTINO, @MOV_LOTE_DESTINO, @MOV_SUB_LOTE_DESTINO, @MOV_ID_ORIGEM, @PRO_ID_ORIGEM, @MOV_LOTE_ORIGEM, @MOV_SUB_LOTE_ORIGEM, @MOV_TYPE, @MOV_DOC, @MOV_APROVEITAMENTO, @MOV_RETIDO, @MOV_VINCOS_ONDULADEIRA, @BOL_ID, @ORD_ID_ORIGEM, @COR_SEQUENCIA, @VER_ID, @MOV_TIPO_CUSTO, @MOV_GRUPO_CONTABIL, @FOR_ID, @CLI_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                ProdutoId = MovimentoEstoque.ProdutoId,
                OrderId = MovimentoEstoque.OrderId,
                Tipo = MovimentoEstoque.Tipo,
                TurnoId = MovimentoEstoque.TurnoId,
                TurmaId = MovimentoEstoque.TurmaId,
                Quantidade = MovimentoEstoque.Quantidade,
                MOV_PESO_UNITARIO = MovimentoEstoque.MOV_PESO_UNITARIO,
                DataHoraCriacao = MovimentoEstoque.DataHoraCriacao,
                DataHoraEmissao = MovimentoEstoque.DataHoraEmissao,
                DiaTurma = MovimentoEstoque.DiaTurma,
                Lote = MovimentoEstoque.Lote,
                SubLote = MovimentoEstoque.SubLote,
                MaquinaId = MovimentoEstoque.MaquinaId,
                USE_ID = MovimentoEstoque.USE_ID,
                Observacao = MovimentoEstoque.Observacao,
                OcorrenciaId = MovimentoEstoque.OcorrenciaId,
                Armazem = MovimentoEstoque.Armazem,
                Endereco = MovimentoEstoque.Endereco,
                Estorno = MovimentoEstoque.Estorno,
                SequenciaTransformacao = MovimentoEstoque.SequenciaTransformacao,
                SequenciaRepeticao = MovimentoEstoque.SequenciaRepeticao,
                ObsOpParcial = MovimentoEstoque.ObsOpParcial,
                OcoIdOpParcial = MovimentoEstoque.OcoIdOpParcial,
                MOV_ID_INTEGRACAO = MovimentoEstoque.MOV_ID_INTEGRACAO,
                MOV_ID_INTEGRACAO_ERP = MovimentoEstoque.MOV_ID_INTEGRACAO_ERP,
                CAR_ID = MovimentoEstoque.CAR_ID,
                MOV_ID_DESTINO = MovimentoEstoque.MOV_ID_DESTINO,
                PRO_ID_DESTINO = MovimentoEstoque.PRO_ID_DESTINO,
                MOV_LOTE_DESTINO = MovimentoEstoque.MOV_LOTE_DESTINO,
                MOV_SUB_LOTE_DESTINO = MovimentoEstoque.MOV_SUB_LOTE_DESTINO,
                MOV_ID_ORIGEM = MovimentoEstoque.MOV_ID_ORIGEM,
                PRO_ID_ORIGEM = MovimentoEstoque.PRO_ID_ORIGEM,
                MOV_LOTE_ORIGEM = MovimentoEstoque.MOV_LOTE_ORIGEM,
                MOV_SUB_LOTE_ORIGEM = MovimentoEstoque.MOV_SUB_LOTE_ORIGEM,
                MOV_TYPE = MovimentoEstoque.MOV_TYPE,
                MOV_DOC = MovimentoEstoque.MOV_DOC,
                MOV_APROVEITAMENTO = MovimentoEstoque.MOV_APROVEITAMENTO,
                MOV_RETIDO = MovimentoEstoque.MOV_RETIDO,
                MOV_VINCOS_ONDULADEIRA = MovimentoEstoque.MOV_VINCOS_ONDULADEIRA,
                BOL_ID = MovimentoEstoque.BOL_ID,
                ORD_ID_ORIGEM = MovimentoEstoque.ORD_ID_ORIGEM,
                COR_SEQUENCIA = MovimentoEstoque.COR_SEQUENCIA,
                VER_ID = MovimentoEstoque.VER_ID,
                MOV_TIPO_CUSTO = MovimentoEstoque.MOV_TIPO_CUSTO,
                MOV_GRUPO_CONTABIL = MovimentoEstoque.MOV_GRUPO_CONTABIL,
                FOR_ID = MovimentoEstoque.FOR_ID,
                CLI_ID = MovimentoEstoque.CLI_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMovimentoEstoqueQuery(IMovimentoEstoqueEntity MovimentoEstoque)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET ProdutoId = @ProdutoId, OrderId = @OrderId, Tipo = @Tipo, TurnoId = @TurnoId, TurmaId = @TurmaId, Quantidade = @Quantidade, MOV_PESO_UNITARIO = @MOV_PESO_UNITARIO, DataHoraCriacao = @DataHoraCriacao, DataHoraEmissao = @DataHoraEmissao, DiaTurma = @DiaTurma, Lote = @Lote, SubLote = @SubLote, MaquinaId = @MaquinaId, USE_ID = @USE_ID, Observacao = @Observacao, OcorrenciaId = @OcorrenciaId, Armazem = @Armazem, Endereco = @Endereco, Estorno = @Estorno, SequenciaTransformacao = @SequenciaTransformacao, SequenciaRepeticao = @SequenciaRepeticao, ObsOpParcial = @ObsOpParcial, OcoIdOpParcial = @OcoIdOpParcial, MOV_ID_INTEGRACAO = @MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP = @MOV_ID_INTEGRACAO_ERP, CAR_ID = @CAR_ID, MOV_ID_DESTINO = @MOV_ID_DESTINO, PRO_ID_DESTINO = @PRO_ID_DESTINO, MOV_LOTE_DESTINO = @MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO = @MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM = @MOV_ID_ORIGEM, PRO_ID_ORIGEM = @PRO_ID_ORIGEM, MOV_LOTE_ORIGEM = @MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM = @MOV_SUB_LOTE_ORIGEM, MOV_TYPE = @MOV_TYPE, MOV_DOC = @MOV_DOC, MOV_APROVEITAMENTO = @MOV_APROVEITAMENTO, MOV_RETIDO = @MOV_RETIDO, MOV_VINCOS_ONDULADEIRA = @MOV_VINCOS_ONDULADEIRA, BOL_ID = @BOL_ID, ORD_ID_ORIGEM = @ORD_ID_ORIGEM, COR_SEQUENCIA = @COR_SEQUENCIA, VER_ID = @VER_ID, MOV_TIPO_CUSTO = @MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL = @MOV_GRUPO_CONTABIL, FOR_ID = @FOR_ID, CLI_ID = @CLI_ID, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                ProdutoId = MovimentoEstoque.ProdutoId,
                OrderId = MovimentoEstoque.OrderId,
                Tipo = MovimentoEstoque.Tipo,
                TurnoId = MovimentoEstoque.TurnoId,
                TurmaId = MovimentoEstoque.TurmaId,
                Quantidade = MovimentoEstoque.Quantidade,
                MOV_PESO_UNITARIO = MovimentoEstoque.MOV_PESO_UNITARIO,
                DataHoraCriacao = MovimentoEstoque.DataHoraCriacao,
                DataHoraEmissao = MovimentoEstoque.DataHoraEmissao,
                DiaTurma = MovimentoEstoque.DiaTurma,
                Lote = MovimentoEstoque.Lote,
                SubLote = MovimentoEstoque.SubLote,
                MaquinaId = MovimentoEstoque.MaquinaId,
                USE_ID = MovimentoEstoque.USE_ID,
                Observacao = MovimentoEstoque.Observacao,
                OcorrenciaId = MovimentoEstoque.OcorrenciaId,
                Armazem = MovimentoEstoque.Armazem,
                Endereco = MovimentoEstoque.Endereco,
                Estorno = MovimentoEstoque.Estorno,
                SequenciaTransformacao = MovimentoEstoque.SequenciaTransformacao,
                SequenciaRepeticao = MovimentoEstoque.SequenciaRepeticao,
                ObsOpParcial = MovimentoEstoque.ObsOpParcial,
                OcoIdOpParcial = MovimentoEstoque.OcoIdOpParcial,
                MOV_ID_INTEGRACAO = MovimentoEstoque.MOV_ID_INTEGRACAO,
                MOV_ID_INTEGRACAO_ERP = MovimentoEstoque.MOV_ID_INTEGRACAO_ERP,
                CAR_ID = MovimentoEstoque.CAR_ID,
                MOV_ID_DESTINO = MovimentoEstoque.MOV_ID_DESTINO,
                PRO_ID_DESTINO = MovimentoEstoque.PRO_ID_DESTINO,
                MOV_LOTE_DESTINO = MovimentoEstoque.MOV_LOTE_DESTINO,
                MOV_SUB_LOTE_DESTINO = MovimentoEstoque.MOV_SUB_LOTE_DESTINO,
                MOV_ID_ORIGEM = MovimentoEstoque.MOV_ID_ORIGEM,
                PRO_ID_ORIGEM = MovimentoEstoque.PRO_ID_ORIGEM,
                MOV_LOTE_ORIGEM = MovimentoEstoque.MOV_LOTE_ORIGEM,
                MOV_SUB_LOTE_ORIGEM = MovimentoEstoque.MOV_SUB_LOTE_ORIGEM,
                MOV_TYPE = MovimentoEstoque.MOV_TYPE,
                MOV_DOC = MovimentoEstoque.MOV_DOC,
                MOV_APROVEITAMENTO = MovimentoEstoque.MOV_APROVEITAMENTO,
                MOV_RETIDO = MovimentoEstoque.MOV_RETIDO,
                MOV_VINCOS_ONDULADEIRA = MovimentoEstoque.MOV_VINCOS_ONDULADEIRA,
                BOL_ID = MovimentoEstoque.BOL_ID,
                ORD_ID_ORIGEM = MovimentoEstoque.ORD_ID_ORIGEM,
                COR_SEQUENCIA = MovimentoEstoque.COR_SEQUENCIA,
                VER_ID = MovimentoEstoque.VER_ID,
                MOV_TIPO_CUSTO = MovimentoEstoque.MOV_TIPO_CUSTO,
                MOV_GRUPO_CONTABIL = MovimentoEstoque.MOV_GRUPO_CONTABIL,
                FOR_ID = MovimentoEstoque.FOR_ID,
                CLI_ID = MovimentoEstoque.CLI_ID,
                Changed = MovimentoEstoque.Changed,
                UserId = _executionContext.UserId,
                Id = MovimentoEstoque.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProdutoId(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET ProdutoId = @ProdutoId WHERE Id = @Id ";
            this.Parameters = new
            {
                ProdutoId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOrderId(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET OrderId = @OrderId WHERE Id = @Id ";
            this.Parameters = new
            {
                OrderId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipo(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET Tipo = @Tipo WHERE Id = @Id ";
            this.Parameters = new
            {
                Tipo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTurnoId(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET TurnoId = @TurnoId WHERE Id = @Id ";
            this.Parameters = new
            {
                TurnoId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTurmaId(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET TurmaId = @TurmaId WHERE Id = @Id ";
            this.Parameters = new
            {
                TurmaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateQuantidade(int id, Decimal value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET Quantidade = @Quantidade WHERE Id = @Id ";
            this.Parameters = new
            {
                Quantidade = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_PESO_UNITARIO(int id, Decimal value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET MOV_PESO_UNITARIO = @MOV_PESO_UNITARIO WHERE Id = @Id ";
            this.Parameters = new
            {
                MOV_PESO_UNITARIO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataHoraCriacao(int id, DateTime value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET DataHoraCriacao = @DataHoraCriacao WHERE Id = @Id ";
            this.Parameters = new
            {
                DataHoraCriacao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataHoraEmissao(int id, DateTime value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET DataHoraEmissao = @DataHoraEmissao WHERE Id = @Id ";
            this.Parameters = new
            {
                DataHoraEmissao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDiaTurma(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET DiaTurma = @DiaTurma WHERE Id = @Id ";
            this.Parameters = new
            {
                DiaTurma = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateLote(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET Lote = @Lote WHERE Id = @Id ";
            this.Parameters = new
            {
                Lote = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSubLote(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET SubLote = @SubLote WHERE Id = @Id ";
            this.Parameters = new
            {
                SubLote = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMaquinaId(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET MaquinaId = @MaquinaId WHERE Id = @Id ";
            this.Parameters = new
            {
                MaquinaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSE_ID(int id, int value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET USE_ID = @USE_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                USE_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateObservacao(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET Observacao = @Observacao WHERE Id = @Id ";
            this.Parameters = new
            {
                Observacao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOcorrenciaId(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET OcorrenciaId = @OcorrenciaId WHERE Id = @Id ";
            this.Parameters = new
            {
                OcorrenciaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateArmazem(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET Armazem = @Armazem WHERE Id = @Id ";
            this.Parameters = new
            {
                Armazem = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEndereco(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET Endereco = @Endereco WHERE Id = @Id ";
            this.Parameters = new
            {
                Endereco = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEstorno(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET Estorno = @Estorno WHERE Id = @Id ";
            this.Parameters = new
            {
                Estorno = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSequenciaTransformacao(int id, int value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET SequenciaTransformacao = @SequenciaTransformacao WHERE Id = @Id ";
            this.Parameters = new
            {
                SequenciaTransformacao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSequenciaRepeticao(int id, int value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET SequenciaRepeticao = @SequenciaRepeticao WHERE Id = @Id ";
            this.Parameters = new
            {
                SequenciaRepeticao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateObsOpParcial(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET ObsOpParcial = @ObsOpParcial WHERE Id = @Id ";
            this.Parameters = new
            {
                ObsOpParcial = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOcoIdOpParcial(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET OcoIdOpParcial = @OcoIdOpParcial WHERE Id = @Id ";
            this.Parameters = new
            {
                OcoIdOpParcial = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_ID_INTEGRACAO(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET MOV_ID_INTEGRACAO = @MOV_ID_INTEGRACAO WHERE Id = @Id ";
            this.Parameters = new
            {
                MOV_ID_INTEGRACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_ID_INTEGRACAO_ERP(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET MOV_ID_INTEGRACAO_ERP = @MOV_ID_INTEGRACAO_ERP WHERE Id = @Id ";
            this.Parameters = new
            {
                MOV_ID_INTEGRACAO_ERP = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_ID(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET CAR_ID = @CAR_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_ID_DESTINO(int id, int value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET MOV_ID_DESTINO = @MOV_ID_DESTINO WHERE Id = @Id ";
            this.Parameters = new
            {
                MOV_ID_DESTINO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_DESTINO(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET PRO_ID_DESTINO = @PRO_ID_DESTINO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_DESTINO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_LOTE_DESTINO(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET MOV_LOTE_DESTINO = @MOV_LOTE_DESTINO WHERE Id = @Id ";
            this.Parameters = new
            {
                MOV_LOTE_DESTINO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_SUB_LOTE_DESTINO(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET MOV_SUB_LOTE_DESTINO = @MOV_SUB_LOTE_DESTINO WHERE Id = @Id ";
            this.Parameters = new
            {
                MOV_SUB_LOTE_DESTINO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_ID_ORIGEM(int id, int value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET MOV_ID_ORIGEM = @MOV_ID_ORIGEM WHERE Id = @Id ";
            this.Parameters = new
            {
                MOV_ID_ORIGEM = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_ORIGEM(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET PRO_ID_ORIGEM = @PRO_ID_ORIGEM WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_ORIGEM = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_LOTE_ORIGEM(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET MOV_LOTE_ORIGEM = @MOV_LOTE_ORIGEM WHERE Id = @Id ";
            this.Parameters = new
            {
                MOV_LOTE_ORIGEM = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_SUB_LOTE_ORIGEM(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET MOV_SUB_LOTE_ORIGEM = @MOV_SUB_LOTE_ORIGEM WHERE Id = @Id ";
            this.Parameters = new
            {
                MOV_SUB_LOTE_ORIGEM = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_TYPE(int id, int value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET MOV_TYPE = @MOV_TYPE WHERE Id = @Id ";
            this.Parameters = new
            {
                MOV_TYPE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_DOC(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET MOV_DOC = @MOV_DOC WHERE Id = @Id ";
            this.Parameters = new
            {
                MOV_DOC = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_APROVEITAMENTO(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET MOV_APROVEITAMENTO = @MOV_APROVEITAMENTO WHERE Id = @Id ";
            this.Parameters = new
            {
                MOV_APROVEITAMENTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_RETIDO(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET MOV_RETIDO = @MOV_RETIDO WHERE Id = @Id ";
            this.Parameters = new
            {
                MOV_RETIDO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_VINCOS_ONDULADEIRA(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET MOV_VINCOS_ONDULADEIRA = @MOV_VINCOS_ONDULADEIRA WHERE Id = @Id ";
            this.Parameters = new
            {
                MOV_VINCOS_ONDULADEIRA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_ID(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET BOL_ID = @BOL_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                BOL_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ID_ORIGEM(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET ORD_ID_ORIGEM = @ORD_ID_ORIGEM WHERE Id = @Id ";
            this.Parameters = new
            {
                ORD_ID_ORIGEM = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_SEQUENCIA(int id, int value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET COR_SEQUENCIA = @COR_SEQUENCIA WHERE Id = @Id ";
            this.Parameters = new
            {
                COR_SEQUENCIA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVER_ID(int id, int value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET VER_ID = @VER_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                VER_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_TIPO_CUSTO(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET MOV_TIPO_CUSTO = @MOV_TIPO_CUSTO WHERE Id = @Id ";
            this.Parameters = new
            {
                MOV_TIPO_CUSTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMOV_GRUPO_CONTABIL(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET MOV_GRUPO_CONTABIL = @MOV_GRUPO_CONTABIL WHERE Id = @Id ";
            this.Parameters = new
            {
                MOV_GRUPO_CONTABIL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFOR_ID(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET FOR_ID = @FOR_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                FOR_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_ID(int id, string value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET CLI_ID = @CLI_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                CLI_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE MovimentoEstoque SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMovimentoEstoqueQuery(IMovimentoEstoqueEntity MovimentoEstoque)
        {
            this.Query = $@" DELETE FROM MovimentoEstoque WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = MovimentoEstoque.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration