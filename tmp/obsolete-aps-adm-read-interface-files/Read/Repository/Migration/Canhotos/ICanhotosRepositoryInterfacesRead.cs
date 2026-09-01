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
    public partial interface ICanhotosReadRepository
    {
        public DataPagination<CanhotosDTO> getCanhotos(ICommandRead command );
        public IEnumerable<CanhotosTenantIDDTO> getCanhotosReadFKTenantID(object command );
        public IEnumerable<CanhotosUserIdDTO> getCanhotosReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCAR_ID(string value );
        public bool ExistsByORD_ID(string value );
        public bool ExistsByNOT_ID(string value );
        public bool ExistsByCAN_DATA_ENTREGA(DateTime value );
        public bool ExistsByCAN_IMG(string value );
        public bool ExistsByCAN_LAT_ENTREGA(Decimal value );
        public bool ExistsByCAN_LONG_ENTREGA(Decimal value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public CanhotosDTO FirstById(int value );
        public CanhotosDTO FirstByCAR_ID(string value );
        public CanhotosDTO FirstByORD_ID(string value );
        public CanhotosDTO FirstByNOT_ID(string value );
        public CanhotosDTO FirstByCAN_DATA_ENTREGA(DateTime value );
        public CanhotosDTO FirstByCAN_IMG(string value );
        public CanhotosDTO FirstByCAN_LAT_ENTREGA(Decimal value );
        public CanhotosDTO FirstByCAN_LONG_ENTREGA(Decimal value );
        public CanhotosDTO FirstByTenantID(int value );
        public CanhotosDTO FirstByDeleted(bool value );
        public CanhotosDTO FirstByChanged(DateTime value );
        public CanhotosDTO FirstByUserId(int value );
        public IEnumerable<CanhotosDTO> GetAllById(int value );
        public IEnumerable<CanhotosDTO> GetAllByCAR_ID(string value );
        public IEnumerable<CanhotosDTO> GetAllByORD_ID(string value );
        public IEnumerable<CanhotosDTO> GetAllByNOT_ID(string value );
        public IEnumerable<CanhotosDTO> GetAllByCAN_DATA_ENTREGA(DateTime value );
        public IEnumerable<CanhotosDTO> GetAllByCAN_IMG(string value );
        public IEnumerable<CanhotosDTO> GetAllByCAN_LAT_ENTREGA(Decimal value );
        public IEnumerable<CanhotosDTO> GetAllByCAN_LONG_ENTREGA(Decimal value );
        public IEnumerable<CanhotosDTO> GetAllByTenantID(int value );
        public IEnumerable<CanhotosDTO> GetAllByDeleted(bool value );
        public IEnumerable<CanhotosDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CanhotosDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration