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
    public partial interface ITemposLogisticosReadRepository
    {
        public DataPagination<TemposLogisticosDTO> getTemposLogisticos(ICommandRead command );
        public IEnumerable<TemposLogisticosTenantIDDTO> getTemposLogisticosReadFKTenantID(object command );
        public IEnumerable<TemposLogisticosUserIdDTO> getTemposLogisticosReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByTMP_TIPO_TEMPO(string value );
        public bool ExistsByTMP_TIPO_CARGA(string value );
        public bool ExistsByTMP_TEMPO_MEDIO_UNITARIO(Decimal value );
        public bool ExistsByCLI_ID(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TemposLogisticosDTO FirstById(int value );
        public TemposLogisticosDTO FirstByTMP_TIPO_TEMPO(string value );
        public TemposLogisticosDTO FirstByTMP_TIPO_CARGA(string value );
        public TemposLogisticosDTO FirstByTMP_TEMPO_MEDIO_UNITARIO(Decimal value );
        public TemposLogisticosDTO FirstByCLI_ID(string value );
        public TemposLogisticosDTO FirstByTenantID(int value );
        public TemposLogisticosDTO FirstByDeleted(bool value );
        public TemposLogisticosDTO FirstByChanged(DateTime value );
        public TemposLogisticosDTO FirstByUserId(int value );
        public IEnumerable<TemposLogisticosDTO> GetAllById(int value );
        public IEnumerable<TemposLogisticosDTO> GetAllByTMP_TIPO_TEMPO(string value );
        public IEnumerable<TemposLogisticosDTO> GetAllByTMP_TIPO_CARGA(string value );
        public IEnumerable<TemposLogisticosDTO> GetAllByTMP_TEMPO_MEDIO_UNITARIO(Decimal value );
        public IEnumerable<TemposLogisticosDTO> GetAllByCLI_ID(string value );
        public IEnumerable<TemposLogisticosDTO> GetAllByTenantID(int value );
        public IEnumerable<TemposLogisticosDTO> GetAllByDeleted(bool value );
        public IEnumerable<TemposLogisticosDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TemposLogisticosDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration