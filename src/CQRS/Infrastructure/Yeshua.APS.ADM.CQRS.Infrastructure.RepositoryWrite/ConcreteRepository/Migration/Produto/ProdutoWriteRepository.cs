// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
// </yeshua>

using Dapper;
using Dominio.Entitys;
using IRepository.Write;
using IQuery.Write;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Produto
{
    public partial class ProdutoWriteRepository : IProdutoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IProdutoQueryWrite _query; 

        public ProdutoWriteRepository(IUnitOfWork unitOfWork,IProdutoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IProdutoEntity Produto)
        {
            var query = _query.InserirProdutoQuery(Produto);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IProdutoEntity Produto)
        {
            var query = _query.UpdateProdutoQuery(Produto);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IProdutoEntity Produto)
        {
            var query = _query.DeleteProdutoQuery(Produto);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDescricao(string id, string value)
        {
            var query = _query.UpdateDescricao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(string id, string value)
        {
            var query = _query.UpdateStatus(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string id, int value)
        {
            var query = _query.UpdateTenantID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string id, bool value)
        {
            var query = _query.UpdateDeleted(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string id, DateTime value)
        {
            var query = _query.UpdateChanged(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string id, int value)
        {
            var query = _query.UpdateUserId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ESTOQUE_ATUAL(string id, Decimal value)
        {
            var query = _query.UpdatePRO_ESTOQUE_ATUAL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUNI_ID(string id, string value)
        {
            var query = _query.UpdateUNI_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_FARDOS_POR_CAMADA(string id, Decimal value)
        {
            var query = _query.UpdatePRO_FARDOS_POR_CAMADA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_CAMADAS_POR_PALETE(string id, Decimal value)
        {
            var query = _query.UpdatePRO_CAMADAS_POR_PALETE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_TIPO_IDENTIFICACAO(string id, int value)
        {
            var query = _query.UpdatePRO_TIPO_IDENTIFICACAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_GRUPO_PALETIZACAO(string id, string value)
        {
            var query = _query.UpdatePRO_GRUPO_PALETIZACAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_PECAS_POR_FARDO(string id, Decimal value)
        {
            var query = _query.UpdatePRO_PECAS_POR_FARDO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_INTEGRACAO(string id, string value)
        {
            var query = _query.UpdatePRO_ID_INTEGRACAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_INTEGRACAO_ERP(string id, string value)
        {
            var query = _query.UpdatePRO_ID_INTEGRACAO_ERP(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_ID(string id, string value)
        {
            var query = _query.UpdateGRP_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTEM_ID(string id, int value)
        {
            var query = _query.UpdateTEM_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_LARGURA_PECA(string id, Decimal value)
        {
            var query = _query.UpdatePRO_LARGURA_PECA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_COMPRIMENTO_PECA(string id, Decimal value)
        {
            var query = _query.UpdatePRO_COMPRIMENTO_PECA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ALTURA_PECA(string id, Decimal value)
        {
            var query = _query.UpdatePRO_ALTURA_PECA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_LARGURA_EMBALADA(string id, Decimal value)
        {
            var query = _query.UpdatePRO_LARGURA_EMBALADA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_COMPRIMENTO_EMBALADA(string id, Decimal value)
        {
            var query = _query.UpdatePRO_COMPRIMENTO_EMBALADA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ALTURA_EMBALADA(string id, Decimal value)
        {
            var query = _query.UpdatePRO_ALTURA_EMBALADA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_FRENTE(string id, string value)
        {
            var query = _query.UpdatePRO_FRENTE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ROTACIONA_COMPRIMENTO(string id, string value)
        {
            var query = _query.UpdatePRO_ROTACIONA_COMPRIMENTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ROTACIONA_LARGURA(string id, string value)
        {
            var query = _query.UpdatePRO_ROTACIONA_LARGURA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ROTACIONA_ALTURA(string id, string value)
        {
            var query = _query.UpdatePRO_ROTACIONA_ALTURA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ESCALA_COR(string id, string value)
        {
            var query = _query.UpdatePRO_ESCALA_COR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_SUB_ESCALA_COR(string id, string value)
        {
            var query = _query.UpdatePRO_SUB_ESCALA_COR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_CUSTO_SUBIDA_ESCALA_COR(string id, Decimal value)
        {
            var query = _query.UpdatePRO_CUSTO_SUBIDA_ESCALA_COR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_CUSTO_DECIDA_ESCALA_COR(string id, Decimal value)
        {
            var query = _query.UpdatePRO_CUSTO_DECIDA_ESCALA_COR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTMP_TIPO_CARGA(string id, string value)
        {
            var query = _query.UpdateTMP_TIPO_CARGA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_TEMPO_CARREGAMENTO_UNITARIO(string id, Decimal value)
        {
            var query = _query.UpdatePRO_TEMPO_CARREGAMENTO_UNITARIO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_TEMPO_DESCARREGAMENTO_UNITARIO(string id, Decimal value)
        {
            var query = _query.UpdatePRO_TEMPO_DESCARREGAMENTO_UNITARIO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_PERCENTUAL_JANELA_EMBARQUE(string id, Decimal value)
        {
            var query = _query.UpdatePRO_PERCENTUAL_JANELA_EMBARQUE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_TEMPO_PRODUCAO_CONJUNTO(string id, Decimal value)
        {
            var query = _query.UpdatePRO_TEMPO_PRODUCAO_CONJUNTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_PECAS_DA_PECA(string id, Decimal value)
        {
            var query = _query.UpdatePRO_PECAS_DA_PECA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_TYPE(string id, int value)
        {
            var query = _query.UpdatePRO_TYPE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_COLOR_HEXA(string id, string value)
        {
            var query = _query.UpdatePRO_COLOR_HEXA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_VINCOS_LARGURA(string id, string value)
        {
            var query = _query.UpdatePRO_VINCOS_LARGURA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_VINCOS_COMPRIMENTO(string id, string value)
        {
            var query = _query.UpdatePRO_VINCOS_COMPRIMENTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_LARGURA_INTERNA(string id, Decimal value)
        {
            var query = _query.UpdatePRO_LARGURA_INTERNA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_COMPRIMENTO_INTERNA(string id, Decimal value)
        {
            var query = _query.UpdatePRO_COMPRIMENTO_INTERNA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ALTURA_INTERNA(string id, Decimal value)
        {
            var query = _query.UpdatePRO_ALTURA_INTERNA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_COD_DESENHO(string id, string value)
        {
            var query = _query.UpdatePRO_COD_DESENHO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_FECHAMENTO(string id, string value)
        {
            var query = _query.UpdatePRO_FECHAMENTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_TIPO_LAP(string id, string value)
        {
            var query = _query.UpdatePRO_TIPO_LAP(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_TAMANHO_LAP(string id, Decimal value)
        {
            var query = _query.UpdatePRO_TAMANHO_LAP(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_LAP_PROLONGADO(string id, string value)
        {
            var query = _query.UpdatePRO_LAP_PROLONGADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_TAMANHO_LAP_PROLONG(string id, Decimal value)
        {
            var query = _query.UpdatePRO_TAMANHO_LAP_PROLONG(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ARRANJO_LARGURA(string id, Decimal value)
        {
            var query = _query.UpdatePRO_ARRANJO_LARGURA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ARRANJO_COMPRIMENTO(string id, Decimal value)
        {
            var query = _query.UpdatePRO_ARRANJO_COMPRIMENTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_FITILHOS_FARDO_LARG(string id, int value)
        {
            var query = _query.UpdatePRO_FITILHOS_FARDO_LARG(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_FITILHOS_FARDO_COMP(string id, int value)
        {
            var query = _query.UpdatePRO_FITILHOS_FARDO_COMP(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_FITILHOS_PALETE_LARG(string id, int value)
        {
            var query = _query.UpdatePRO_FITILHOS_PALETE_LARG(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_FITILHOS_PALETE_COMP(string id, int value)
        {
            var query = _query.UpdatePRO_FITILHOS_PALETE_COMP(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_FILME_PALETE(string id, int value)
        {
            var query = _query.UpdatePRO_FILME_PALETE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_QTD_ESPELHO(string id, int value)
        {
            var query = _query.UpdatePRO_QTD_ESPELHO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_CUSTO(string id, Decimal value)
        {
            var query = _query.UpdatePRO_CUSTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_AREA_LIQUIDA(string id, Decimal value)
        {
            var query = _query.UpdatePRO_AREA_LIQUIDA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_PESO(string id, Decimal value)
        {
            var query = _query.UpdatePRO_PESO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_TOLERANCIA_DIMENSAO_CHAPA_DE(string id, int value)
        {
            var query = _query.UpdatePRO_TOLERANCIA_DIMENSAO_CHAPA_DE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_TOLERANCIA_DIMENSAO_CHAPA_ATE(string id, int value)
        {
            var query = _query.UpdatePRO_TOLERANCIA_DIMENSAO_CHAPA_ATE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_IMG_LASTRO(string id, string value)
        {
            var query = _query.UpdatePRO_IMG_LASTRO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateABN_ID(string id, string value)
        {
            var query = _query.UpdateABN_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSEG_ID(string id, int value)
        {
            var query = _query.UpdateSEG_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_RESINA(string id, string value)
        {
            var query = _query.UpdatePRO_RESINA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ENDURECEDOR_MIOLO(string id, string value)
        {
            var query = _query.UpdatePRO_ENDURECEDOR_MIOLO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_VINCOS_ONDULADEIRA(string id, string value)
        {
            var query = _query.UpdatePRO_VINCOS_ONDULADEIRA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ADICIONAL_ABA_SUPERIOR(string id, int value)
        {
            var query = _query.UpdatePRO_ADICIONAL_ABA_SUPERIOR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ADICIONAL_ABA_INFERIOR(string id, int value)
        {
            var query = _query.UpdatePRO_ADICIONAL_ABA_INFERIOR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_PROMOVE_RESINA(string id, string value)
        {
            var query = _query.UpdatePRO_PROMOVE_RESINA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_PROMOVE_DE(string id, Decimal value)
        {
            var query = _query.UpdatePRO_PROMOVE_DE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_PROMOVE_ATE(string id, Decimal value)
        {
            var query = _query.UpdatePRO_PROMOVE_ATE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_PROFUNDIDADE_VINCO(string id, int value)
        {
            var query = _query.UpdatePRO_PROFUNDIDADE_VINCO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVIN_ID(string id, int value)
        {
            var query = _query.UpdateVIN_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_PROMOVE_PRODUTO(string id, string value)
        {
            var query = _query.UpdatePRO_PROMOVE_PRODUTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_TARA(string id, Decimal value)
        {
            var query = _query.UpdatePRO_TARA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_COMPRESSAO(string id, Decimal value)
        {
            var query = _query.UpdatePRO_COMPRESSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_COD_BARRAS_CAIXA(string id, string value)
        {
            var query = _query.UpdatePRO_COD_BARRAS_CAIXA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCJN_ID(string id, string value)
        {
            var query = _query.UpdateCJN_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRJ_ID(string id, string value)
        {
            var query = _query.UpdatePRJ_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_REFILE_LARGURA(string id, int value)
        {
            var query = _query.UpdatePRO_REFILE_LARGURA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_REFILE_COMPRIMENTO(string id, int value)
        {
            var query = _query.UpdatePRO_REFILE_COMPRIMENTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_M2_PONTA(string id, Decimal value)
        {
            var query = _query.UpdatePRO_M2_PONTA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_QTD_CORTES_PECA1(string id, int value)
        {
            var query = _query.UpdatePRO_QTD_CORTES_PECA1(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_QTD_CORTES_PECA2(string id, int value)
        {
            var query = _query.UpdatePRO_QTD_CORTES_PECA2(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_DIVISAO_MONTADA(string id, string value)
        {
            var query = _query.UpdatePRO_DIVISAO_MONTADA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_SEGMENTO_A(string id, Decimal value)
        {
            var query = _query.UpdatePRO_SEGMENTO_A(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_SEGMENTO_B(string id, Decimal value)
        {
            var query = _query.UpdatePRO_SEGMENTO_B(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_SEGMENTO_C(string id, Decimal value)
        {
            var query = _query.UpdatePRO_SEGMENTO_C(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_SEGMENTO_D(string id, Decimal value)
        {
            var query = _query.UpdatePRO_SEGMENTO_D(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_SEGMENTO_E(string id, Decimal value)
        {
            var query = _query.UpdatePRO_SEGMENTO_E(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_SEGMENTO_F(string id, Decimal value)
        {
            var query = _query.UpdatePRO_SEGMENTO_F(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_SEGMENTO_G(string id, Decimal value)
        {
            var query = _query.UpdatePRO_SEGMENTO_G(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_SEGMENTO_H(string id, Decimal value)
        {
            var query = _query.UpdatePRO_SEGMENTO_H(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_SEGMENTO_I(string id, Decimal value)
        {
            var query = _query.UpdatePRO_SEGMENTO_I(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_QTD_GRAMPOS(string id, Decimal value)
        {
            var query = _query.UpdatePRO_QTD_GRAMPOS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_AREA_REFILE_INTERNO(string id, Decimal value)
        {
            var query = _query.UpdatePRO_AREA_REFILE_INTERNO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_AREA_REFILE_EXTERNO(string id, Decimal value)
        {
            var query = _query.UpdatePRO_AREA_REFILE_EXTERNO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_PESO_REFILE(string id, Decimal value)
        {
            var query = _query.UpdatePRO_PESO_REFILE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ORELHA_INVERTIDA(string id, string value)
        {
            var query = _query.UpdatePRO_ORELHA_INVERTIDA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ENDERECO(string id, string value)
        {
            var query = _query.UpdatePRO_ENDERECO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_VINCULADO(string id, string value)
        {
            var query = _query.UpdatePRO_ID_VINCULADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_BATIDAS_PROXIMA_MANUTENCAO(string id, int value)
        {
            var query = _query.UpdatePRO_BATIDAS_PROXIMA_MANUTENCAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ENTRADA_NA_MAQUINA(string id, string value)
        {
            var query = _query.UpdatePRO_ENTRADA_NA_MAQUINA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTDI_ID(string id, string value)
        {
            var query = _query.UpdateTDI_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_QUEBRA_VINCO(string id, int value)
        {
            var query = _query.UpdatePRO_QUEBRA_VINCO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_LARGURA_FARDO(string id, int value)
        {
            var query = _query.UpdatePRO_LARGURA_FARDO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_COMPRIMENTO_FARDO(string id, int value)
        {
            var query = _query.UpdatePRO_COMPRIMENTO_FARDO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ALTURA_FARDO(string id, Decimal value)
        {
            var query = _query.UpdatePRO_ALTURA_FARDO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_TIPO_CUSTO(string id, string value)
        {
            var query = _query.UpdatePRO_TIPO_CUSTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_GRUPO_CONTABIL(string id, string value)
        {
            var query = _query.UpdatePRO_GRUPO_CONTABIL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_CLASSE_CUSTO_01(string id, string value)
        {
            var query = _query.UpdatePRO_CLASSE_CUSTO_01(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_OBS_ALTERACAO(string id, string value)
        {
            var query = _query.UpdatePRO_OBS_ALTERACAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_ID(string id, int value)
        {
            var query = _query.UpdateTIP_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_PECAS_POR_VEICULO(string id, Decimal value)
        {
            var query = _query.UpdatePRO_PECAS_POR_VEICULO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_DISTANCIA_ENTRE_VINCOS(string id, int value)
        {
            var query = _query.UpdatePRO_DISTANCIA_ENTRE_VINCOS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_DISTANCIA_ENTRE_VINCOS2(string id, int value)
        {
            var query = _query.UpdatePRO_DISTANCIA_ENTRE_VINCOS2(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_DISTANCIA_ENTRE_VINCOS3(string id, int value)
        {
            var query = _query.UpdatePRO_DISTANCIA_ENTRE_VINCOS3(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_OUT(string id, int value)
        {
            var query = _query.UpdatePRO_OUT(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_FACA(string id, string value)
        {
            var query = _query.UpdatePRO_ID_FACA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_CLICHE(string id, string value)
        {
            var query = _query.UpdatePRO_ID_CLICHE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_TINTA_01(string id, string value)
        {
            var query = _query.UpdatePRO_ID_TINTA_01(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_TINTA_02(string id, string value)
        {
            var query = _query.UpdatePRO_ID_TINTA_02(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_TINTA_03(string id, string value)
        {
            var query = _query.UpdatePRO_ID_TINTA_03(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_TINTA_04(string id, string value)
        {
            var query = _query.UpdatePRO_ID_TINTA_04(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_TINTA_05(string id, string value)
        {
            var query = _query.UpdatePRO_ID_TINTA_05(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_FORROSUP(string id, string value)
        {
            var query = _query.UpdatePRO_ID_FORROSUP(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_CANTONEIRA(string id, string value)
        {
            var query = _query.UpdatePRO_ID_CANTONEIRA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_PALETE(string id, string value)
        {
            var query = _query.UpdatePRO_ID_PALETE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_TAMPO(string id, string value)
        {
            var query = _query.UpdatePRO_ID_TAMPO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_FORROINF(string id, string value)
        {
            var query = _query.UpdatePRO_ID_FORROINF(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_CHAPA(string id, string value)
        {
            var query = _query.UpdatePRO_ID_CHAPA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_COMPOSICAO(string id, string value)
        {
            var query = _query.UpdatePRO_ID_COMPOSICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_QUEBRA_VINCO_MAIOR(string id, int value)
        {
            var query = _query.UpdatePRO_QUEBRA_VINCO_MAIOR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_QUEBRA_VINCO_MENOR(string id, int value)
        {
            var query = _query.UpdatePRO_QUEBRA_VINCO_MENOR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_ID(string id, string value)
        {
            var query = _query.UpdateCLI_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration