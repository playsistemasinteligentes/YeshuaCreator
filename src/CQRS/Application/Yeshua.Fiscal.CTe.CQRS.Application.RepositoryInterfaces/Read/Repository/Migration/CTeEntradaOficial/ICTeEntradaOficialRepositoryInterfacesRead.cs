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
    public partial interface ICTeEntradaOficialReadRepository
    {
        public DataPagination<CTeEntradaOficialDTO> getCTeEntradaOficial(ICommandRead command );
        public IEnumerable<CTeEntradaOficialTenantIDDTO> getCTeEntradaOficialReadFKTenantID(object command );
        public IEnumerable<CTeEntradaOficialUserIdDTO> getCTeEntradaOficialReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCorrelationId(string value );
        public bool ExistsBySourceApplication(string value );
        public bool ExistsBySourceModule(string value );
        public bool ExistsBySourceMessageId(string value );
        public bool ExistsByMessageType(string value );
        public bool ExistsByMessageVersion(string value );
        public bool ExistsByReceivedAtUtc(DateTime value );
        public bool ExistsByPayloadHash(string value );
        public bool ExistsByPayloadStorageKey(string value );
        public bool ExistsByStatus(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public CTeEntradaOficialDTO FirstById(int value );
        public CTeEntradaOficialDTO FirstByCorrelationId(string value );
        public CTeEntradaOficialDTO FirstBySourceApplication(string value );
        public CTeEntradaOficialDTO FirstBySourceModule(string value );
        public CTeEntradaOficialDTO FirstBySourceMessageId(string value );
        public CTeEntradaOficialDTO FirstByMessageType(string value );
        public CTeEntradaOficialDTO FirstByMessageVersion(string value );
        public CTeEntradaOficialDTO FirstByReceivedAtUtc(DateTime value );
        public CTeEntradaOficialDTO FirstByPayloadHash(string value );
        public CTeEntradaOficialDTO FirstByPayloadStorageKey(string value );
        public CTeEntradaOficialDTO FirstByStatus(int value );
        public CTeEntradaOficialDTO FirstByTenantID(int value );
        public CTeEntradaOficialDTO FirstByDeleted(bool value );
        public CTeEntradaOficialDTO FirstByChanged(DateTime value );
        public CTeEntradaOficialDTO FirstByUserId(int value );
        public IEnumerable<CTeEntradaOficialDTO> GetAllById(int value );
        public IEnumerable<CTeEntradaOficialDTO> GetAllByCorrelationId(string value );
        public IEnumerable<CTeEntradaOficialDTO> GetAllBySourceApplication(string value );
        public IEnumerable<CTeEntradaOficialDTO> GetAllBySourceModule(string value );
        public IEnumerable<CTeEntradaOficialDTO> GetAllBySourceMessageId(string value );
        public IEnumerable<CTeEntradaOficialDTO> GetAllByMessageType(string value );
        public IEnumerable<CTeEntradaOficialDTO> GetAllByMessageVersion(string value );
        public IEnumerable<CTeEntradaOficialDTO> GetAllByReceivedAtUtc(DateTime value );
        public IEnumerable<CTeEntradaOficialDTO> GetAllByPayloadHash(string value );
        public IEnumerable<CTeEntradaOficialDTO> GetAllByPayloadStorageKey(string value );
        public IEnumerable<CTeEntradaOficialDTO> GetAllByStatus(int value );
        public IEnumerable<CTeEntradaOficialDTO> GetAllByTenantID(int value );
        public IEnumerable<CTeEntradaOficialDTO> GetAllByDeleted(bool value );
        public IEnumerable<CTeEntradaOficialDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CTeEntradaOficialDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration