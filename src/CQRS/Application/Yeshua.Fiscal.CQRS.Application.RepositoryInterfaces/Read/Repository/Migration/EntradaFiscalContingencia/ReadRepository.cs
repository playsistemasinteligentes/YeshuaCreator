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
    public partial interface IEntradaFiscalContingenciaReadRepository
    {
        public DataPagination<EntradaFiscalContingenciaDTO> getEntradaFiscalContingencia(ICommandRead command );
        public IEnumerable<EntradaFiscalContingenciaTenantIDDTO> getEntradaFiscalContingenciaReadFKTenantID(object command );
        public IEnumerable<EntradaFiscalContingenciaUserIdDTO> getEntradaFiscalContingenciaReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCorrelationId(string value );
        public bool ExistsByCargaId(string value );
        public bool ExistsByTipoSolicitante(int value );
        public bool ExistsByAmbiente(int value );
        public bool ExistsBySourceApplication(string value );
        public bool ExistsBySourceModule(string value );
        public bool ExistsBySourceMessageId(string value );
        public bool ExistsByEmitenteFiscalDocumento(string value );
        public bool ExistsByTomadorDocumento(string value );
        public bool ExistsByTransportadorDocumento(string value );
        public bool ExistsByRemetenteDocumento(string value );
        public bool ExistsByDestinatarioDocumento(string value );
        public bool ExistsByUFInicio(string value );
        public bool ExistsByUFFim(string value );
        public bool ExistsByMunicipioInicioCodigoIbge(string value );
        public bool ExistsByMunicipioFimCodigoIbge(string value );
        public bool ExistsByRNTRC(string value );
        public bool ExistsByPlacaVeiculo(string value );
        public bool ExistsByUFVeiculo(string value );
        public bool ExistsByCondutorDocumento(string value );
        public bool ExistsByCondutorNome(string value );
        public bool ExistsByQuantidadeDocumentos(int value );
        public bool ExistsByValorCarga(Decimal value );
        public bool ExistsByPesoBruto(Decimal value );
        public bool ExistsByVolume(Decimal value );
        public bool ExistsByPendenciasJson(string value );
        public bool ExistsBySnapshotJson(string value );
        public bool ExistsByEmissaoFiscalCorrelationId(string value );
        public bool ExistsByEmissaoFiscalSagaId(int value );
        public bool ExistsByCriadoEmUtc(DateTime value );
        public bool ExistsByAtualizadoEmUtc(DateTime value );
        public bool ExistsByStatus(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public EntradaFiscalContingenciaDTO FirstById(int value );
        public EntradaFiscalContingenciaDTO FirstByCorrelationId(string value );
        public EntradaFiscalContingenciaDTO FirstByCargaId(string value );
        public EntradaFiscalContingenciaDTO FirstByTipoSolicitante(int value );
        public EntradaFiscalContingenciaDTO FirstByAmbiente(int value );
        public EntradaFiscalContingenciaDTO FirstBySourceApplication(string value );
        public EntradaFiscalContingenciaDTO FirstBySourceModule(string value );
        public EntradaFiscalContingenciaDTO FirstBySourceMessageId(string value );
        public EntradaFiscalContingenciaDTO FirstByEmitenteFiscalDocumento(string value );
        public EntradaFiscalContingenciaDTO FirstByTomadorDocumento(string value );
        public EntradaFiscalContingenciaDTO FirstByTransportadorDocumento(string value );
        public EntradaFiscalContingenciaDTO FirstByRemetenteDocumento(string value );
        public EntradaFiscalContingenciaDTO FirstByDestinatarioDocumento(string value );
        public EntradaFiscalContingenciaDTO FirstByUFInicio(string value );
        public EntradaFiscalContingenciaDTO FirstByUFFim(string value );
        public EntradaFiscalContingenciaDTO FirstByMunicipioInicioCodigoIbge(string value );
        public EntradaFiscalContingenciaDTO FirstByMunicipioFimCodigoIbge(string value );
        public EntradaFiscalContingenciaDTO FirstByRNTRC(string value );
        public EntradaFiscalContingenciaDTO FirstByPlacaVeiculo(string value );
        public EntradaFiscalContingenciaDTO FirstByUFVeiculo(string value );
        public EntradaFiscalContingenciaDTO FirstByCondutorDocumento(string value );
        public EntradaFiscalContingenciaDTO FirstByCondutorNome(string value );
        public EntradaFiscalContingenciaDTO FirstByQuantidadeDocumentos(int value );
        public EntradaFiscalContingenciaDTO FirstByValorCarga(Decimal value );
        public EntradaFiscalContingenciaDTO FirstByPesoBruto(Decimal value );
        public EntradaFiscalContingenciaDTO FirstByVolume(Decimal value );
        public EntradaFiscalContingenciaDTO FirstByPendenciasJson(string value );
        public EntradaFiscalContingenciaDTO FirstBySnapshotJson(string value );
        public EntradaFiscalContingenciaDTO FirstByEmissaoFiscalCorrelationId(string value );
        public EntradaFiscalContingenciaDTO FirstByEmissaoFiscalSagaId(int value );
        public EntradaFiscalContingenciaDTO FirstByCriadoEmUtc(DateTime value );
        public EntradaFiscalContingenciaDTO FirstByAtualizadoEmUtc(DateTime value );
        public EntradaFiscalContingenciaDTO FirstByStatus(int value );
        public EntradaFiscalContingenciaDTO FirstByTenantID(int value );
        public EntradaFiscalContingenciaDTO FirstByDeleted(bool value );
        public EntradaFiscalContingenciaDTO FirstByChanged(DateTime value );
        public EntradaFiscalContingenciaDTO FirstByUserId(int value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllById(int value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByCorrelationId(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByCargaId(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByTipoSolicitante(int value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByAmbiente(int value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllBySourceApplication(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllBySourceModule(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllBySourceMessageId(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByEmitenteFiscalDocumento(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByTomadorDocumento(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByTransportadorDocumento(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByRemetenteDocumento(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByDestinatarioDocumento(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByUFInicio(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByUFFim(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByMunicipioInicioCodigoIbge(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByMunicipioFimCodigoIbge(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByRNTRC(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByPlacaVeiculo(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByUFVeiculo(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByCondutorDocumento(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByCondutorNome(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByQuantidadeDocumentos(int value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByValorCarga(Decimal value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByPesoBruto(Decimal value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByVolume(Decimal value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByPendenciasJson(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllBySnapshotJson(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByEmissaoFiscalCorrelationId(string value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByEmissaoFiscalSagaId(int value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByCriadoEmUtc(DateTime value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByAtualizadoEmUtc(DateTime value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByStatus(int value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByTenantID(int value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByDeleted(bool value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<EntradaFiscalContingenciaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration