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
    public partial interface IProdutoWriteRepository
    {
        void Insert(IProdutoEntity produto);
        void Update(IProdutoEntity produto);
        void Delete(IProdutoEntity produto);
        void UpdateDescricao(string id, string value);
        void UpdateStatus(string id, string value);
        void UpdateTenantID(string id, int value);
        void UpdateDeleted(string id, bool value);
        void UpdateChanged(string id, DateTime value);
        void UpdateUserId(string id, int value);
        void UpdatePRO_ESTOQUE_ATUAL(string id, Decimal value);
        void UpdateUNI_ID(string id, string value);
        void UpdatePRO_FARDOS_POR_CAMADA(string id, Decimal value);
        void UpdatePRO_CAMADAS_POR_PALETE(string id, Decimal value);
        void UpdatePRO_TIPO_IDENTIFICACAO(string id, int value);
        void UpdatePRO_GRUPO_PALETIZACAO(string id, string value);
        void UpdatePRO_PECAS_POR_FARDO(string id, Decimal value);
        void UpdatePRO_ID_INTEGRACAO(string id, string value);
        void UpdatePRO_ID_INTEGRACAO_ERP(string id, string value);
        void UpdateGRP_ID(string id, string value);
        void UpdateTEM_ID(string id, int value);
        void UpdatePRO_LARGURA_PECA(string id, Decimal value);
        void UpdatePRO_COMPRIMENTO_PECA(string id, Decimal value);
        void UpdatePRO_ALTURA_PECA(string id, Decimal value);
        void UpdatePRO_LARGURA_EMBALADA(string id, Decimal value);
        void UpdatePRO_COMPRIMENTO_EMBALADA(string id, Decimal value);
        void UpdatePRO_ALTURA_EMBALADA(string id, Decimal value);
        void UpdatePRO_FRENTE(string id, string value);
        void UpdatePRO_ROTACIONA_COMPRIMENTO(string id, string value);
        void UpdatePRO_ROTACIONA_LARGURA(string id, string value);
        void UpdatePRO_ROTACIONA_ALTURA(string id, string value);
        void UpdatePRO_ESCALA_COR(string id, string value);
        void UpdatePRO_SUB_ESCALA_COR(string id, string value);
        void UpdatePRO_CUSTO_SUBIDA_ESCALA_COR(string id, Decimal value);
        void UpdatePRO_CUSTO_DECIDA_ESCALA_COR(string id, Decimal value);
        void UpdateTMP_TIPO_CARGA(string id, string value);
        void UpdatePRO_TEMPO_CARREGAMENTO_UNITARIO(string id, Decimal value);
        void UpdatePRO_TEMPO_DESCARREGAMENTO_UNITARIO(string id, Decimal value);
        void UpdatePRO_PERCENTUAL_JANELA_EMBARQUE(string id, Decimal value);
        void UpdatePRO_TEMPO_PRODUCAO_CONJUNTO(string id, Decimal value);
        void UpdatePRO_PECAS_DA_PECA(string id, Decimal value);
        void UpdatePRO_TYPE(string id, int value);
        void UpdatePRO_COLOR_HEXA(string id, string value);
        void UpdatePRO_VINCOS_LARGURA(string id, string value);
        void UpdatePRO_VINCOS_COMPRIMENTO(string id, string value);
        void UpdatePRO_LARGURA_INTERNA(string id, Decimal value);
        void UpdatePRO_COMPRIMENTO_INTERNA(string id, Decimal value);
        void UpdatePRO_ALTURA_INTERNA(string id, Decimal value);
        void UpdatePRO_COD_DESENHO(string id, string value);
        void UpdatePRO_FECHAMENTO(string id, string value);
        void UpdatePRO_TIPO_LAP(string id, string value);
        void UpdatePRO_TAMANHO_LAP(string id, Decimal value);
        void UpdatePRO_LAP_PROLONGADO(string id, string value);
        void UpdatePRO_TAMANHO_LAP_PROLONG(string id, Decimal value);
        void UpdatePRO_ARRANJO_LARGURA(string id, Decimal value);
        void UpdatePRO_ARRANJO_COMPRIMENTO(string id, Decimal value);
        void UpdatePRO_FITILHOS_FARDO_LARG(string id, int value);
        void UpdatePRO_FITILHOS_FARDO_COMP(string id, int value);
        void UpdatePRO_FITILHOS_PALETE_LARG(string id, int value);
        void UpdatePRO_FITILHOS_PALETE_COMP(string id, int value);
        void UpdatePRO_FILME_PALETE(string id, int value);
        void UpdatePRO_QTD_ESPELHO(string id, int value);
        void UpdatePRO_CUSTO(string id, Decimal value);
        void UpdatePRO_AREA_LIQUIDA(string id, Decimal value);
        void UpdatePRO_PESO(string id, Decimal value);
        void UpdatePRO_TOLERANCIA_DIMENSAO_CHAPA_DE(string id, int value);
        void UpdatePRO_TOLERANCIA_DIMENSAO_CHAPA_ATE(string id, int value);
        void UpdatePRO_IMG_LASTRO(string id, string value);
        void UpdateABN_ID(string id, string value);
        void UpdateSEG_ID(string id, int value);
        void UpdatePRO_RESINA(string id, string value);
        void UpdatePRO_ENDURECEDOR_MIOLO(string id, string value);
        void UpdatePRO_VINCOS_ONDULADEIRA(string id, string value);
        void UpdatePRO_ADICIONAL_ABA_SUPERIOR(string id, int value);
        void UpdatePRO_ADICIONAL_ABA_INFERIOR(string id, int value);
        void UpdatePRO_PROMOVE_RESINA(string id, string value);
        void UpdatePRO_PROMOVE_DE(string id, Decimal value);
        void UpdatePRO_PROMOVE_ATE(string id, Decimal value);
        void UpdatePRO_PROFUNDIDADE_VINCO(string id, int value);
        void UpdateVIN_ID(string id, int value);
        void UpdatePRO_PROMOVE_PRODUTO(string id, string value);
        void UpdatePRO_TARA(string id, Decimal value);
        void UpdatePRO_COMPRESSAO(string id, Decimal value);
        void UpdatePRO_COD_BARRAS_CAIXA(string id, string value);
        void UpdateCJN_ID(string id, string value);
        void UpdatePRJ_ID(string id, string value);
        void UpdatePRO_REFILE_LARGURA(string id, int value);
        void UpdatePRO_REFILE_COMPRIMENTO(string id, int value);
        void UpdatePRO_M2_PONTA(string id, Decimal value);
        void UpdatePRO_QTD_CORTES_PECA1(string id, int value);
        void UpdatePRO_QTD_CORTES_PECA2(string id, int value);
        void UpdatePRO_DIVISAO_MONTADA(string id, string value);
        void UpdatePRO_SEGMENTO_A(string id, Decimal value);
        void UpdatePRO_SEGMENTO_B(string id, Decimal value);
        void UpdatePRO_SEGMENTO_C(string id, Decimal value);
        void UpdatePRO_SEGMENTO_D(string id, Decimal value);
        void UpdatePRO_SEGMENTO_E(string id, Decimal value);
        void UpdatePRO_SEGMENTO_F(string id, Decimal value);
        void UpdatePRO_SEGMENTO_G(string id, Decimal value);
        void UpdatePRO_SEGMENTO_H(string id, Decimal value);
        void UpdatePRO_SEGMENTO_I(string id, Decimal value);
        void UpdatePRO_QTD_GRAMPOS(string id, Decimal value);
        void UpdatePRO_AREA_REFILE_INTERNO(string id, Decimal value);
        void UpdatePRO_AREA_REFILE_EXTERNO(string id, Decimal value);
        void UpdatePRO_PESO_REFILE(string id, Decimal value);
        void UpdatePRO_ORELHA_INVERTIDA(string id, string value);
        void UpdatePRO_ENDERECO(string id, string value);
        void UpdatePRO_ID_VINCULADO(string id, string value);
        void UpdatePRO_BATIDAS_PROXIMA_MANUTENCAO(string id, int value);
        void UpdatePRO_ENTRADA_NA_MAQUINA(string id, string value);
        void UpdateTDI_ID(string id, string value);
        void UpdatePRO_QUEBRA_VINCO(string id, int value);
        void UpdatePRO_LARGURA_FARDO(string id, int value);
        void UpdatePRO_COMPRIMENTO_FARDO(string id, int value);
        void UpdatePRO_ALTURA_FARDO(string id, Decimal value);
        void UpdatePRO_TIPO_CUSTO(string id, string value);
        void UpdatePRO_GRUPO_CONTABIL(string id, string value);
        void UpdatePRO_CLASSE_CUSTO_01(string id, string value);
        void UpdatePRO_OBS_ALTERACAO(string id, string value);
        void UpdateTIP_ID(string id, int value);
        void UpdatePRO_PECAS_POR_VEICULO(string id, Decimal value);
        void UpdatePRO_DISTANCIA_ENTRE_VINCOS(string id, int value);
        void UpdatePRO_DISTANCIA_ENTRE_VINCOS2(string id, int value);
        void UpdatePRO_DISTANCIA_ENTRE_VINCOS3(string id, int value);
        void UpdatePRO_OUT(string id, int value);
        void UpdatePRO_ID_FACA(string id, string value);
        void UpdatePRO_ID_CLICHE(string id, string value);
        void UpdatePRO_ID_TINTA_01(string id, string value);
        void UpdatePRO_ID_TINTA_02(string id, string value);
        void UpdatePRO_ID_TINTA_03(string id, string value);
        void UpdatePRO_ID_TINTA_04(string id, string value);
        void UpdatePRO_ID_TINTA_05(string id, string value);
        void UpdatePRO_ID_FORROSUP(string id, string value);
        void UpdatePRO_ID_CANTONEIRA(string id, string value);
        void UpdatePRO_ID_PALETE(string id, string value);
        void UpdatePRO_ID_TAMPO(string id, string value);
        void UpdatePRO_ID_FORROINF(string id, string value);
        void UpdatePRO_ID_CHAPA(string id, string value);
        void UpdatePRO_ID_COMPOSICAO(string id, string value);
        void UpdatePRO_QUEBRA_VINCO_MAIOR(string id, int value);
        void UpdatePRO_QUEBRA_VINCO_MENOR(string id, int value);
        void UpdateCLI_ID(string id, string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration