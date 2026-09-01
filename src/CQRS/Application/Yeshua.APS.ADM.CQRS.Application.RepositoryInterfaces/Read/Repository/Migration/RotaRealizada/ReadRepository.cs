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
    public partial interface IRotaRealizadaReadRepository
    {
        public DataPagination<RotaRealizadaDTO> getRotaRealizada(ICommandRead command );
        public IEnumerable<RotaRealizadaTenantIDDTO> getRotaRealizadaReadFKTenantID(object command );
        public IEnumerable<RotaRealizadaUserIdDTO> getRotaRealizadaReadFKUserId(object command );
        public bool ExistsByROT_ID(int value );
        public bool ExistsByCAR_ID(string value );
        public bool ExistsByROT_DATA_HORA(DateTime value );
        public bool ExistsByROT_LAT(Decimal value );
        public bool ExistsByROT_LONG(Decimal value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public RotaRealizadaDTO FirstByROT_ID(int value );
        public RotaRealizadaDTO FirstByCAR_ID(string value );
        public RotaRealizadaDTO FirstByROT_DATA_HORA(DateTime value );
        public RotaRealizadaDTO FirstByROT_LAT(Decimal value );
        public RotaRealizadaDTO FirstByROT_LONG(Decimal value );
        public RotaRealizadaDTO FirstByTenantID(int value );
        public RotaRealizadaDTO FirstByDeleted(bool value );
        public RotaRealizadaDTO FirstByChanged(DateTime value );
        public RotaRealizadaDTO FirstByUserId(int value );
        public IEnumerable<RotaRealizadaDTO> GetAllByROT_ID(int value );
        public IEnumerable<RotaRealizadaDTO> GetAllByCAR_ID(string value );
        public IEnumerable<RotaRealizadaDTO> GetAllByROT_DATA_HORA(DateTime value );
        public IEnumerable<RotaRealizadaDTO> GetAllByROT_LAT(Decimal value );
        public IEnumerable<RotaRealizadaDTO> GetAllByROT_LONG(Decimal value );
        public IEnumerable<RotaRealizadaDTO> GetAllByTenantID(int value );
        public IEnumerable<RotaRealizadaDTO> GetAllByDeleted(bool value );
        public IEnumerable<RotaRealizadaDTO> GetAllByChanged(DateTime value );
        public IEnumerable<RotaRealizadaDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration