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
    public partial interface IEquipeReadRepository
    {
        public DataPagination<EquipeDTO> getEquipe(ICommandRead command );
        public IEnumerable<EquipeTenantIDDTO> getEquipeReadFKTenantID(object command );
        public IEnumerable<EquipeUserIdDTO> getEquipeReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByEQU_ID(string value );
        public bool ExistsByEQU_HIERARQUIA_SEQ_TRANSFORMACAO(Decimal value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public EquipeDTO FirstById(int value );
        public EquipeDTO FirstByEQU_ID(string value );
        public EquipeDTO FirstByEQU_HIERARQUIA_SEQ_TRANSFORMACAO(Decimal value );
        public EquipeDTO FirstByTenantID(int value );
        public EquipeDTO FirstByDeleted(bool value );
        public EquipeDTO FirstByChanged(DateTime value );
        public EquipeDTO FirstByUserId(int value );
        public IEnumerable<EquipeDTO> GetAllById(int value );
        public IEnumerable<EquipeDTO> GetAllByEQU_ID(string value );
        public IEnumerable<EquipeDTO> GetAllByEQU_HIERARQUIA_SEQ_TRANSFORMACAO(Decimal value );
        public IEnumerable<EquipeDTO> GetAllByTenantID(int value );
        public IEnumerable<EquipeDTO> GetAllByDeleted(bool value );
        public IEnumerable<EquipeDTO> GetAllByChanged(DateTime value );
        public IEnumerable<EquipeDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration