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
    public partial interface IPendenciasInterfaceReadRepository
    {
        public DataPagination<PendenciasInterfaceDTO> getPendenciasInterface(ICommandRead command );
        public IEnumerable<PendenciasInterfaceTenantIDDTO> getPendenciasInterfaceReadFKTenantID(object command );
        public IEnumerable<PendenciasInterfaceUserIdDTO> getPendenciasInterfaceReadFKUserId(object command );
        public bool ExistsByPEN_STATUS_OUT(string value );
        public bool ExistsByPEN_PROTOCOLO_OUT(string value );
        public bool ExistsByPEN_ID_PROTOCOLO_OUT(string value );
        public bool ExistsByPEN_STATUS_IN(string value );
        public bool ExistsByPEN_PROTOCOLO_IN(string value );
        public bool ExistsByPEN_ID_PROTOCOLO_IN(string value );
        public bool ExistsByDATA_ENTRADA(DateTime value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public bool ExistsByPEN_ID(int value );
        public PendenciasInterfaceDTO FirstByPEN_STATUS_OUT(string value );
        public PendenciasInterfaceDTO FirstByPEN_PROTOCOLO_OUT(string value );
        public PendenciasInterfaceDTO FirstByPEN_ID_PROTOCOLO_OUT(string value );
        public PendenciasInterfaceDTO FirstByPEN_STATUS_IN(string value );
        public PendenciasInterfaceDTO FirstByPEN_PROTOCOLO_IN(string value );
        public PendenciasInterfaceDTO FirstByPEN_ID_PROTOCOLO_IN(string value );
        public PendenciasInterfaceDTO FirstByDATA_ENTRADA(DateTime value );
        public PendenciasInterfaceDTO FirstByTenantID(int value );
        public PendenciasInterfaceDTO FirstByDeleted(bool value );
        public PendenciasInterfaceDTO FirstByChanged(DateTime value );
        public PendenciasInterfaceDTO FirstByUserId(int value );
        public PendenciasInterfaceDTO FirstByPEN_ID(int value );
        public IEnumerable<PendenciasInterfaceDTO> GetAllByPEN_STATUS_OUT(string value );
        public IEnumerable<PendenciasInterfaceDTO> GetAllByPEN_PROTOCOLO_OUT(string value );
        public IEnumerable<PendenciasInterfaceDTO> GetAllByPEN_ID_PROTOCOLO_OUT(string value );
        public IEnumerable<PendenciasInterfaceDTO> GetAllByPEN_STATUS_IN(string value );
        public IEnumerable<PendenciasInterfaceDTO> GetAllByPEN_PROTOCOLO_IN(string value );
        public IEnumerable<PendenciasInterfaceDTO> GetAllByPEN_ID_PROTOCOLO_IN(string value );
        public IEnumerable<PendenciasInterfaceDTO> GetAllByDATA_ENTRADA(DateTime value );
        public IEnumerable<PendenciasInterfaceDTO> GetAllByTenantID(int value );
        public IEnumerable<PendenciasInterfaceDTO> GetAllByDeleted(bool value );
        public IEnumerable<PendenciasInterfaceDTO> GetAllByChanged(DateTime value );
        public IEnumerable<PendenciasInterfaceDTO> GetAllByUserId(int value );
        public IEnumerable<PendenciasInterfaceDTO> GetAllByPEN_ID(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration