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
    public class CorridasOnduladeiraQueryWrite : QueryBase, ICorridasOnduladeiraQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CorridasOnduladeiraQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCorridasOnduladeiraQuery(ICorridasOnduladeiraEntity CorridasOnduladeira)
        {
            this.Query = $@" INSERT INTO [CorridasOnduladeira] ([BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA]) OUTPUT INSERTED.[COR_ID] VALUES(@BOL_ID, @BOL_ID_ORIGEM, @PRO_LARGURA_PECA, @PRO_LARGURA_PECA_PROGRAMADO, @PRO_COMPRIMENTO_PECA, @PRO_COMPRIMENTO_PECA_PROGRAMADO, @PRO_UTILIZOU_REFILE_OBRIGATORIO, @PRO_VINCOS_RECALCULADOS, @COR_SOLVER, @COR_GRAMATURA_PAPEIS_PROGRAMADOS, @COR_CUSTO_PAPEIS_PROGRAMADOS, @COR_GRAMATURA_RESINA_PROGRAMADOS, @COR_CUSTO_RESINA_PROGRAMADOS, @COR_TOLERANCIA_MENOS, @COR_TOLERANCIA_MAIS, @COR_PILHAS_POR_PALETE, @COR_COR_FILA, @COR_M_LINEAR_REALIZADO, @PRO_ID_PALETE, @COR_STATUS_PALETE, @COR_GRUPO_PRODUTIVO, @TenantID, @Deleted, @Changed, @UserId, @COR_STATUS, @COR_STATUS_INTERFACE, @MAQ_ID, @COR_ID_INTERFACE, @COR_SEQUENCIA, @COR_SEQUENCIA_ORIGEM, @ORD_ID, @FPR_SEQ_REPETICAO, @ROT_SEQ_TRANFORMACAO, @COR_FACAO, @COR_FORMATO_BOBINA, @COR_INICIO_PREVISTO, @COR_FIM_PREVISTO, @PRO_ID, @COR_QTD_PLANEJADO, @PRO_QTD_PACAS, @COR_PECAS_LARGURA) ";
            this.Parameters = new
            {
                BOL_ID = CorridasOnduladeira.BOL_ID,
                BOL_ID_ORIGEM = CorridasOnduladeira.BOL_ID_ORIGEM,
                PRO_LARGURA_PECA = CorridasOnduladeira.PRO_LARGURA_PECA,
                PRO_LARGURA_PECA_PROGRAMADO = CorridasOnduladeira.PRO_LARGURA_PECA_PROGRAMADO,
                PRO_COMPRIMENTO_PECA = CorridasOnduladeira.PRO_COMPRIMENTO_PECA,
                PRO_COMPRIMENTO_PECA_PROGRAMADO = CorridasOnduladeira.PRO_COMPRIMENTO_PECA_PROGRAMADO,
                PRO_UTILIZOU_REFILE_OBRIGATORIO = CorridasOnduladeira.PRO_UTILIZOU_REFILE_OBRIGATORIO,
                PRO_VINCOS_RECALCULADOS = CorridasOnduladeira.PRO_VINCOS_RECALCULADOS,
                COR_SOLVER = CorridasOnduladeira.COR_SOLVER,
                COR_GRAMATURA_PAPEIS_PROGRAMADOS = CorridasOnduladeira.COR_GRAMATURA_PAPEIS_PROGRAMADOS,
                COR_CUSTO_PAPEIS_PROGRAMADOS = CorridasOnduladeira.COR_CUSTO_PAPEIS_PROGRAMADOS,
                COR_GRAMATURA_RESINA_PROGRAMADOS = CorridasOnduladeira.COR_GRAMATURA_RESINA_PROGRAMADOS,
                COR_CUSTO_RESINA_PROGRAMADOS = CorridasOnduladeira.COR_CUSTO_RESINA_PROGRAMADOS,
                COR_TOLERANCIA_MENOS = CorridasOnduladeira.COR_TOLERANCIA_MENOS,
                COR_TOLERANCIA_MAIS = CorridasOnduladeira.COR_TOLERANCIA_MAIS,
                COR_PILHAS_POR_PALETE = CorridasOnduladeira.COR_PILHAS_POR_PALETE,
                COR_COR_FILA = CorridasOnduladeira.COR_COR_FILA,
                COR_M_LINEAR_REALIZADO = CorridasOnduladeira.COR_M_LINEAR_REALIZADO,
                PRO_ID_PALETE = CorridasOnduladeira.PRO_ID_PALETE,
                COR_STATUS_PALETE = CorridasOnduladeira.COR_STATUS_PALETE,
                COR_GRUPO_PRODUTIVO = CorridasOnduladeira.COR_GRUPO_PRODUTIVO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
                COR_STATUS = CorridasOnduladeira.COR_STATUS,
                COR_STATUS_INTERFACE = CorridasOnduladeira.COR_STATUS_INTERFACE,
                MAQ_ID = CorridasOnduladeira.MAQ_ID,
                COR_ID_INTERFACE = CorridasOnduladeira.COR_ID_INTERFACE,
                COR_SEQUENCIA = CorridasOnduladeira.COR_SEQUENCIA,
                COR_SEQUENCIA_ORIGEM = CorridasOnduladeira.COR_SEQUENCIA_ORIGEM,
                ORD_ID = CorridasOnduladeira.ORD_ID,
                FPR_SEQ_REPETICAO = CorridasOnduladeira.FPR_SEQ_REPETICAO,
                ROT_SEQ_TRANFORMACAO = CorridasOnduladeira.ROT_SEQ_TRANFORMACAO,
                COR_FACAO = CorridasOnduladeira.COR_FACAO,
                COR_FORMATO_BOBINA = CorridasOnduladeira.COR_FORMATO_BOBINA,
                COR_INICIO_PREVISTO = CorridasOnduladeira.COR_INICIO_PREVISTO,
                COR_FIM_PREVISTO = CorridasOnduladeira.COR_FIM_PREVISTO,
                PRO_ID = CorridasOnduladeira.PRO_ID,
                COR_QTD_PLANEJADO = CorridasOnduladeira.COR_QTD_PLANEJADO,
                PRO_QTD_PACAS = CorridasOnduladeira.PRO_QTD_PACAS,
                COR_PECAS_LARGURA = CorridasOnduladeira.COR_PECAS_LARGURA,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorridasOnduladeiraQuery(ICorridasOnduladeiraEntity CorridasOnduladeira)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [BOL_ID] = @BOL_ID, [BOL_ID_ORIGEM] = @BOL_ID_ORIGEM, [PRO_LARGURA_PECA] = @PRO_LARGURA_PECA, [PRO_LARGURA_PECA_PROGRAMADO] = @PRO_LARGURA_PECA_PROGRAMADO, [PRO_COMPRIMENTO_PECA] = @PRO_COMPRIMENTO_PECA, [PRO_COMPRIMENTO_PECA_PROGRAMADO] = @PRO_COMPRIMENTO_PECA_PROGRAMADO, [PRO_UTILIZOU_REFILE_OBRIGATORIO] = @PRO_UTILIZOU_REFILE_OBRIGATORIO, [PRO_VINCOS_RECALCULADOS] = @PRO_VINCOS_RECALCULADOS, [COR_SOLVER] = @COR_SOLVER, [COR_GRAMATURA_PAPEIS_PROGRAMADOS] = @COR_GRAMATURA_PAPEIS_PROGRAMADOS, [COR_CUSTO_PAPEIS_PROGRAMADOS] = @COR_CUSTO_PAPEIS_PROGRAMADOS, [COR_GRAMATURA_RESINA_PROGRAMADOS] = @COR_GRAMATURA_RESINA_PROGRAMADOS, [COR_CUSTO_RESINA_PROGRAMADOS] = @COR_CUSTO_RESINA_PROGRAMADOS, [COR_TOLERANCIA_MENOS] = @COR_TOLERANCIA_MENOS, [COR_TOLERANCIA_MAIS] = @COR_TOLERANCIA_MAIS, [COR_PILHAS_POR_PALETE] = @COR_PILHAS_POR_PALETE, [COR_COR_FILA] = @COR_COR_FILA, [COR_M_LINEAR_REALIZADO] = @COR_M_LINEAR_REALIZADO, [PRO_ID_PALETE] = @PRO_ID_PALETE, [COR_STATUS_PALETE] = @COR_STATUS_PALETE, [COR_GRUPO_PRODUTIVO] = @COR_GRUPO_PRODUTIVO, [Changed] = @Changed, [UserId] = @UserId, [COR_STATUS] = @COR_STATUS, [COR_STATUS_INTERFACE] = @COR_STATUS_INTERFACE, [MAQ_ID] = @MAQ_ID, [COR_ID_INTERFACE] = @COR_ID_INTERFACE, [COR_SEQUENCIA] = @COR_SEQUENCIA, [COR_SEQUENCIA_ORIGEM] = @COR_SEQUENCIA_ORIGEM, [ORD_ID] = @ORD_ID, [FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO, [ROT_SEQ_TRANFORMACAO] = @ROT_SEQ_TRANFORMACAO, [COR_FACAO] = @COR_FACAO, [COR_FORMATO_BOBINA] = @COR_FORMATO_BOBINA, [COR_INICIO_PREVISTO] = @COR_INICIO_PREVISTO, [COR_FIM_PREVISTO] = @COR_FIM_PREVISTO, [PRO_ID] = @PRO_ID, [COR_QTD_PLANEJADO] = @COR_QTD_PLANEJADO, [PRO_QTD_PACAS] = @PRO_QTD_PACAS, [COR_PECAS_LARGURA] = @COR_PECAS_LARGURA WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                BOL_ID = CorridasOnduladeira.BOL_ID,
                BOL_ID_ORIGEM = CorridasOnduladeira.BOL_ID_ORIGEM,
                PRO_LARGURA_PECA = CorridasOnduladeira.PRO_LARGURA_PECA,
                PRO_LARGURA_PECA_PROGRAMADO = CorridasOnduladeira.PRO_LARGURA_PECA_PROGRAMADO,
                PRO_COMPRIMENTO_PECA = CorridasOnduladeira.PRO_COMPRIMENTO_PECA,
                PRO_COMPRIMENTO_PECA_PROGRAMADO = CorridasOnduladeira.PRO_COMPRIMENTO_PECA_PROGRAMADO,
                PRO_UTILIZOU_REFILE_OBRIGATORIO = CorridasOnduladeira.PRO_UTILIZOU_REFILE_OBRIGATORIO,
                PRO_VINCOS_RECALCULADOS = CorridasOnduladeira.PRO_VINCOS_RECALCULADOS,
                COR_SOLVER = CorridasOnduladeira.COR_SOLVER,
                COR_GRAMATURA_PAPEIS_PROGRAMADOS = CorridasOnduladeira.COR_GRAMATURA_PAPEIS_PROGRAMADOS,
                COR_CUSTO_PAPEIS_PROGRAMADOS = CorridasOnduladeira.COR_CUSTO_PAPEIS_PROGRAMADOS,
                COR_GRAMATURA_RESINA_PROGRAMADOS = CorridasOnduladeira.COR_GRAMATURA_RESINA_PROGRAMADOS,
                COR_CUSTO_RESINA_PROGRAMADOS = CorridasOnduladeira.COR_CUSTO_RESINA_PROGRAMADOS,
                COR_TOLERANCIA_MENOS = CorridasOnduladeira.COR_TOLERANCIA_MENOS,
                COR_TOLERANCIA_MAIS = CorridasOnduladeira.COR_TOLERANCIA_MAIS,
                COR_PILHAS_POR_PALETE = CorridasOnduladeira.COR_PILHAS_POR_PALETE,
                COR_COR_FILA = CorridasOnduladeira.COR_COR_FILA,
                COR_M_LINEAR_REALIZADO = CorridasOnduladeira.COR_M_LINEAR_REALIZADO,
                PRO_ID_PALETE = CorridasOnduladeira.PRO_ID_PALETE,
                COR_STATUS_PALETE = CorridasOnduladeira.COR_STATUS_PALETE,
                COR_GRUPO_PRODUTIVO = CorridasOnduladeira.COR_GRUPO_PRODUTIVO,
                Changed = CorridasOnduladeira.Changed,
                UserId = _executionContext.UserId,
                COR_STATUS = CorridasOnduladeira.COR_STATUS,
                COR_STATUS_INTERFACE = CorridasOnduladeira.COR_STATUS_INTERFACE,
                MAQ_ID = CorridasOnduladeira.MAQ_ID,
                COR_ID_INTERFACE = CorridasOnduladeira.COR_ID_INTERFACE,
                COR_SEQUENCIA = CorridasOnduladeira.COR_SEQUENCIA,
                COR_SEQUENCIA_ORIGEM = CorridasOnduladeira.COR_SEQUENCIA_ORIGEM,
                ORD_ID = CorridasOnduladeira.ORD_ID,
                FPR_SEQ_REPETICAO = CorridasOnduladeira.FPR_SEQ_REPETICAO,
                ROT_SEQ_TRANFORMACAO = CorridasOnduladeira.ROT_SEQ_TRANFORMACAO,
                COR_FACAO = CorridasOnduladeira.COR_FACAO,
                COR_FORMATO_BOBINA = CorridasOnduladeira.COR_FORMATO_BOBINA,
                COR_INICIO_PREVISTO = CorridasOnduladeira.COR_INICIO_PREVISTO,
                COR_FIM_PREVISTO = CorridasOnduladeira.COR_FIM_PREVISTO,
                PRO_ID = CorridasOnduladeira.PRO_ID,
                COR_QTD_PLANEJADO = CorridasOnduladeira.COR_QTD_PLANEJADO,
                PRO_QTD_PACAS = CorridasOnduladeira.PRO_QTD_PACAS,
                COR_PECAS_LARGURA = CorridasOnduladeira.COR_PECAS_LARGURA,
                COR_ID = CorridasOnduladeira.COR_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_ID(int cor_id, string value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [BOL_ID] = @BOL_ID WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                BOL_ID = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_ID_ORIGEM(int cor_id, string value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [BOL_ID_ORIGEM] = @BOL_ID_ORIGEM WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                BOL_ID_ORIGEM = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_LARGURA_PECA(int cor_id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [PRO_LARGURA_PECA] = @PRO_LARGURA_PECA WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                PRO_LARGURA_PECA = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_LARGURA_PECA_PROGRAMADO(int cor_id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [PRO_LARGURA_PECA_PROGRAMADO] = @PRO_LARGURA_PECA_PROGRAMADO WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                PRO_LARGURA_PECA_PROGRAMADO = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_COMPRIMENTO_PECA(int cor_id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [PRO_COMPRIMENTO_PECA] = @PRO_COMPRIMENTO_PECA WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                PRO_COMPRIMENTO_PECA = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_COMPRIMENTO_PECA_PROGRAMADO(int cor_id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [PRO_COMPRIMENTO_PECA_PROGRAMADO] = @PRO_COMPRIMENTO_PECA_PROGRAMADO WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                PRO_COMPRIMENTO_PECA_PROGRAMADO = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_UTILIZOU_REFILE_OBRIGATORIO(int cor_id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [PRO_UTILIZOU_REFILE_OBRIGATORIO] = @PRO_UTILIZOU_REFILE_OBRIGATORIO WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                PRO_UTILIZOU_REFILE_OBRIGATORIO = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_VINCOS_RECALCULADOS(int cor_id, string value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [PRO_VINCOS_RECALCULADOS] = @PRO_VINCOS_RECALCULADOS WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                PRO_VINCOS_RECALCULADOS = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_SOLVER(int cor_id, string value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_SOLVER] = @COR_SOLVER WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_SOLVER = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_GRAMATURA_PAPEIS_PROGRAMADOS(int cor_id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_GRAMATURA_PAPEIS_PROGRAMADOS] = @COR_GRAMATURA_PAPEIS_PROGRAMADOS WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_GRAMATURA_PAPEIS_PROGRAMADOS = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_CUSTO_PAPEIS_PROGRAMADOS(int cor_id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_CUSTO_PAPEIS_PROGRAMADOS] = @COR_CUSTO_PAPEIS_PROGRAMADOS WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_CUSTO_PAPEIS_PROGRAMADOS = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_GRAMATURA_RESINA_PROGRAMADOS(int cor_id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_GRAMATURA_RESINA_PROGRAMADOS] = @COR_GRAMATURA_RESINA_PROGRAMADOS WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_GRAMATURA_RESINA_PROGRAMADOS = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_CUSTO_RESINA_PROGRAMADOS(int cor_id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_CUSTO_RESINA_PROGRAMADOS] = @COR_CUSTO_RESINA_PROGRAMADOS WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_CUSTO_RESINA_PROGRAMADOS = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_TOLERANCIA_MENOS(int cor_id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_TOLERANCIA_MENOS] = @COR_TOLERANCIA_MENOS WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_TOLERANCIA_MENOS = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_TOLERANCIA_MAIS(int cor_id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_TOLERANCIA_MAIS] = @COR_TOLERANCIA_MAIS WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_TOLERANCIA_MAIS = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_PILHAS_POR_PALETE(int cor_id, int value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_PILHAS_POR_PALETE] = @COR_PILHAS_POR_PALETE WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_PILHAS_POR_PALETE = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_COR_FILA(int cor_id, string value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_COR_FILA] = @COR_COR_FILA WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_COR_FILA = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_M_LINEAR_REALIZADO(int cor_id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_M_LINEAR_REALIZADO] = @COR_M_LINEAR_REALIZADO WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_M_LINEAR_REALIZADO = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_PALETE(int cor_id, string value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [PRO_ID_PALETE] = @PRO_ID_PALETE WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                PRO_ID_PALETE = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_STATUS_PALETE(int cor_id, string value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_STATUS_PALETE] = @COR_STATUS_PALETE WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_STATUS_PALETE = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_GRUPO_PRODUTIVO(int cor_id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_GRUPO_PRODUTIVO] = @COR_GRUPO_PRODUTIVO WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_GRUPO_PRODUTIVO = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int cor_id, int value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [TenantID] = @TenantID WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                TenantID = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int cor_id, bool value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [Deleted] = @Deleted WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                Deleted = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int cor_id, DateTime value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [Changed] = @Changed WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                Changed = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int cor_id, int value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [UserId] = @UserId WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                UserId = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_STATUS(int cor_id, string value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_STATUS] = @COR_STATUS WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_STATUS = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_STATUS_INTERFACE(int cor_id, string value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_STATUS_INTERFACE] = @COR_STATUS_INTERFACE WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_STATUS_INTERFACE = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ID(int cor_id, string value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [MAQ_ID] = @MAQ_ID WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                MAQ_ID = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_ID_INTERFACE(int cor_id, int value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_ID_INTERFACE] = @COR_ID_INTERFACE WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_ID_INTERFACE = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_SEQUENCIA(int cor_id, int value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_SEQUENCIA] = @COR_SEQUENCIA WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_SEQUENCIA = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_SEQUENCIA_ORIGEM(int cor_id, int value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_SEQUENCIA_ORIGEM] = @COR_SEQUENCIA_ORIGEM WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_SEQUENCIA_ORIGEM = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ID(int cor_id, string value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [ORD_ID] = @ORD_ID WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                ORD_ID = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_SEQ_REPETICAO(int cor_id, int value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                FPR_SEQ_REPETICAO = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_SEQ_TRANFORMACAO(int cor_id, int value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [ROT_SEQ_TRANFORMACAO] = @ROT_SEQ_TRANFORMACAO WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                ROT_SEQ_TRANFORMACAO = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_FACAO(int cor_id, int value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_FACAO] = @COR_FACAO WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_FACAO = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_FORMATO_BOBINA(int cor_id, int value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_FORMATO_BOBINA] = @COR_FORMATO_BOBINA WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_FORMATO_BOBINA = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_INICIO_PREVISTO(int cor_id, DateTime value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_INICIO_PREVISTO] = @COR_INICIO_PREVISTO WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_INICIO_PREVISTO = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_FIM_PREVISTO(int cor_id, DateTime value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_FIM_PREVISTO] = @COR_FIM_PREVISTO WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_FIM_PREVISTO = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID(int cor_id, string value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [PRO_ID] = @PRO_ID WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                PRO_ID = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_QTD_PLANEJADO(int cor_id, int value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_QTD_PLANEJADO] = @COR_QTD_PLANEJADO WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_QTD_PLANEJADO = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_QTD_PACAS(int cor_id, int value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [PRO_QTD_PACAS] = @PRO_QTD_PACAS WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                PRO_QTD_PACAS = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_PECAS_LARGURA(int cor_id, int value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeira] SET [COR_PECAS_LARGURA] = @COR_PECAS_LARGURA WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_PECAS_LARGURA = value,
                COR_ID = cor_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCorridasOnduladeiraQuery(ICorridasOnduladeiraEntity CorridasOnduladeira)
        {
            this.Query = $@" DELETE FROM [CorridasOnduladeira] WHERE [COR_ID] = @COR_ID ";
            this.Parameters = new
            {
                COR_ID = CorridasOnduladeira.COR_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration