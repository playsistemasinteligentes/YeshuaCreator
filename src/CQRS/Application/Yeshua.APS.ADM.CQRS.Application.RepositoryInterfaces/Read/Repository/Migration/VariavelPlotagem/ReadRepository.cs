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
    public partial interface IVariavelPlotagemReadRepository
    {
        public DataPagination<VariavelPlotagemDTO> getVariavelPlotagem(ICommandRead command );
        public IEnumerable<VariavelPlotagemTenantIDDTO> getVariavelPlotagemReadFKTenantID(object command );
        public IEnumerable<VariavelPlotagemUserIdDTO> getVariavelPlotagemReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByVAR_ID(int value );
        public bool ExistsByPLO_ID(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public VariavelPlotagemDTO FirstById(int value );
        public VariavelPlotagemDTO FirstByVAR_ID(int value );
        public VariavelPlotagemDTO FirstByPLO_ID(int value );
        public VariavelPlotagemDTO FirstByTenantID(int value );
        public VariavelPlotagemDTO FirstByDeleted(bool value );
        public VariavelPlotagemDTO FirstByChanged(DateTime value );
        public VariavelPlotagemDTO FirstByUserId(int value );
        public IEnumerable<VariavelPlotagemDTO> GetAllById(int value );
        public IEnumerable<VariavelPlotagemDTO> GetAllByVAR_ID(int value );
        public IEnumerable<VariavelPlotagemDTO> GetAllByPLO_ID(int value );
        public IEnumerable<VariavelPlotagemDTO> GetAllByTenantID(int value );
        public IEnumerable<VariavelPlotagemDTO> GetAllByDeleted(bool value );
        public IEnumerable<VariavelPlotagemDTO> GetAllByChanged(DateTime value );
        public IEnumerable<VariavelPlotagemDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration