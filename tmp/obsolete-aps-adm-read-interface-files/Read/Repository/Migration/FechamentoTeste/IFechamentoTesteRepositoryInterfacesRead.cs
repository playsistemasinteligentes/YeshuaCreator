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
    public partial interface IFechamentoTesteReadRepository
    {
        public DataPagination<FechamentoTesteDTO> getFechamentoTeste(ICommandRead command );
        public IEnumerable<FechamentoTesteTenantIDDTO> getFechamentoTesteReadFKTenantID(object command );
        public IEnumerable<FechamentoTesteUserIdDTO> getFechamentoTesteReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByFEC_ID(int value );
        public bool ExistsByFEC_QTD(int value );
        public bool ExistsByGRP_ID(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public FechamentoTesteDTO FirstById(int value );
        public FechamentoTesteDTO FirstByFEC_ID(int value );
        public FechamentoTesteDTO FirstByFEC_QTD(int value );
        public FechamentoTesteDTO FirstByGRP_ID(string value );
        public FechamentoTesteDTO FirstByTenantID(int value );
        public FechamentoTesteDTO FirstByDeleted(bool value );
        public FechamentoTesteDTO FirstByChanged(DateTime value );
        public FechamentoTesteDTO FirstByUserId(int value );
        public IEnumerable<FechamentoTesteDTO> GetAllById(int value );
        public IEnumerable<FechamentoTesteDTO> GetAllByFEC_ID(int value );
        public IEnumerable<FechamentoTesteDTO> GetAllByFEC_QTD(int value );
        public IEnumerable<FechamentoTesteDTO> GetAllByGRP_ID(string value );
        public IEnumerable<FechamentoTesteDTO> GetAllByTenantID(int value );
        public IEnumerable<FechamentoTesteDTO> GetAllByDeleted(bool value );
        public IEnumerable<FechamentoTesteDTO> GetAllByChanged(DateTime value );
        public IEnumerable<FechamentoTesteDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration