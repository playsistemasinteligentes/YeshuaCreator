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
    public partial interface ITempoSetupOnduladeiraReadRepository
    {
        public DataPagination<TempoSetupOnduladeiraDTO> getTempoSetupOnduladeira(ICommandRead command );
        public IEnumerable<TempoSetupOnduladeiraOND_ID_DEDTO> getTempoSetupOnduladeiraReadFKOND_ID_DE(object command );
        public IEnumerable<TempoSetupOnduladeiraTenantIDDTO> getTempoSetupOnduladeiraReadFKTenantID(object command );
        public IEnumerable<TempoSetupOnduladeiraUserIdDTO> getTempoSetupOnduladeiraReadFKUserId(object command );
        public bool ExistsByTEM_ID(int value );
        public bool ExistsByOND_ID_DE(string value );
        public bool ExistsByOND_ID_PARA(string value );
        public bool ExistsByTEM_RESINA_DE(string value );
        public bool ExistsByTEM_RESINA_PARA(string value );
        public bool ExistsByTEM_TEMPO(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public TempoSetupOnduladeiraDTO FirstByTEM_ID(int value );
        public TempoSetupOnduladeiraDTO FirstByOND_ID_DE(string value );
        public TempoSetupOnduladeiraDTO FirstByOND_ID_PARA(string value );
        public TempoSetupOnduladeiraDTO FirstByTEM_RESINA_DE(string value );
        public TempoSetupOnduladeiraDTO FirstByTEM_RESINA_PARA(string value );
        public TempoSetupOnduladeiraDTO FirstByTEM_TEMPO(int value );
        public TempoSetupOnduladeiraDTO FirstByTenantID(int value );
        public TempoSetupOnduladeiraDTO FirstByDeleted(bool value );
        public TempoSetupOnduladeiraDTO FirstByChanged(DateTime value );
        public TempoSetupOnduladeiraDTO FirstByUserId(int value );
        public IEnumerable<TempoSetupOnduladeiraDTO> GetAllByTEM_ID(int value );
        public IEnumerable<TempoSetupOnduladeiraDTO> GetAllByOND_ID_DE(string value );
        public IEnumerable<TempoSetupOnduladeiraDTO> GetAllByOND_ID_PARA(string value );
        public IEnumerable<TempoSetupOnduladeiraDTO> GetAllByTEM_RESINA_DE(string value );
        public IEnumerable<TempoSetupOnduladeiraDTO> GetAllByTEM_RESINA_PARA(string value );
        public IEnumerable<TempoSetupOnduladeiraDTO> GetAllByTEM_TEMPO(int value );
        public IEnumerable<TempoSetupOnduladeiraDTO> GetAllByTenantID(int value );
        public IEnumerable<TempoSetupOnduladeiraDTO> GetAllByDeleted(bool value );
        public IEnumerable<TempoSetupOnduladeiraDTO> GetAllByChanged(DateTime value );
        public IEnumerable<TempoSetupOnduladeiraDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration