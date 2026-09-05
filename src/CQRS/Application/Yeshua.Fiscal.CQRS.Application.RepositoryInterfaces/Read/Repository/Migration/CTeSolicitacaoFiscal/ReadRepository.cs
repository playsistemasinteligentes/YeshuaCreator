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
    public partial interface ICTeSolicitacaoFiscalReadRepository
    {
        public DataPagination<CTeSolicitacaoFiscalDTO> getCTeSolicitacaoFiscal(ICommandRead command );
        public IEnumerable<CTeSolicitacaoFiscalEntradaOficialIdDTO> getCTeSolicitacaoFiscalReadFKEntradaOficialId(object command );
        public IEnumerable<CTeSolicitacaoFiscalRomaneioConsolidadoIdDTO> getCTeSolicitacaoFiscalReadFKRomaneioConsolidadoId(object command );
        public IEnumerable<CTeSolicitacaoFiscalTenantIDDTO> getCTeSolicitacaoFiscalReadFKTenantID(object command );
        public IEnumerable<CTeSolicitacaoFiscalUserIdDTO> getCTeSolicitacaoFiscalReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByEntradaOficialId(int value );
        public bool ExistsByRomaneioConsolidadoId(int value );
        public bool ExistsByCorrelationId(string value );
        public bool ExistsByAmbiente(int value );
        public bool ExistsByUFEmitente(string value );
        public bool ExistsByEmitenteDocumento(string value );
        public bool ExistsByProdutoFiscal(int value );
        public bool ExistsByTipoCTe(int value );
        public bool ExistsByTipoServico(int value );
        public bool ExistsByModal(int value );
        public bool ExistsByGlobalizado(int value );
        public bool ExistsByUFInicio(string value );
        public bool ExistsByUFFim(string value );
        public bool ExistsByMunicipioInicioCodigoIbge(string value );
        public bool ExistsByMunicipioFimCodigoIbge(string value );
        public bool ExistsByValorServico(Decimal value );
        public bool ExistsByValorCarga(Decimal value );
        public bool ExistsByPreferenciasManifestoJson(string value );
        public bool ExistsByStatus(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public CTeSolicitacaoFiscalDTO FirstById(int value );
        public CTeSolicitacaoFiscalDTO FirstByEntradaOficialId(int value );
        public CTeSolicitacaoFiscalDTO FirstByRomaneioConsolidadoId(int value );
        public CTeSolicitacaoFiscalDTO FirstByCorrelationId(string value );
        public CTeSolicitacaoFiscalDTO FirstByAmbiente(int value );
        public CTeSolicitacaoFiscalDTO FirstByUFEmitente(string value );
        public CTeSolicitacaoFiscalDTO FirstByEmitenteDocumento(string value );
        public CTeSolicitacaoFiscalDTO FirstByProdutoFiscal(int value );
        public CTeSolicitacaoFiscalDTO FirstByTipoCTe(int value );
        public CTeSolicitacaoFiscalDTO FirstByTipoServico(int value );
        public CTeSolicitacaoFiscalDTO FirstByModal(int value );
        public CTeSolicitacaoFiscalDTO FirstByGlobalizado(int value );
        public CTeSolicitacaoFiscalDTO FirstByUFInicio(string value );
        public CTeSolicitacaoFiscalDTO FirstByUFFim(string value );
        public CTeSolicitacaoFiscalDTO FirstByMunicipioInicioCodigoIbge(string value );
        public CTeSolicitacaoFiscalDTO FirstByMunicipioFimCodigoIbge(string value );
        public CTeSolicitacaoFiscalDTO FirstByValorServico(Decimal value );
        public CTeSolicitacaoFiscalDTO FirstByValorCarga(Decimal value );
        public CTeSolicitacaoFiscalDTO FirstByPreferenciasManifestoJson(string value );
        public CTeSolicitacaoFiscalDTO FirstByStatus(int value );
        public CTeSolicitacaoFiscalDTO FirstByTenantID(int value );
        public CTeSolicitacaoFiscalDTO FirstByDeleted(bool value );
        public CTeSolicitacaoFiscalDTO FirstByChanged(DateTime value );
        public CTeSolicitacaoFiscalDTO FirstByUserId(int value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllById(int value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByEntradaOficialId(int value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByRomaneioConsolidadoId(int value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByCorrelationId(string value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByAmbiente(int value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByUFEmitente(string value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByEmitenteDocumento(string value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByProdutoFiscal(int value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByTipoCTe(int value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByTipoServico(int value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByModal(int value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByGlobalizado(int value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByUFInicio(string value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByUFFim(string value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByMunicipioInicioCodigoIbge(string value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByMunicipioFimCodigoIbge(string value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByValorServico(Decimal value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByValorCarga(Decimal value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByPreferenciasManifestoJson(string value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByStatus(int value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByTenantID(int value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByDeleted(bool value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CTeSolicitacaoFiscalDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration