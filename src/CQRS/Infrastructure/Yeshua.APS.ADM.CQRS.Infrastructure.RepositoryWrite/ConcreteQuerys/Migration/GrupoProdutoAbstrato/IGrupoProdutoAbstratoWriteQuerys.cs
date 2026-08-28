// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IGrupoProdutoAbstratoQueryWrite 
     {
        public QueryModel InserirGrupoProdutoAbstratoQuery(IGrupoProdutoAbstratoEntity GrupoProdutoAbstrato);
        public QueryModel UpdateGrupoProdutoAbstratoQuery(IGrupoProdutoAbstratoEntity GrupoProdutoAbstrato);
        QueryModel UpdateGRP_DESCRICAO(string grp_id, string value);
        QueryModel UpdateTEM_ID(string grp_id, int value);
        QueryModel UpdateGRP_TIPO(string grp_id, Decimal value);
        QueryModel UpdateGRP_PAP_ONDA(string grp_id, string value);
        QueryModel UpdateGRP_PAP_GRAMATURA(string grp_id, Decimal value);
        QueryModel UpdateGRP_PAP_ALTURA(string grp_id, Decimal value);
        QueryModel UpdateGRP_PAP_NOME_COMERCIAL(string grp_id, string value);
        QueryModel UpdateGRP_ATIVO(string grp_id, string value);
        QueryModel UpdateGRP_DT_CRIACAO(string grp_id, DateTime value);
        QueryModel UpdateGRP_PAPEL1(string grp_id, string value);
        QueryModel UpdateGRP_PAPEL2(string grp_id, string value);
        QueryModel UpdateGRP_PAPEL3(string grp_id, string value);
        QueryModel UpdateGRP_PAPEL4(string grp_id, string value);
        QueryModel UpdateGRP_PAPEL5(string grp_id, string value);
        QueryModel UpdateGRP_ID_INTEGRACAO(string grp_id, string value);
        QueryModel UpdateGRP_ID_INTEGRACAO_ERP(string grp_id, string value);
        QueryModel UpdateGRP_TYPE(string grp_id, int value);
        QueryModel UpdateGRP_PERFORMANCE(string grp_id, Decimal value);
        QueryModel UpdateGRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO(string grp_id, Decimal value);
        QueryModel UpdateGRP_RESINA(string grp_id, string value);
        QueryModel UpdateGRP_ENDURECEDOR_MIOLO(string grp_id, string value);
        QueryModel UpdateVIN_ID(string grp_id, int value);
        QueryModel UpdateGRP_COLUNA_DE(string grp_id, Decimal value);
        QueryModel UpdateGRP_COLUNA_ATE(string grp_id, Decimal value);
        QueryModel UpdateGRP_CRUSH(string grp_id, Decimal value);
        QueryModel UpdateGRP_ID_FAMILIA(string grp_id, string value);
        QueryModel UpdateGRP_REFILE_LARGURA(string grp_id, Decimal value);
        QueryModel UpdateGRP_REFILE_COMPRIMENTO(string grp_id, Decimal value);
        QueryModel UpdateGRP_TIPO_LAP(string grp_id, string value);
        QueryModel UpdateGRP_LAP_PROLONGADO(string grp_id, string value);
        QueryModel UpdateGRP_TAMANHO_LAP_OND_SIMPLES(string grp_id, Decimal value);
        QueryModel UpdateGRP_TAMANHO_LAP_OND_DUPLA(string grp_id, Decimal value);
        QueryModel UpdateGRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES(string grp_id, Decimal value);
        QueryModel UpdateGRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA(string grp_id, Decimal value);
        QueryModel UpdateGRP_FEFCO(string grp_id, string value);
        QueryModel UpdateGRP_TOLERANCIA_DIMENCAO_CHAPA_DE(string grp_id, int value);
        QueryModel UpdateGRP_TOLERANCIA_DIMENCAO_CHAPA_ATE(string grp_id, int value);
        QueryModel UpdateGRP_PREFIXO_ID_PRODUTO(string grp_id, string value);
        QueryModel UpdateGRP_COLUNA_CAIXA(string grp_id, Decimal value);
        QueryModel UpdateGRP_COLUNA_CHAPA(string grp_id, Decimal value);
        QueryModel UpdateGRP_MULLEN(string grp_id, Decimal value);
        QueryModel UpdateGRP_TENDENCIA_TOLERANCIA_PEDIDO(string grp_id, int value);
        QueryModel UpdateGRP_PERCENTUAL_PERDA_MEDIA(string grp_id, Decimal value);
        QueryModel UpdateGRP_FILTRA_SEQ_TRANS(string grp_id, int value);
        QueryModel UpdateGRP_IMG_CAIXA(string grp_id, string value);
        QueryModel UpdateTenantID(string grp_id, int value);
        QueryModel UpdateDeleted(string grp_id, bool value);
        QueryModel UpdateChanged(string grp_id, DateTime value);
        QueryModel UpdateUserId(string grp_id, int value);
        public QueryModel DeleteGrupoProdutoAbstratoQuery(IGrupoProdutoAbstratoEntity GrupoProdutoAbstrato);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration