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
    public partial interface IExperienciaPlanejamentoTransporteReadRepository
    {
        public DataPagination<ExperienciaPlanejamentoTransporteDTO> getExperienciaPlanejamentoTransporte(ICommandRead command );
        public IEnumerable<ExperienciaPlanejamentoTransporteTenantIDDTO> getExperienciaPlanejamentoTransporteReadFKTenantID(object command );
        public IEnumerable<ExperienciaPlanejamentoTransporteUserIdDTO> getExperienciaPlanejamentoTransporteReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByTipo(int value );
        public bool ExistsByReferencia(string value );
        public bool ExistsByPedidoId(string value );
        public bool ExistsByClienteId(string value );
        public bool ExistsByMunicipio(string value );
        public bool ExistsByRegiao(string value );
        public bool ExistsByRotaId(string value );
        public bool ExistsByPeso(Decimal value );
        public bool ExistsByVolume(Decimal value );
        public bool ExistsByObservacao(string value );
        public bool ExistsByCriadoEm(DateTime value );
        public bool ExistsByCriadoPor(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ExperienciaPlanejamentoTransporteDTO FirstById(int value );
        public ExperienciaPlanejamentoTransporteDTO FirstByTipo(int value );
        public ExperienciaPlanejamentoTransporteDTO FirstByReferencia(string value );
        public ExperienciaPlanejamentoTransporteDTO FirstByPedidoId(string value );
        public ExperienciaPlanejamentoTransporteDTO FirstByClienteId(string value );
        public ExperienciaPlanejamentoTransporteDTO FirstByMunicipio(string value );
        public ExperienciaPlanejamentoTransporteDTO FirstByRegiao(string value );
        public ExperienciaPlanejamentoTransporteDTO FirstByRotaId(string value );
        public ExperienciaPlanejamentoTransporteDTO FirstByPeso(Decimal value );
        public ExperienciaPlanejamentoTransporteDTO FirstByVolume(Decimal value );
        public ExperienciaPlanejamentoTransporteDTO FirstByObservacao(string value );
        public ExperienciaPlanejamentoTransporteDTO FirstByCriadoEm(DateTime value );
        public ExperienciaPlanejamentoTransporteDTO FirstByCriadoPor(string value );
        public ExperienciaPlanejamentoTransporteDTO FirstByTenantID(int value );
        public ExperienciaPlanejamentoTransporteDTO FirstByDeleted(bool value );
        public ExperienciaPlanejamentoTransporteDTO FirstByChanged(DateTime value );
        public ExperienciaPlanejamentoTransporteDTO FirstByUserId(int value );
        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllById(int value );
        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByTipo(int value );
        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByReferencia(string value );
        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByPedidoId(string value );
        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByClienteId(string value );
        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByMunicipio(string value );
        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByRegiao(string value );
        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByRotaId(string value );
        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByPeso(Decimal value );
        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByVolume(Decimal value );
        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByObservacao(string value );
        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByCriadoEm(DateTime value );
        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByCriadoPor(string value );
        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByTenantID(int value );
        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByDeleted(bool value );
        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ExperienciaPlanejamentoTransporteDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration