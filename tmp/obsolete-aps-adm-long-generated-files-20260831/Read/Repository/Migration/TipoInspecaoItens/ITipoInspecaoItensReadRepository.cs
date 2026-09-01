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
    public partial interface ITipoInspecaoItensReadRepository
    {
        public DataPagination<TipoInspecaoItensDTO> getTipoInspecaoItens(ICommandRead command );
        public IEnumerable<TipoInspecaoItensTenantIDDTO> getTipoInspecaoItensReadFKTenantID(object command );
        public IEnumerable<TipoInspecaoItensUserIdDTO> getTipoInspecaoItensReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByTII_ID(int value );
        public bool ExistsByTIV_ID(int value );
        public bool ExistsByITI_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TipoInspecaoItensDTO FirstById(int value );
        public TipoInspecaoItensDTO FirstByTII_ID(int value );
        public TipoInspecaoItensDTO FirstByTIV_ID(int value );
        public TipoInspecaoItensDTO FirstByITI_ID(int value );
        public TipoInspecaoItensDTO FirstByTenantID(int value );
        public TipoInspecaoItensDTO FirstByDeleted(bool value );
        public TipoInspecaoItensDTO FirstByChanged(DateTime value );
        public TipoInspecaoItensDTO FirstByUserId(int value );
        public IEnumerable<TipoInspecaoItensDTO> GetAllById(int value );
        public IEnumerable<TipoInspecaoItensDTO> GetAllByTII_ID(int value );
        public IEnumerable<TipoInspecaoItensDTO> GetAllByTIV_ID(int value );
        public IEnumerable<TipoInspecaoItensDTO> GetAllByITI_ID(int value );
        public IEnumerable<TipoInspecaoItensDTO> GetAllByTenantID(int value );
        public IEnumerable<TipoInspecaoItensDTO> GetAllByDeleted(bool value );
        public IEnumerable<TipoInspecaoItensDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TipoInspecaoItensDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration