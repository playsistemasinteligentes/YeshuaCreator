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
    public partial interface IyTokenReadRepository
    {
        public DataPagination<yTokenDTO> getyToken(ICommandRead command , bool TakeOffTenantID = false);
        public IEnumerable<yTokenTenantIDDTO> getyTokenReadFKTenantID(object command , bool TakeOffTenantID = false);
        public IEnumerable<yTokenUserIdDTO> getyTokenReadFKUserId(object command , bool TakeOffTenantID = false);
        public bool ExistsById(int value , bool TakeOffTenantID = false);
        public bool ExistsByTokenHash(string value , bool TakeOffTenantID = false);
        public bool ExistsByDescription(string value , bool TakeOffTenantID = false);
        public bool ExistsByConnectorKey(string value , bool TakeOffTenantID = false);
        public bool ExistsByActive(bool value , bool TakeOffTenantID = false);
        public bool ExistsByValidUntil(DateTime value , bool TakeOffTenantID = false);
        public bool ExistsByCreatedAt(DateTime value , bool TakeOffTenantID = false);
        public bool ExistsByLastUsedAt(DateTime value , bool TakeOffTenantID = false);
        public bool ExistsByTenantID(int value , bool TakeOffTenantID = false);
        public bool ExistsByUserId(int value , bool TakeOffTenantID = false);
        public bool ExistsByDeleted(bool value , bool TakeOffTenantID = false);
        public bool ExistsByChanged(DateTime value , bool TakeOffTenantID = false);
        public yTokenDTO FirstById(int value , bool TakeOffTenantID = false);
        public yTokenDTO FirstByTokenHash(string value , bool TakeOffTenantID = false);
        public yTokenDTO FirstByDescription(string value , bool TakeOffTenantID = false);
        public yTokenDTO FirstByConnectorKey(string value , bool TakeOffTenantID = false);
        public yTokenDTO FirstByActive(bool value , bool TakeOffTenantID = false);
        public yTokenDTO FirstByValidUntil(DateTime value , bool TakeOffTenantID = false);
        public yTokenDTO FirstByCreatedAt(DateTime value , bool TakeOffTenantID = false);
        public yTokenDTO FirstByLastUsedAt(DateTime value , bool TakeOffTenantID = false);
        public yTokenDTO FirstByTenantID(int value , bool TakeOffTenantID = false);
        public yTokenDTO FirstByUserId(int value , bool TakeOffTenantID = false);
        public yTokenDTO FirstByDeleted(bool value , bool TakeOffTenantID = false);
        public yTokenDTO FirstByChanged(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<yTokenDTO> GetAllById(int value , bool TakeOffTenantID = false);
        public IEnumerable<yTokenDTO> GetAllByTokenHash(string value , bool TakeOffTenantID = false);
        public IEnumerable<yTokenDTO> GetAllByDescription(string value , bool TakeOffTenantID = false);
        public IEnumerable<yTokenDTO> GetAllByConnectorKey(string value , bool TakeOffTenantID = false);
        public IEnumerable<yTokenDTO> GetAllByActive(bool value , bool TakeOffTenantID = false);
        public IEnumerable<yTokenDTO> GetAllByValidUntil(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<yTokenDTO> GetAllByCreatedAt(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<yTokenDTO> GetAllByLastUsedAt(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<yTokenDTO> GetAllByTenantID(int value , bool TakeOffTenantID = false);
        public IEnumerable<yTokenDTO> GetAllByUserId(int value , bool TakeOffTenantID = false);
        public IEnumerable<yTokenDTO> GetAllByDeleted(bool value , bool TakeOffTenantID = false);
        public IEnumerable<yTokenDTO> GetAllByChanged(DateTime value , bool TakeOffTenantID = false);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration