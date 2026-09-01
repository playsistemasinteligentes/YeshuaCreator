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
    public partial interface IOrderTrackReadRepository
    {
        public DataPagination<OrderTrackDTO> getOrderTrack(ICommandRead command );
        public IEnumerable<OrderTrackORD_IDDTO> getOrderTrackReadFKORD_ID(object command );
        public IEnumerable<OrderTrackTenantIDDTO> getOrderTrackReadFKTenantID(object command );
        public IEnumerable<OrderTrackUserIdDTO> getOrderTrackReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByOTK_ID(int value );
        public bool ExistsByOTK_SEQUENCIA(Decimal value );
        public bool ExistsByOTK_VERSSAO(int value );
        public bool ExistsByORD_ID(string value );
        public bool ExistsByOTK_EVENTO(string value );
        public bool ExistsByOTK_DATA_NECESSIDADE_DE(DateTime value );
        public bool ExistsByOTK_DATA_NECESSIDADE_ATE(DateTime value );
        public bool ExistsByOTK_DATA_PREVISTA(DateTime value );
        public bool ExistsByOTK_DATA_REALIZADA(DateTime value );
        public bool ExistsByFPR_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public OrderTrackDTO FirstById(int value );
        public OrderTrackDTO FirstByOTK_ID(int value );
        public OrderTrackDTO FirstByOTK_SEQUENCIA(Decimal value );
        public OrderTrackDTO FirstByOTK_VERSSAO(int value );
        public OrderTrackDTO FirstByORD_ID(string value );
        public OrderTrackDTO FirstByOTK_EVENTO(string value );
        public OrderTrackDTO FirstByOTK_DATA_NECESSIDADE_DE(DateTime value );
        public OrderTrackDTO FirstByOTK_DATA_NECESSIDADE_ATE(DateTime value );
        public OrderTrackDTO FirstByOTK_DATA_PREVISTA(DateTime value );
        public OrderTrackDTO FirstByOTK_DATA_REALIZADA(DateTime value );
        public OrderTrackDTO FirstByFPR_ID(int value );
        public OrderTrackDTO FirstByTenantID(int value );
        public OrderTrackDTO FirstByDeleted(bool value );
        public OrderTrackDTO FirstByChanged(DateTime value );
        public OrderTrackDTO FirstByUserId(int value );
        public IEnumerable<OrderTrackDTO> GetAllById(int value );
        public IEnumerable<OrderTrackDTO> GetAllByOTK_ID(int value );
        public IEnumerable<OrderTrackDTO> GetAllByOTK_SEQUENCIA(Decimal value );
        public IEnumerable<OrderTrackDTO> GetAllByOTK_VERSSAO(int value );
        public IEnumerable<OrderTrackDTO> GetAllByORD_ID(string value );
        public IEnumerable<OrderTrackDTO> GetAllByOTK_EVENTO(string value );
        public IEnumerable<OrderTrackDTO> GetAllByOTK_DATA_NECESSIDADE_DE(DateTime value );
        public IEnumerable<OrderTrackDTO> GetAllByOTK_DATA_NECESSIDADE_ATE(DateTime value );
        public IEnumerable<OrderTrackDTO> GetAllByOTK_DATA_PREVISTA(DateTime value );
        public IEnumerable<OrderTrackDTO> GetAllByOTK_DATA_REALIZADA(DateTime value );
        public IEnumerable<OrderTrackDTO> GetAllByFPR_ID(int value );
        public IEnumerable<OrderTrackDTO> GetAllByTenantID(int value );
        public IEnumerable<OrderTrackDTO> GetAllByDeleted(bool value );
        public IEnumerable<OrderTrackDTO> GetAllByChanged(DateTime value );
        public IEnumerable<OrderTrackDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration