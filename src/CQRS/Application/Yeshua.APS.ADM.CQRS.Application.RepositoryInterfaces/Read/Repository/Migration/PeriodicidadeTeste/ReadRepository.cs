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
    public partial interface IPeriodicidadeTesteReadRepository
    {
        public DataPagination<PeriodicidadeTesteDTO> getPeriodicidadeTeste(ICommandRead command );
        public IEnumerable<PeriodicidadeTesteTenantIDDTO> getPeriodicidadeTesteReadFKTenantID(object command );
        public IEnumerable<PeriodicidadeTesteUserIdDTO> getPeriodicidadeTesteReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByPER_ID(int value );
        public bool ExistsByPER_QTD(string value );
        public bool ExistsByUNI_ID(string value );
        public bool ExistsByGRP_ID(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public PeriodicidadeTesteDTO FirstById(int value );
        public PeriodicidadeTesteDTO FirstByPER_ID(int value );
        public PeriodicidadeTesteDTO FirstByPER_QTD(string value );
        public PeriodicidadeTesteDTO FirstByUNI_ID(string value );
        public PeriodicidadeTesteDTO FirstByGRP_ID(string value );
        public PeriodicidadeTesteDTO FirstByTenantID(int value );
        public PeriodicidadeTesteDTO FirstByDeleted(bool value );
        public PeriodicidadeTesteDTO FirstByChanged(DateTime value );
        public PeriodicidadeTesteDTO FirstByUserId(int value );
        public IEnumerable<PeriodicidadeTesteDTO> GetAllById(int value );
        public IEnumerable<PeriodicidadeTesteDTO> GetAllByPER_ID(int value );
        public IEnumerable<PeriodicidadeTesteDTO> GetAllByPER_QTD(string value );
        public IEnumerable<PeriodicidadeTesteDTO> GetAllByUNI_ID(string value );
        public IEnumerable<PeriodicidadeTesteDTO> GetAllByGRP_ID(string value );
        public IEnumerable<PeriodicidadeTesteDTO> GetAllByTenantID(int value );
        public IEnumerable<PeriodicidadeTesteDTO> GetAllByDeleted(bool value );
        public IEnumerable<PeriodicidadeTesteDTO> GetAllByChanged(DateTime value );
        public IEnumerable<PeriodicidadeTesteDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration