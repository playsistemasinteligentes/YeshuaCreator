// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
// </yeshua>

using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IGrupoProdutoAbstratoWriteRepository
    {
        void Insert(IGrupoProdutoAbstratoEntity grupoprodutoabstrato);
        void Update(IGrupoProdutoAbstratoEntity grupoprodutoabstrato);
        void Delete(IGrupoProdutoAbstratoEntity grupoprodutoabstrato);
        void UpdateGRP_DESCRICAO(string grp_id, string value);
        void UpdateTEM_ID(string grp_id, int value);
        void UpdateGRP_TIPO(string grp_id, Decimal value);
        void UpdateGRP_PAP_ONDA(string grp_id, string value);
        void UpdateGRP_PAP_GRAMATURA(string grp_id, Decimal value);
        void UpdateGRP_PAP_ALTURA(string grp_id, Decimal value);
        void UpdateGRP_PAP_NOME_COMERCIAL(string grp_id, string value);
        void UpdateGRP_ATIVO(string grp_id, string value);
        void UpdateGRP_DT_CRIACAO(string grp_id, DateTime value);
        void UpdateGRP_PAPEL1(string grp_id, string value);
        void UpdateGRP_PAPEL2(string grp_id, string value);
        void UpdateGRP_PAPEL3(string grp_id, string value);
        void UpdateGRP_PAPEL4(string grp_id, string value);
        void UpdateGRP_PAPEL5(string grp_id, string value);
        void UpdateGRP_ID_INTEGRACAO(string grp_id, string value);
        void UpdateGRP_ID_INTEGRACAO_ERP(string grp_id, string value);
        void UpdateGRP_TYPE(string grp_id, int value);
        void UpdateGRP_PERFORMANCE(string grp_id, Decimal value);
        void UpdateGRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO(string grp_id, Decimal value);
        void UpdateGRP_RESINA(string grp_id, string value);
        void UpdateGRP_ENDURECEDOR_MIOLO(string grp_id, string value);
        void UpdateVIN_ID(string grp_id, int value);
        void UpdateGRP_COLUNA_DE(string grp_id, Decimal value);
        void UpdateGRP_COLUNA_ATE(string grp_id, Decimal value);
        void UpdateGRP_CRUSH(string grp_id, Decimal value);
        void UpdateGRP_ID_FAMILIA(string grp_id, string value);
        void UpdateGRP_REFILE_LARGURA(string grp_id, Decimal value);
        void UpdateGRP_REFILE_COMPRIMENTO(string grp_id, Decimal value);
        void UpdateGRP_TIPO_LAP(string grp_id, string value);
        void UpdateGRP_LAP_PROLONGADO(string grp_id, string value);
        void UpdateGRP_TAMANHO_LAP_OND_SIMPLES(string grp_id, Decimal value);
        void UpdateGRP_TAMANHO_LAP_OND_DUPLA(string grp_id, Decimal value);
        void UpdateGRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES(string grp_id, Decimal value);
        void UpdateGRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA(string grp_id, Decimal value);
        void UpdateGRP_FEFCO(string grp_id, string value);
        void UpdateGRP_TOLERANCIA_DIMENCAO_CHAPA_DE(string grp_id, int value);
        void UpdateGRP_TOLERANCIA_DIMENCAO_CHAPA_ATE(string grp_id, int value);
        void UpdateGRP_PREFIXO_ID_PRODUTO(string grp_id, string value);
        void UpdateGRP_COLUNA_CAIXA(string grp_id, Decimal value);
        void UpdateGRP_COLUNA_CHAPA(string grp_id, Decimal value);
        void UpdateGRP_MULLEN(string grp_id, Decimal value);
        void UpdateGRP_TENDENCIA_TOLERANCIA_PEDIDO(string grp_id, int value);
        void UpdateGRP_PERCENTUAL_PERDA_MEDIA(string grp_id, Decimal value);
        void UpdateGRP_FILTRA_SEQ_TRANS(string grp_id, int value);
        void UpdateGRP_IMG_CAIXA(string grp_id, string value);
        void UpdateTenantID(string grp_id, int value);
        void UpdateDeleted(string grp_id, bool value);
        void UpdateChanged(string grp_id, DateTime value);
        void UpdateUserId(string grp_id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration