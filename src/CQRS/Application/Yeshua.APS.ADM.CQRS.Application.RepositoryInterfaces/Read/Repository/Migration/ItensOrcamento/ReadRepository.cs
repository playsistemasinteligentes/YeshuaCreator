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
    public partial interface IItensOrcamentoReadRepository
    {
        public DataPagination<ItensOrcamentoDTO> getItensOrcamento(ICommandRead command );
        public IEnumerable<ItensOrcamentoGRP_ID_COMPOSICAODTO> getItensOrcamentoReadFKGRP_ID_COMPOSICAO(object command );
        public IEnumerable<ItensOrcamentoTenantIDDTO> getItensOrcamentoReadFKTenantID(object command );
        public IEnumerable<ItensOrcamentoUserIdDTO> getItensOrcamentoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByITO_ID(int value );
        public bool ExistsByORC_ID(int value );
        public bool ExistsByTIP_ID(int value );
        public bool ExistsByPRO_ID(string value );
        public bool ExistsByITO_OBS(string value );
        public bool ExistsByITO_QUANTIDADE(Decimal value );
        public bool ExistsByITO_CUSTO(Decimal value );
        public bool ExistsByITO_MARGEM(Decimal value );
        public bool ExistsByITO_VALOR_UNITARIO(Decimal value );
        public bool ExistsByITO_VERSSAO_CUSTO(DateTime value );
        public bool ExistsByITO_STATUS(string value );
        public bool ExistsByITO_ERP_CUSTOS_FIXOS(Decimal value );
        public bool ExistsByITO_ERP_CUSTOS_VARIAVEIS(Decimal value );
        public bool ExistsByITO_ERP_DESPESAS_VAR_VENDA(Decimal value );
        public bool ExistsByITO_ERP_IMPOSTOS(Decimal value );
        public bool ExistsByGRP_ID_COMPOSICAO(string value );
        public bool ExistsByITO_LARGURA(Decimal value );
        public bool ExistsByITO_COMPRIMENTO(Decimal value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ItensOrcamentoDTO FirstById(int value );
        public ItensOrcamentoDTO FirstByITO_ID(int value );
        public ItensOrcamentoDTO FirstByORC_ID(int value );
        public ItensOrcamentoDTO FirstByTIP_ID(int value );
        public ItensOrcamentoDTO FirstByPRO_ID(string value );
        public ItensOrcamentoDTO FirstByITO_OBS(string value );
        public ItensOrcamentoDTO FirstByITO_QUANTIDADE(Decimal value );
        public ItensOrcamentoDTO FirstByITO_CUSTO(Decimal value );
        public ItensOrcamentoDTO FirstByITO_MARGEM(Decimal value );
        public ItensOrcamentoDTO FirstByITO_VALOR_UNITARIO(Decimal value );
        public ItensOrcamentoDTO FirstByITO_VERSSAO_CUSTO(DateTime value );
        public ItensOrcamentoDTO FirstByITO_STATUS(string value );
        public ItensOrcamentoDTO FirstByITO_ERP_CUSTOS_FIXOS(Decimal value );
        public ItensOrcamentoDTO FirstByITO_ERP_CUSTOS_VARIAVEIS(Decimal value );
        public ItensOrcamentoDTO FirstByITO_ERP_DESPESAS_VAR_VENDA(Decimal value );
        public ItensOrcamentoDTO FirstByITO_ERP_IMPOSTOS(Decimal value );
        public ItensOrcamentoDTO FirstByGRP_ID_COMPOSICAO(string value );
        public ItensOrcamentoDTO FirstByITO_LARGURA(Decimal value );
        public ItensOrcamentoDTO FirstByITO_COMPRIMENTO(Decimal value );
        public ItensOrcamentoDTO FirstByTenantID(int value );
        public ItensOrcamentoDTO FirstByDeleted(bool value );
        public ItensOrcamentoDTO FirstByChanged(DateTime value );
        public ItensOrcamentoDTO FirstByUserId(int value );
        public IEnumerable<ItensOrcamentoDTO> GetAllById(int value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_ID(int value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByORC_ID(int value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByTIP_ID(int value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByPRO_ID(string value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_OBS(string value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_QUANTIDADE(Decimal value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_CUSTO(Decimal value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_MARGEM(Decimal value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_VALOR_UNITARIO(Decimal value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_VERSSAO_CUSTO(DateTime value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_STATUS(string value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_ERP_CUSTOS_FIXOS(Decimal value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_ERP_CUSTOS_VARIAVEIS(Decimal value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_ERP_DESPESAS_VAR_VENDA(Decimal value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_ERP_IMPOSTOS(Decimal value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByGRP_ID_COMPOSICAO(string value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_LARGURA(Decimal value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByITO_COMPRIMENTO(Decimal value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByTenantID(int value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByDeleted(bool value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ItensOrcamentoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration