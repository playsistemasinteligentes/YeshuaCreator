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
    public partial interface ICTeRomaneioConsolidadoReadRepository
    {
        public DataPagination<CTeRomaneioConsolidadoDTO> getCTeRomaneioConsolidado(ICommandRead command );
        public IEnumerable<CTeRomaneioConsolidadoEntradaOficialIdDTO> getCTeRomaneioConsolidadoReadFKEntradaOficialId(object command );
        public IEnumerable<CTeRomaneioConsolidadoTenantIDDTO> getCTeRomaneioConsolidadoReadFKTenantID(object command );
        public IEnumerable<CTeRomaneioConsolidadoUserIdDTO> getCTeRomaneioConsolidadoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByEntradaOficialId(int value );
        public bool ExistsByCorrelationId(string value );
        public bool ExistsByRomaneioId(string value );
        public bool ExistsByCargaId(string value );
        public bool ExistsByConsolidadoEmUtc(DateTime value );
        public bool ExistsByUFInicio(string value );
        public bool ExistsByUFFim(string value );
        public bool ExistsByMunicipioInicioCodigoIbge(string value );
        public bool ExistsByMunicipioFimCodigoIbge(string value );
        public bool ExistsByEmitenteDocumento(string value );
        public bool ExistsByTomadorDocumento(string value );
        public bool ExistsByRotaSnapshotJson(string value );
        public bool ExistsByCargaSnapshotJson(string value );
        public bool ExistsByPreferenciasFiscaisJson(string value );
        public bool ExistsByStatus(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public CTeRomaneioConsolidadoDTO FirstById(int value );
        public CTeRomaneioConsolidadoDTO FirstByEntradaOficialId(int value );
        public CTeRomaneioConsolidadoDTO FirstByCorrelationId(string value );
        public CTeRomaneioConsolidadoDTO FirstByRomaneioId(string value );
        public CTeRomaneioConsolidadoDTO FirstByCargaId(string value );
        public CTeRomaneioConsolidadoDTO FirstByConsolidadoEmUtc(DateTime value );
        public CTeRomaneioConsolidadoDTO FirstByUFInicio(string value );
        public CTeRomaneioConsolidadoDTO FirstByUFFim(string value );
        public CTeRomaneioConsolidadoDTO FirstByMunicipioInicioCodigoIbge(string value );
        public CTeRomaneioConsolidadoDTO FirstByMunicipioFimCodigoIbge(string value );
        public CTeRomaneioConsolidadoDTO FirstByEmitenteDocumento(string value );
        public CTeRomaneioConsolidadoDTO FirstByTomadorDocumento(string value );
        public CTeRomaneioConsolidadoDTO FirstByRotaSnapshotJson(string value );
        public CTeRomaneioConsolidadoDTO FirstByCargaSnapshotJson(string value );
        public CTeRomaneioConsolidadoDTO FirstByPreferenciasFiscaisJson(string value );
        public CTeRomaneioConsolidadoDTO FirstByStatus(int value );
        public CTeRomaneioConsolidadoDTO FirstByTenantID(int value );
        public CTeRomaneioConsolidadoDTO FirstByDeleted(bool value );
        public CTeRomaneioConsolidadoDTO FirstByChanged(DateTime value );
        public CTeRomaneioConsolidadoDTO FirstByUserId(int value );
        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllById(int value );
        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByEntradaOficialId(int value );
        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByCorrelationId(string value );
        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByRomaneioId(string value );
        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByCargaId(string value );
        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByConsolidadoEmUtc(DateTime value );
        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByUFInicio(string value );
        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByUFFim(string value );
        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByMunicipioInicioCodigoIbge(string value );
        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByMunicipioFimCodigoIbge(string value );
        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByEmitenteDocumento(string value );
        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByTomadorDocumento(string value );
        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByRotaSnapshotJson(string value );
        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByCargaSnapshotJson(string value );
        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByPreferenciasFiscaisJson(string value );
        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByStatus(int value );
        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByTenantID(int value );
        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByDeleted(bool value );
        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CTeRomaneioConsolidadoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration