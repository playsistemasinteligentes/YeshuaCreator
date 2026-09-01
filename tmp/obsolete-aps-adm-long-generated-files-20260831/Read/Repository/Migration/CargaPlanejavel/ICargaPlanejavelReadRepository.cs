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
    public partial interface ICargaPlanejavelReadRepository
    {
        public DataPagination<CargaPlanejavelDTO> getCargaPlanejavel(ICommandRead command );
        public bool ExistsByCargaId(string value );
        public bool ExistsByStatus(string value );
        public bool ExistsByTransportadoraId(string value );
        public bool ExistsByVeiculoId(string value );
        public bool ExistsByTipoVeiculoId(int value );
        public bool ExistsByPesoTeorico(Decimal value );
        public bool ExistsByVolumeTeorico(Decimal value );
        public bool ExistsByInicioJanelaEmbarque(DateTime value );
        public bool ExistsByFimJanelaEmbarque(DateTime value );
        public bool ExistsByEmbarqueAlvo(DateTime value );
        public bool ExistsByQuantidadePedidos(int value );
        public bool ExistsByAlertasResumo(string value );
        public CargaPlanejavelDTO FirstByCargaId(string value );
        public CargaPlanejavelDTO FirstByStatus(string value );
        public CargaPlanejavelDTO FirstByTransportadoraId(string value );
        public CargaPlanejavelDTO FirstByVeiculoId(string value );
        public CargaPlanejavelDTO FirstByTipoVeiculoId(int value );
        public CargaPlanejavelDTO FirstByPesoTeorico(Decimal value );
        public CargaPlanejavelDTO FirstByVolumeTeorico(Decimal value );
        public CargaPlanejavelDTO FirstByInicioJanelaEmbarque(DateTime value );
        public CargaPlanejavelDTO FirstByFimJanelaEmbarque(DateTime value );
        public CargaPlanejavelDTO FirstByEmbarqueAlvo(DateTime value );
        public CargaPlanejavelDTO FirstByQuantidadePedidos(int value );
        public CargaPlanejavelDTO FirstByAlertasResumo(string value );
        public IEnumerable<CargaPlanejavelDTO> GetAllByCargaId(string value );
        public IEnumerable<CargaPlanejavelDTO> GetAllByStatus(string value );
        public IEnumerable<CargaPlanejavelDTO> GetAllByTransportadoraId(string value );
        public IEnumerable<CargaPlanejavelDTO> GetAllByVeiculoId(string value );
        public IEnumerable<CargaPlanejavelDTO> GetAllByTipoVeiculoId(int value );
        public IEnumerable<CargaPlanejavelDTO> GetAllByPesoTeorico(Decimal value );
        public IEnumerable<CargaPlanejavelDTO> GetAllByVolumeTeorico(Decimal value );
        public IEnumerable<CargaPlanejavelDTO> GetAllByInicioJanelaEmbarque(DateTime value );
        public IEnumerable<CargaPlanejavelDTO> GetAllByFimJanelaEmbarque(DateTime value );
        public IEnumerable<CargaPlanejavelDTO> GetAllByEmbarqueAlvo(DateTime value );
        public IEnumerable<CargaPlanejavelDTO> GetAllByQuantidadePedidos(int value );
        public IEnumerable<CargaPlanejavelDTO> GetAllByAlertasResumo(string value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration