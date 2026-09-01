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
    public partial interface ICondicaoPagamentoReadRepository
    {
        public DataPagination<CondicaoPagamentoDTO> getCondicaoPagamento(ICommandRead command );
        public IEnumerable<CondicaoPagamentoTenantIDDTO> getCondicaoPagamentoReadFKTenantID(object command );
        public IEnumerable<CondicaoPagamentoUserIdDTO> getCondicaoPagamentoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCON_ID(string value );
        public bool ExistsByCON_DESCRICAO(string value );
        public bool ExistsByCON_PARCELAS(int value );
        public bool ExistsByCON_VALOR_ACRECIMO(Decimal value );
        public bool ExistsByCON_INTEGRACAO_ERP(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public CondicaoPagamentoDTO FirstById(int value );
        public CondicaoPagamentoDTO FirstByCON_ID(string value );
        public CondicaoPagamentoDTO FirstByCON_DESCRICAO(string value );
        public CondicaoPagamentoDTO FirstByCON_PARCELAS(int value );
        public CondicaoPagamentoDTO FirstByCON_VALOR_ACRECIMO(Decimal value );
        public CondicaoPagamentoDTO FirstByCON_INTEGRACAO_ERP(string value );
        public CondicaoPagamentoDTO FirstByTenantID(int value );
        public CondicaoPagamentoDTO FirstByDeleted(bool value );
        public CondicaoPagamentoDTO FirstByChanged(DateTime value );
        public CondicaoPagamentoDTO FirstByUserId(int value );
        public IEnumerable<CondicaoPagamentoDTO> GetAllById(int value );
        public IEnumerable<CondicaoPagamentoDTO> GetAllByCON_ID(string value );
        public IEnumerable<CondicaoPagamentoDTO> GetAllByCON_DESCRICAO(string value );
        public IEnumerable<CondicaoPagamentoDTO> GetAllByCON_PARCELAS(int value );
        public IEnumerable<CondicaoPagamentoDTO> GetAllByCON_VALOR_ACRECIMO(Decimal value );
        public IEnumerable<CondicaoPagamentoDTO> GetAllByCON_INTEGRACAO_ERP(string value );
        public IEnumerable<CondicaoPagamentoDTO> GetAllByTenantID(int value );
        public IEnumerable<CondicaoPagamentoDTO> GetAllByDeleted(bool value );
        public IEnumerable<CondicaoPagamentoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CondicaoPagamentoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration