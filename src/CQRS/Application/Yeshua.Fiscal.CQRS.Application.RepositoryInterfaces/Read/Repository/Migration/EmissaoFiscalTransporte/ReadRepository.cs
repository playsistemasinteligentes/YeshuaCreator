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
    public partial interface IEmissaoFiscalTransporteReadRepository
    {
        public DataPagination<EmissaoFiscalTransporteDTO> getEmissaoFiscalTransporte(ICommandRead command );
        public IEnumerable<EmissaoFiscalTransporteTenantIDDTO> getEmissaoFiscalTransporteReadFKTenantID(object command );
        public IEnumerable<EmissaoFiscalTransporteUserIdDTO> getEmissaoFiscalTransporteReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCorrelationId(string value );
        public bool ExistsByOrigemFluxo(int value );
        public bool ExistsByCargaId(string value );
        public bool ExistsByRomaneioId(string value );
        public bool ExistsByAmbiente(int value );
        public bool ExistsByEmitenteDocumento(string value );
        public bool ExistsByTomadorDocumento(string value );
        public bool ExistsByTransportadorDocumento(string value );
        public bool ExistsByUFInicio(string value );
        public bool ExistsByUFFim(string value );
        public bool ExistsByMunicipioInicioCodigoIbge(string value );
        public bool ExistsByMunicipioFimCodigoIbge(string value );
        public bool ExistsByQuantidadeNFe(int value );
        public bool ExistsByQuantidadeCTe(int value );
        public bool ExistsByQuantidadeMDFe(int value );
        public bool ExistsByValorCarga(Decimal value );
        public bool ExistsByPesoBruto(Decimal value );
        public bool ExistsByVolume(Decimal value );
        public bool ExistsByUltimaMensagem(string value );
        public bool ExistsByCriadoEmUtc(DateTime value );
        public bool ExistsByAtualizadoEmUtc(DateTime value );
        public bool ExistsByConcluidoEmUtc(DateTime value );
        public bool ExistsByStatus(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public EmissaoFiscalTransporteDTO FirstById(int value );
        public EmissaoFiscalTransporteDTO FirstByCorrelationId(string value );
        public EmissaoFiscalTransporteDTO FirstByOrigemFluxo(int value );
        public EmissaoFiscalTransporteDTO FirstByCargaId(string value );
        public EmissaoFiscalTransporteDTO FirstByRomaneioId(string value );
        public EmissaoFiscalTransporteDTO FirstByAmbiente(int value );
        public EmissaoFiscalTransporteDTO FirstByEmitenteDocumento(string value );
        public EmissaoFiscalTransporteDTO FirstByTomadorDocumento(string value );
        public EmissaoFiscalTransporteDTO FirstByTransportadorDocumento(string value );
        public EmissaoFiscalTransporteDTO FirstByUFInicio(string value );
        public EmissaoFiscalTransporteDTO FirstByUFFim(string value );
        public EmissaoFiscalTransporteDTO FirstByMunicipioInicioCodigoIbge(string value );
        public EmissaoFiscalTransporteDTO FirstByMunicipioFimCodigoIbge(string value );
        public EmissaoFiscalTransporteDTO FirstByQuantidadeNFe(int value );
        public EmissaoFiscalTransporteDTO FirstByQuantidadeCTe(int value );
        public EmissaoFiscalTransporteDTO FirstByQuantidadeMDFe(int value );
        public EmissaoFiscalTransporteDTO FirstByValorCarga(Decimal value );
        public EmissaoFiscalTransporteDTO FirstByPesoBruto(Decimal value );
        public EmissaoFiscalTransporteDTO FirstByVolume(Decimal value );
        public EmissaoFiscalTransporteDTO FirstByUltimaMensagem(string value );
        public EmissaoFiscalTransporteDTO FirstByCriadoEmUtc(DateTime value );
        public EmissaoFiscalTransporteDTO FirstByAtualizadoEmUtc(DateTime value );
        public EmissaoFiscalTransporteDTO FirstByConcluidoEmUtc(DateTime value );
        public EmissaoFiscalTransporteDTO FirstByStatus(int value );
        public EmissaoFiscalTransporteDTO FirstByTenantID(int value );
        public EmissaoFiscalTransporteDTO FirstByDeleted(bool value );
        public EmissaoFiscalTransporteDTO FirstByChanged(DateTime value );
        public EmissaoFiscalTransporteDTO FirstByUserId(int value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllById(int value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByCorrelationId(string value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByOrigemFluxo(int value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByCargaId(string value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByRomaneioId(string value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByAmbiente(int value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByEmitenteDocumento(string value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByTomadorDocumento(string value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByTransportadorDocumento(string value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByUFInicio(string value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByUFFim(string value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByMunicipioInicioCodigoIbge(string value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByMunicipioFimCodigoIbge(string value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByQuantidadeNFe(int value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByQuantidadeCTe(int value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByQuantidadeMDFe(int value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByValorCarga(Decimal value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByPesoBruto(Decimal value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByVolume(Decimal value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByUltimaMensagem(string value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByCriadoEmUtc(DateTime value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByAtualizadoEmUtc(DateTime value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByConcluidoEmUtc(DateTime value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByStatus(int value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByTenantID(int value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByDeleted(bool value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByChanged(DateTime value );
        public IEnumerable<EmissaoFiscalTransporteDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration