// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration
// </yeshua>

using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Read
{
    public partial interface IGrupoProdutoAbstratoReadRepository
    {
        public DataPagination<GrupoProdutoAbstratoDTO> getGrupoProdutoAbstrato(ICommandRead command );
        public IEnumerable<GrupoProdutoAbstratoGRP_PAP_ONDADTO> getGrupoProdutoAbstratoReadFKGRP_PAP_ONDA(object command );
        public IEnumerable<GrupoProdutoAbstratoVIN_IDDTO> getGrupoProdutoAbstratoReadFKVIN_ID(object command );
        public IEnumerable<GrupoProdutoAbstratoTenantIDDTO> getGrupoProdutoAbstratoReadFKTenantID(object command );
        public IEnumerable<GrupoProdutoAbstratoUserIdDTO> getGrupoProdutoAbstratoReadFKUserId(object command );
        public bool ExistsByGRP_ID(string value );
        public bool ExistsByGRP_DESCRICAO(string value );
        public bool ExistsByTEM_ID(int value );
        public bool ExistsByGRP_TIPO(Decimal value );
        public bool ExistsByGRP_PAP_ONDA(string value );
        public bool ExistsByGRP_PAP_GRAMATURA(Decimal value );
        public bool ExistsByGRP_PAP_ALTURA(Decimal value );
        public bool ExistsByGRP_PAP_NOME_COMERCIAL(string value );
        public bool ExistsByGRP_ATIVO(string value );
        public bool ExistsByGRP_DT_CRIACAO(DateTime value );
        public bool ExistsByGRP_PAPEL1(string value );
        public bool ExistsByGRP_PAPEL2(string value );
        public bool ExistsByGRP_PAPEL3(string value );
        public bool ExistsByGRP_PAPEL4(string value );
        public bool ExistsByGRP_PAPEL5(string value );
        public bool ExistsByGRP_ID_INTEGRACAO(string value );
        public bool ExistsByGRP_ID_INTEGRACAO_ERP(string value );
        public bool ExistsByGRP_TYPE(int value );
        public bool ExistsByGRP_PERFORMANCE(Decimal value );
        public bool ExistsByGRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO(Decimal value );
        public bool ExistsByGRP_RESINA(string value );
        public bool ExistsByGRP_ENDURECEDOR_MIOLO(string value );
        public bool ExistsByVIN_ID(int value );
        public bool ExistsByGRP_COLUNA_DE(Decimal value );
        public bool ExistsByGRP_COLUNA_ATE(Decimal value );
        public bool ExistsByGRP_CRUSH(Decimal value );
        public bool ExistsByGRP_ID_FAMILIA(string value );
        public bool ExistsByGRP_REFILE_LARGURA(Decimal value );
        public bool ExistsByGRP_REFILE_COMPRIMENTO(Decimal value );
        public bool ExistsByGRP_TIPO_LAP(string value );
        public bool ExistsByGRP_LAP_PROLONGADO(string value );
        public bool ExistsByGRP_TAMANHO_LAP_OND_SIMPLES(Decimal value );
        public bool ExistsByGRP_TAMANHO_LAP_OND_DUPLA(Decimal value );
        public bool ExistsByGRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES(Decimal value );
        public bool ExistsByGRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA(Decimal value );
        public bool ExistsByGRP_FEFCO(string value );
        public bool ExistsByGRP_TOLERANCIA_DIMENCAO_CHAPA_DE(int value );
        public bool ExistsByGRP_TOLERANCIA_DIMENCAO_CHAPA_ATE(int value );
        public bool ExistsByGRP_PREFIXO_ID_PRODUTO(string value );
        public bool ExistsByGRP_COLUNA_CAIXA(Decimal value );
        public bool ExistsByGRP_COLUNA_CHAPA(Decimal value );
        public bool ExistsByGRP_MULLEN(Decimal value );
        public bool ExistsByGRP_TENDENCIA_TOLERANCIA_PEDIDO(int value );
        public bool ExistsByGRP_PERCENTUAL_PERDA_MEDIA(Decimal value );
        public bool ExistsByGRP_FILTRA_SEQ_TRANS(int value );
        public bool ExistsByGRP_IMG_CAIXA(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public GrupoProdutoAbstratoDTO FirstByGRP_ID(string value );
        public GrupoProdutoAbstratoDTO FirstByGRP_DESCRICAO(string value );
        public GrupoProdutoAbstratoDTO FirstByTEM_ID(int value );
        public GrupoProdutoAbstratoDTO FirstByGRP_TIPO(Decimal value );
        public GrupoProdutoAbstratoDTO FirstByGRP_PAP_ONDA(string value );
        public GrupoProdutoAbstratoDTO FirstByGRP_PAP_GRAMATURA(Decimal value );
        public GrupoProdutoAbstratoDTO FirstByGRP_PAP_ALTURA(Decimal value );
        public GrupoProdutoAbstratoDTO FirstByGRP_PAP_NOME_COMERCIAL(string value );
        public GrupoProdutoAbstratoDTO FirstByGRP_ATIVO(string value );
        public GrupoProdutoAbstratoDTO FirstByGRP_DT_CRIACAO(DateTime value );
        public GrupoProdutoAbstratoDTO FirstByGRP_PAPEL1(string value );
        public GrupoProdutoAbstratoDTO FirstByGRP_PAPEL2(string value );
        public GrupoProdutoAbstratoDTO FirstByGRP_PAPEL3(string value );
        public GrupoProdutoAbstratoDTO FirstByGRP_PAPEL4(string value );
        public GrupoProdutoAbstratoDTO FirstByGRP_PAPEL5(string value );
        public GrupoProdutoAbstratoDTO FirstByGRP_ID_INTEGRACAO(string value );
        public GrupoProdutoAbstratoDTO FirstByGRP_ID_INTEGRACAO_ERP(string value );
        public GrupoProdutoAbstratoDTO FirstByGRP_TYPE(int value );
        public GrupoProdutoAbstratoDTO FirstByGRP_PERFORMANCE(Decimal value );
        public GrupoProdutoAbstratoDTO FirstByGRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO(Decimal value );
        public GrupoProdutoAbstratoDTO FirstByGRP_RESINA(string value );
        public GrupoProdutoAbstratoDTO FirstByGRP_ENDURECEDOR_MIOLO(string value );
        public GrupoProdutoAbstratoDTO FirstByVIN_ID(int value );
        public GrupoProdutoAbstratoDTO FirstByGRP_COLUNA_DE(Decimal value );
        public GrupoProdutoAbstratoDTO FirstByGRP_COLUNA_ATE(Decimal value );
        public GrupoProdutoAbstratoDTO FirstByGRP_CRUSH(Decimal value );
        public GrupoProdutoAbstratoDTO FirstByGRP_ID_FAMILIA(string value );
        public GrupoProdutoAbstratoDTO FirstByGRP_REFILE_LARGURA(Decimal value );
        public GrupoProdutoAbstratoDTO FirstByGRP_REFILE_COMPRIMENTO(Decimal value );
        public GrupoProdutoAbstratoDTO FirstByGRP_TIPO_LAP(string value );
        public GrupoProdutoAbstratoDTO FirstByGRP_LAP_PROLONGADO(string value );
        public GrupoProdutoAbstratoDTO FirstByGRP_TAMANHO_LAP_OND_SIMPLES(Decimal value );
        public GrupoProdutoAbstratoDTO FirstByGRP_TAMANHO_LAP_OND_DUPLA(Decimal value );
        public GrupoProdutoAbstratoDTO FirstByGRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES(Decimal value );
        public GrupoProdutoAbstratoDTO FirstByGRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA(Decimal value );
        public GrupoProdutoAbstratoDTO FirstByGRP_FEFCO(string value );
        public GrupoProdutoAbstratoDTO FirstByGRP_TOLERANCIA_DIMENCAO_CHAPA_DE(int value );
        public GrupoProdutoAbstratoDTO FirstByGRP_TOLERANCIA_DIMENCAO_CHAPA_ATE(int value );
        public GrupoProdutoAbstratoDTO FirstByGRP_PREFIXO_ID_PRODUTO(string value );
        public GrupoProdutoAbstratoDTO FirstByGRP_COLUNA_CAIXA(Decimal value );
        public GrupoProdutoAbstratoDTO FirstByGRP_COLUNA_CHAPA(Decimal value );
        public GrupoProdutoAbstratoDTO FirstByGRP_MULLEN(Decimal value );
        public GrupoProdutoAbstratoDTO FirstByGRP_TENDENCIA_TOLERANCIA_PEDIDO(int value );
        public GrupoProdutoAbstratoDTO FirstByGRP_PERCENTUAL_PERDA_MEDIA(Decimal value );
        public GrupoProdutoAbstratoDTO FirstByGRP_FILTRA_SEQ_TRANS(int value );
        public GrupoProdutoAbstratoDTO FirstByGRP_IMG_CAIXA(string value );
        public GrupoProdutoAbstratoDTO FirstByTenantID(int value );
        public GrupoProdutoAbstratoDTO FirstByDeleted(bool value );
        public GrupoProdutoAbstratoDTO FirstByChanged(DateTime value );
        public GrupoProdutoAbstratoDTO FirstByUserId(int value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_ID(string value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_DESCRICAO(string value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByTEM_ID(int value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_TIPO(Decimal value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PAP_ONDA(string value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PAP_GRAMATURA(Decimal value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PAP_ALTURA(Decimal value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PAP_NOME_COMERCIAL(string value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_ATIVO(string value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_DT_CRIACAO(DateTime value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PAPEL1(string value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PAPEL2(string value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PAPEL3(string value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PAPEL4(string value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PAPEL5(string value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_ID_INTEGRACAO(string value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_ID_INTEGRACAO_ERP(string value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_TYPE(int value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PERFORMANCE(Decimal value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO(Decimal value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_RESINA(string value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_ENDURECEDOR_MIOLO(string value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByVIN_ID(int value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_COLUNA_DE(Decimal value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_COLUNA_ATE(Decimal value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_CRUSH(Decimal value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_ID_FAMILIA(string value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_REFILE_LARGURA(Decimal value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_REFILE_COMPRIMENTO(Decimal value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_TIPO_LAP(string value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_LAP_PROLONGADO(string value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_TAMANHO_LAP_OND_SIMPLES(Decimal value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_TAMANHO_LAP_OND_DUPLA(Decimal value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES(Decimal value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA(Decimal value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_FEFCO(string value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_TOLERANCIA_DIMENCAO_CHAPA_DE(int value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_TOLERANCIA_DIMENCAO_CHAPA_ATE(int value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PREFIXO_ID_PRODUTO(string value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_COLUNA_CAIXA(Decimal value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_COLUNA_CHAPA(Decimal value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_MULLEN(Decimal value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_TENDENCIA_TOLERANCIA_PEDIDO(int value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_PERCENTUAL_PERDA_MEDIA(Decimal value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_FILTRA_SEQ_TRANS(int value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByGRP_IMG_CAIXA(string value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByTenantID(int value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByDeleted(bool value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<GrupoProdutoAbstratoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration