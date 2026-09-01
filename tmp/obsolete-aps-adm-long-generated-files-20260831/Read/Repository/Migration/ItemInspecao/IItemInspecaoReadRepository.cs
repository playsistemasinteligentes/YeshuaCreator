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
    public partial interface IItemInspecaoReadRepository
    {
        public DataPagination<ItemInspecaoDTO> getItemInspecao(ICommandRead command );
        public IEnumerable<ItemInspecaoTenantIDDTO> getItemInspecaoReadFKTenantID(object command );
        public IEnumerable<ItemInspecaoUserIdDTO> getItemInspecaoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByITI_ID(int value );
        public bool ExistsByITI_DESC(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ItemInspecaoDTO FirstById(int value );
        public ItemInspecaoDTO FirstByITI_ID(int value );
        public ItemInspecaoDTO FirstByITI_DESC(string value );
        public ItemInspecaoDTO FirstByTenantID(int value );
        public ItemInspecaoDTO FirstByDeleted(bool value );
        public ItemInspecaoDTO FirstByChanged(DateTime value );
        public ItemInspecaoDTO FirstByUserId(int value );
        public IEnumerable<ItemInspecaoDTO> GetAllById(int value );
        public IEnumerable<ItemInspecaoDTO> GetAllByITI_ID(int value );
        public IEnumerable<ItemInspecaoDTO> GetAllByITI_DESC(string value );
        public IEnumerable<ItemInspecaoDTO> GetAllByTenantID(int value );
        public IEnumerable<ItemInspecaoDTO> GetAllByDeleted(bool value );
        public IEnumerable<ItemInspecaoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ItemInspecaoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration