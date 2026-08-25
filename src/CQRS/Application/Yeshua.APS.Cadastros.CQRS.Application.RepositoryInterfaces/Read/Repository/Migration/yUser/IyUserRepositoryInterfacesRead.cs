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
    public partial interface IyUserReadRepository
    {
        public DataPagination<yUserDTO> getyUser(ICommandRead command , bool TakeOffTenantID = false);
        public IEnumerable<yUserTenantIDDTO> getyUserReadFKTenantID(object command , bool TakeOffTenantID = false);
        public bool ExistsById(int value , bool TakeOffTenantID = false);
        public bool ExistsByNome(string value , bool TakeOffTenantID = false);
        public bool ExistsByEmail(string value , bool TakeOffTenantID = false);
        public bool ExistsBySenha(string value , bool TakeOffTenantID = false);
        public bool ExistsByTenantID(int value , bool TakeOffTenantID = false);
        public bool ExistsByDeleted(bool value , bool TakeOffTenantID = false);
        public bool ExistsByChanged(DateTime value , bool TakeOffTenantID = false);
        public yUserDTO FirstById(int value , bool TakeOffTenantID = false);
        public yUserDTO FirstByNome(string value , bool TakeOffTenantID = false);
        public yUserDTO FirstByEmail(string value , bool TakeOffTenantID = false);
        public yUserDTO FirstBySenha(string value , bool TakeOffTenantID = false);
        public yUserDTO FirstByTenantID(int value , bool TakeOffTenantID = false);
        public yUserDTO FirstByDeleted(bool value , bool TakeOffTenantID = false);
        public yUserDTO FirstByChanged(DateTime value , bool TakeOffTenantID = false);
        public IEnumerable<yUserDTO> GetAllById(int value , bool TakeOffTenantID = false);
        public IEnumerable<yUserDTO> GetAllByNome(string value , bool TakeOffTenantID = false);
        public IEnumerable<yUserDTO> GetAllByEmail(string value , bool TakeOffTenantID = false);
        public IEnumerable<yUserDTO> GetAllBySenha(string value , bool TakeOffTenantID = false);
        public IEnumerable<yUserDTO> GetAllByTenantID(int value , bool TakeOffTenantID = false);
        public IEnumerable<yUserDTO> GetAllByDeleted(bool value , bool TakeOffTenantID = false);
        public IEnumerable<yUserDTO> GetAllByChanged(DateTime value , bool TakeOffTenantID = false);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration