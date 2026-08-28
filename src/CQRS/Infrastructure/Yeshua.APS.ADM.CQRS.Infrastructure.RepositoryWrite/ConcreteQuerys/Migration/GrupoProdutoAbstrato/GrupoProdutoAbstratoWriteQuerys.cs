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
    public class GrupoProdutoAbstratoQueryWrite : QueryBase, IGrupoProdutoAbstratoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public GrupoProdutoAbstratoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirGrupoProdutoAbstratoQuery(IGrupoProdutoAbstratoEntity GrupoProdutoAbstrato)
        {
            this.Query = $@" INSERT INTO GrupoProdutoAbstrato (GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId) VALUES(@GRP_ID, @GRP_DESCRICAO, @TEM_ID, @GRP_TIPO, @GRP_PAP_ONDA, @GRP_PAP_GRAMATURA, @GRP_PAP_ALTURA, @GRP_PAP_NOME_COMERCIAL, @GRP_ATIVO, @GRP_DT_CRIACAO, @GRP_PAPEL1, @GRP_PAPEL2, @GRP_PAPEL3, @GRP_PAPEL4, @GRP_PAPEL5, @GRP_ID_INTEGRACAO, @GRP_ID_INTEGRACAO_ERP, @GRP_TYPE, @GRP_PERFORMANCE, @GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, @GRP_RESINA, @GRP_ENDURECEDOR_MIOLO, @VIN_ID, @GRP_COLUNA_DE, @GRP_COLUNA_ATE, @GRP_CRUSH, @GRP_ID_FAMILIA, @GRP_REFILE_LARGURA, @GRP_REFILE_COMPRIMENTO, @GRP_TIPO_LAP, @GRP_LAP_PROLONGADO, @GRP_TAMANHO_LAP_OND_SIMPLES, @GRP_TAMANHO_LAP_OND_DUPLA, @GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, @GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, @GRP_FEFCO, @GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, @GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, @GRP_PREFIXO_ID_PRODUTO, @GRP_COLUNA_CAIXA, @GRP_COLUNA_CHAPA, @GRP_MULLEN, @GRP_TENDENCIA_TOLERANCIA_PEDIDO, @GRP_PERCENTUAL_PERDA_MEDIA, @GRP_FILTRA_SEQ_TRANS, @GRP_IMG_CAIXA, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                GRP_ID = GrupoProdutoAbstrato.GRP_ID,
                GRP_DESCRICAO = GrupoProdutoAbstrato.GRP_DESCRICAO,
                TEM_ID = GrupoProdutoAbstrato.TEM_ID,
                GRP_TIPO = GrupoProdutoAbstrato.GRP_TIPO,
                GRP_PAP_ONDA = GrupoProdutoAbstrato.GRP_PAP_ONDA,
                GRP_PAP_GRAMATURA = GrupoProdutoAbstrato.GRP_PAP_GRAMATURA,
                GRP_PAP_ALTURA = GrupoProdutoAbstrato.GRP_PAP_ALTURA,
                GRP_PAP_NOME_COMERCIAL = GrupoProdutoAbstrato.GRP_PAP_NOME_COMERCIAL,
                GRP_ATIVO = GrupoProdutoAbstrato.GRP_ATIVO,
                GRP_DT_CRIACAO = GrupoProdutoAbstrato.GRP_DT_CRIACAO,
                GRP_PAPEL1 = GrupoProdutoAbstrato.GRP_PAPEL1,
                GRP_PAPEL2 = GrupoProdutoAbstrato.GRP_PAPEL2,
                GRP_PAPEL3 = GrupoProdutoAbstrato.GRP_PAPEL3,
                GRP_PAPEL4 = GrupoProdutoAbstrato.GRP_PAPEL4,
                GRP_PAPEL5 = GrupoProdutoAbstrato.GRP_PAPEL5,
                GRP_ID_INTEGRACAO = GrupoProdutoAbstrato.GRP_ID_INTEGRACAO,
                GRP_ID_INTEGRACAO_ERP = GrupoProdutoAbstrato.GRP_ID_INTEGRACAO_ERP,
                GRP_TYPE = GrupoProdutoAbstrato.GRP_TYPE,
                GRP_PERFORMANCE = GrupoProdutoAbstrato.GRP_PERFORMANCE,
                GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO = GrupoProdutoAbstrato.GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO,
                GRP_RESINA = GrupoProdutoAbstrato.GRP_RESINA,
                GRP_ENDURECEDOR_MIOLO = GrupoProdutoAbstrato.GRP_ENDURECEDOR_MIOLO,
                VIN_ID = GrupoProdutoAbstrato.VIN_ID,
                GRP_COLUNA_DE = GrupoProdutoAbstrato.GRP_COLUNA_DE,
                GRP_COLUNA_ATE = GrupoProdutoAbstrato.GRP_COLUNA_ATE,
                GRP_CRUSH = GrupoProdutoAbstrato.GRP_CRUSH,
                GRP_ID_FAMILIA = GrupoProdutoAbstrato.GRP_ID_FAMILIA,
                GRP_REFILE_LARGURA = GrupoProdutoAbstrato.GRP_REFILE_LARGURA,
                GRP_REFILE_COMPRIMENTO = GrupoProdutoAbstrato.GRP_REFILE_COMPRIMENTO,
                GRP_TIPO_LAP = GrupoProdutoAbstrato.GRP_TIPO_LAP,
                GRP_LAP_PROLONGADO = GrupoProdutoAbstrato.GRP_LAP_PROLONGADO,
                GRP_TAMANHO_LAP_OND_SIMPLES = GrupoProdutoAbstrato.GRP_TAMANHO_LAP_OND_SIMPLES,
                GRP_TAMANHO_LAP_OND_DUPLA = GrupoProdutoAbstrato.GRP_TAMANHO_LAP_OND_DUPLA,
                GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES = GrupoProdutoAbstrato.GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES,
                GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA = GrupoProdutoAbstrato.GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA,
                GRP_FEFCO = GrupoProdutoAbstrato.GRP_FEFCO,
                GRP_TOLERANCIA_DIMENCAO_CHAPA_DE = GrupoProdutoAbstrato.GRP_TOLERANCIA_DIMENCAO_CHAPA_DE,
                GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE = GrupoProdutoAbstrato.GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE,
                GRP_PREFIXO_ID_PRODUTO = GrupoProdutoAbstrato.GRP_PREFIXO_ID_PRODUTO,
                GRP_COLUNA_CAIXA = GrupoProdutoAbstrato.GRP_COLUNA_CAIXA,
                GRP_COLUNA_CHAPA = GrupoProdutoAbstrato.GRP_COLUNA_CHAPA,
                GRP_MULLEN = GrupoProdutoAbstrato.GRP_MULLEN,
                GRP_TENDENCIA_TOLERANCIA_PEDIDO = GrupoProdutoAbstrato.GRP_TENDENCIA_TOLERANCIA_PEDIDO,
                GRP_PERCENTUAL_PERDA_MEDIA = GrupoProdutoAbstrato.GRP_PERCENTUAL_PERDA_MEDIA,
                GRP_FILTRA_SEQ_TRANS = GrupoProdutoAbstrato.GRP_FILTRA_SEQ_TRANS,
                GRP_IMG_CAIXA = GrupoProdutoAbstrato.GRP_IMG_CAIXA,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrupoProdutoAbstratoQuery(IGrupoProdutoAbstratoEntity GrupoProdutoAbstrato)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_DESCRICAO = @GRP_DESCRICAO, TEM_ID = @TEM_ID, GRP_TIPO = @GRP_TIPO, GRP_PAP_ONDA = @GRP_PAP_ONDA, GRP_PAP_GRAMATURA = @GRP_PAP_GRAMATURA, GRP_PAP_ALTURA = @GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL = @GRP_PAP_NOME_COMERCIAL, GRP_ATIVO = @GRP_ATIVO, GRP_DT_CRIACAO = @GRP_DT_CRIACAO, GRP_PAPEL1 = @GRP_PAPEL1, GRP_PAPEL2 = @GRP_PAPEL2, GRP_PAPEL3 = @GRP_PAPEL3, GRP_PAPEL4 = @GRP_PAPEL4, GRP_PAPEL5 = @GRP_PAPEL5, GRP_ID_INTEGRACAO = @GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP = @GRP_ID_INTEGRACAO_ERP, GRP_TYPE = @GRP_TYPE, GRP_PERFORMANCE = @GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO = @GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA = @GRP_RESINA, GRP_ENDURECEDOR_MIOLO = @GRP_ENDURECEDOR_MIOLO, VIN_ID = @VIN_ID, GRP_COLUNA_DE = @GRP_COLUNA_DE, GRP_COLUNA_ATE = @GRP_COLUNA_ATE, GRP_CRUSH = @GRP_CRUSH, GRP_ID_FAMILIA = @GRP_ID_FAMILIA, GRP_REFILE_LARGURA = @GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO = @GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP = @GRP_TIPO_LAP, GRP_LAP_PROLONGADO = @GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES = @GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA = @GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES = @GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA = @GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO = @GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE = @GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE = @GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO = @GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA = @GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA = @GRP_COLUNA_CHAPA, GRP_MULLEN = @GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO = @GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA = @GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS = @GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA = @GRP_IMG_CAIXA, Changed = @Changed, UserId = @UserId WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_DESCRICAO = GrupoProdutoAbstrato.GRP_DESCRICAO,
                TEM_ID = GrupoProdutoAbstrato.TEM_ID,
                GRP_TIPO = GrupoProdutoAbstrato.GRP_TIPO,
                GRP_PAP_ONDA = GrupoProdutoAbstrato.GRP_PAP_ONDA,
                GRP_PAP_GRAMATURA = GrupoProdutoAbstrato.GRP_PAP_GRAMATURA,
                GRP_PAP_ALTURA = GrupoProdutoAbstrato.GRP_PAP_ALTURA,
                GRP_PAP_NOME_COMERCIAL = GrupoProdutoAbstrato.GRP_PAP_NOME_COMERCIAL,
                GRP_ATIVO = GrupoProdutoAbstrato.GRP_ATIVO,
                GRP_DT_CRIACAO = GrupoProdutoAbstrato.GRP_DT_CRIACAO,
                GRP_PAPEL1 = GrupoProdutoAbstrato.GRP_PAPEL1,
                GRP_PAPEL2 = GrupoProdutoAbstrato.GRP_PAPEL2,
                GRP_PAPEL3 = GrupoProdutoAbstrato.GRP_PAPEL3,
                GRP_PAPEL4 = GrupoProdutoAbstrato.GRP_PAPEL4,
                GRP_PAPEL5 = GrupoProdutoAbstrato.GRP_PAPEL5,
                GRP_ID_INTEGRACAO = GrupoProdutoAbstrato.GRP_ID_INTEGRACAO,
                GRP_ID_INTEGRACAO_ERP = GrupoProdutoAbstrato.GRP_ID_INTEGRACAO_ERP,
                GRP_TYPE = GrupoProdutoAbstrato.GRP_TYPE,
                GRP_PERFORMANCE = GrupoProdutoAbstrato.GRP_PERFORMANCE,
                GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO = GrupoProdutoAbstrato.GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO,
                GRP_RESINA = GrupoProdutoAbstrato.GRP_RESINA,
                GRP_ENDURECEDOR_MIOLO = GrupoProdutoAbstrato.GRP_ENDURECEDOR_MIOLO,
                VIN_ID = GrupoProdutoAbstrato.VIN_ID,
                GRP_COLUNA_DE = GrupoProdutoAbstrato.GRP_COLUNA_DE,
                GRP_COLUNA_ATE = GrupoProdutoAbstrato.GRP_COLUNA_ATE,
                GRP_CRUSH = GrupoProdutoAbstrato.GRP_CRUSH,
                GRP_ID_FAMILIA = GrupoProdutoAbstrato.GRP_ID_FAMILIA,
                GRP_REFILE_LARGURA = GrupoProdutoAbstrato.GRP_REFILE_LARGURA,
                GRP_REFILE_COMPRIMENTO = GrupoProdutoAbstrato.GRP_REFILE_COMPRIMENTO,
                GRP_TIPO_LAP = GrupoProdutoAbstrato.GRP_TIPO_LAP,
                GRP_LAP_PROLONGADO = GrupoProdutoAbstrato.GRP_LAP_PROLONGADO,
                GRP_TAMANHO_LAP_OND_SIMPLES = GrupoProdutoAbstrato.GRP_TAMANHO_LAP_OND_SIMPLES,
                GRP_TAMANHO_LAP_OND_DUPLA = GrupoProdutoAbstrato.GRP_TAMANHO_LAP_OND_DUPLA,
                GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES = GrupoProdutoAbstrato.GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES,
                GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA = GrupoProdutoAbstrato.GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA,
                GRP_FEFCO = GrupoProdutoAbstrato.GRP_FEFCO,
                GRP_TOLERANCIA_DIMENCAO_CHAPA_DE = GrupoProdutoAbstrato.GRP_TOLERANCIA_DIMENCAO_CHAPA_DE,
                GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE = GrupoProdutoAbstrato.GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE,
                GRP_PREFIXO_ID_PRODUTO = GrupoProdutoAbstrato.GRP_PREFIXO_ID_PRODUTO,
                GRP_COLUNA_CAIXA = GrupoProdutoAbstrato.GRP_COLUNA_CAIXA,
                GRP_COLUNA_CHAPA = GrupoProdutoAbstrato.GRP_COLUNA_CHAPA,
                GRP_MULLEN = GrupoProdutoAbstrato.GRP_MULLEN,
                GRP_TENDENCIA_TOLERANCIA_PEDIDO = GrupoProdutoAbstrato.GRP_TENDENCIA_TOLERANCIA_PEDIDO,
                GRP_PERCENTUAL_PERDA_MEDIA = GrupoProdutoAbstrato.GRP_PERCENTUAL_PERDA_MEDIA,
                GRP_FILTRA_SEQ_TRANS = GrupoProdutoAbstrato.GRP_FILTRA_SEQ_TRANS,
                GRP_IMG_CAIXA = GrupoProdutoAbstrato.GRP_IMG_CAIXA,
                Changed = GrupoProdutoAbstrato.Changed,
                UserId = _executionContext.UserId,
                GRP_ID = GrupoProdutoAbstrato.GRP_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_DESCRICAO(string grp_id, string value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_DESCRICAO = @GRP_DESCRICAO WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_DESCRICAO = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTEM_ID(string grp_id, int value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET TEM_ID = @TEM_ID WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                TEM_ID = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_TIPO(string grp_id, Decimal value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_TIPO = @GRP_TIPO WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_TIPO = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAP_ONDA(string grp_id, string value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_PAP_ONDA = @GRP_PAP_ONDA WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_PAP_ONDA = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAP_GRAMATURA(string grp_id, Decimal value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_PAP_GRAMATURA = @GRP_PAP_GRAMATURA WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_PAP_GRAMATURA = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAP_ALTURA(string grp_id, Decimal value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_PAP_ALTURA = @GRP_PAP_ALTURA WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_PAP_ALTURA = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAP_NOME_COMERCIAL(string grp_id, string value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_PAP_NOME_COMERCIAL = @GRP_PAP_NOME_COMERCIAL WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_PAP_NOME_COMERCIAL = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_ATIVO(string grp_id, string value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_ATIVO = @GRP_ATIVO WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_ATIVO = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_DT_CRIACAO(string grp_id, DateTime value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_DT_CRIACAO = @GRP_DT_CRIACAO WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_DT_CRIACAO = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAPEL1(string grp_id, string value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_PAPEL1 = @GRP_PAPEL1 WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_PAPEL1 = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAPEL2(string grp_id, string value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_PAPEL2 = @GRP_PAPEL2 WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_PAPEL2 = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAPEL3(string grp_id, string value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_PAPEL3 = @GRP_PAPEL3 WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_PAPEL3 = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAPEL4(string grp_id, string value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_PAPEL4 = @GRP_PAPEL4 WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_PAPEL4 = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAPEL5(string grp_id, string value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_PAPEL5 = @GRP_PAPEL5 WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_PAPEL5 = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_ID_INTEGRACAO(string grp_id, string value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_ID_INTEGRACAO = @GRP_ID_INTEGRACAO WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_ID_INTEGRACAO = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_ID_INTEGRACAO_ERP(string grp_id, string value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_ID_INTEGRACAO_ERP = @GRP_ID_INTEGRACAO_ERP WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_ID_INTEGRACAO_ERP = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_TYPE(string grp_id, int value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_TYPE = @GRP_TYPE WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_TYPE = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PERFORMANCE(string grp_id, Decimal value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_PERFORMANCE = @GRP_PERFORMANCE WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_PERFORMANCE = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO(string grp_id, Decimal value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO = @GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_RESINA(string grp_id, string value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_RESINA = @GRP_RESINA WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_RESINA = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_ENDURECEDOR_MIOLO(string grp_id, string value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_ENDURECEDOR_MIOLO = @GRP_ENDURECEDOR_MIOLO WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_ENDURECEDOR_MIOLO = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVIN_ID(string grp_id, int value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET VIN_ID = @VIN_ID WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                VIN_ID = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_COLUNA_DE(string grp_id, Decimal value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_COLUNA_DE = @GRP_COLUNA_DE WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_COLUNA_DE = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_COLUNA_ATE(string grp_id, Decimal value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_COLUNA_ATE = @GRP_COLUNA_ATE WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_COLUNA_ATE = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_CRUSH(string grp_id, Decimal value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_CRUSH = @GRP_CRUSH WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_CRUSH = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_ID_FAMILIA(string grp_id, string value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_ID_FAMILIA = @GRP_ID_FAMILIA WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_ID_FAMILIA = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_REFILE_LARGURA(string grp_id, Decimal value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_REFILE_LARGURA = @GRP_REFILE_LARGURA WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_REFILE_LARGURA = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_REFILE_COMPRIMENTO(string grp_id, Decimal value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_REFILE_COMPRIMENTO = @GRP_REFILE_COMPRIMENTO WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_REFILE_COMPRIMENTO = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_TIPO_LAP(string grp_id, string value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_TIPO_LAP = @GRP_TIPO_LAP WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_TIPO_LAP = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_LAP_PROLONGADO(string grp_id, string value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_LAP_PROLONGADO = @GRP_LAP_PROLONGADO WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_LAP_PROLONGADO = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_TAMANHO_LAP_OND_SIMPLES(string grp_id, Decimal value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_TAMANHO_LAP_OND_SIMPLES = @GRP_TAMANHO_LAP_OND_SIMPLES WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_TAMANHO_LAP_OND_SIMPLES = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_TAMANHO_LAP_OND_DUPLA(string grp_id, Decimal value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_TAMANHO_LAP_OND_DUPLA = @GRP_TAMANHO_LAP_OND_DUPLA WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_TAMANHO_LAP_OND_DUPLA = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES(string grp_id, Decimal value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES = @GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA(string grp_id, Decimal value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA = @GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_FEFCO(string grp_id, string value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_FEFCO = @GRP_FEFCO WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_FEFCO = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_TOLERANCIA_DIMENCAO_CHAPA_DE(string grp_id, int value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_TOLERANCIA_DIMENCAO_CHAPA_DE = @GRP_TOLERANCIA_DIMENCAO_CHAPA_DE WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_TOLERANCIA_DIMENCAO_CHAPA_DE = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_TOLERANCIA_DIMENCAO_CHAPA_ATE(string grp_id, int value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE = @GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PREFIXO_ID_PRODUTO(string grp_id, string value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_PREFIXO_ID_PRODUTO = @GRP_PREFIXO_ID_PRODUTO WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_PREFIXO_ID_PRODUTO = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_COLUNA_CAIXA(string grp_id, Decimal value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_COLUNA_CAIXA = @GRP_COLUNA_CAIXA WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_COLUNA_CAIXA = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_COLUNA_CHAPA(string grp_id, Decimal value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_COLUNA_CHAPA = @GRP_COLUNA_CHAPA WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_COLUNA_CHAPA = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_MULLEN(string grp_id, Decimal value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_MULLEN = @GRP_MULLEN WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_MULLEN = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_TENDENCIA_TOLERANCIA_PEDIDO(string grp_id, int value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_TENDENCIA_TOLERANCIA_PEDIDO = @GRP_TENDENCIA_TOLERANCIA_PEDIDO WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_TENDENCIA_TOLERANCIA_PEDIDO = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PERCENTUAL_PERDA_MEDIA(string grp_id, Decimal value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_PERCENTUAL_PERDA_MEDIA = @GRP_PERCENTUAL_PERDA_MEDIA WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_PERCENTUAL_PERDA_MEDIA = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_FILTRA_SEQ_TRANS(string grp_id, int value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_FILTRA_SEQ_TRANS = @GRP_FILTRA_SEQ_TRANS WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_FILTRA_SEQ_TRANS = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_IMG_CAIXA(string grp_id, string value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET GRP_IMG_CAIXA = @GRP_IMG_CAIXA WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_IMG_CAIXA = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string grp_id, int value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET TenantID = @TenantID WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                TenantID = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string grp_id, bool value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET Deleted = @Deleted WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                Deleted = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string grp_id, DateTime value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET Changed = @Changed WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                Changed = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string grp_id, int value)
        {
            this.Query = $@" UPDATE GrupoProdutoAbstrato SET UserId = @UserId WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                UserId = value,
                GRP_ID = grp_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteGrupoProdutoAbstratoQuery(IGrupoProdutoAbstratoEntity GrupoProdutoAbstrato)
        {
            this.Query = $@" DELETE FROM GrupoProdutoAbstrato WHERE GRP_ID = @GRP_ID ";
            this.Parameters = new
            {
                GRP_ID = GrupoProdutoAbstrato.GRP_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration