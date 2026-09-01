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
    public partial interface IRepresentantesReadRepository
    {
        public DataPagination<RepresentantesDTO> getRepresentantes(ICommandRead command );
        public IEnumerable<RepresentantesTenantIDDTO> getRepresentantesReadFKTenantID(object command );
        public IEnumerable<RepresentantesUserIdDTO> getRepresentantesReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByREP_ID(int value );
        public bool ExistsByREP_NOME(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public RepresentantesDTO FirstById(int value );
        public RepresentantesDTO FirstByREP_ID(int value );
        public RepresentantesDTO FirstByREP_NOME(string value );
        public RepresentantesDTO FirstByTenantID(int value );
        public RepresentantesDTO FirstByDeleted(bool value );
        public RepresentantesDTO FirstByChanged(DateTime value );
        public RepresentantesDTO FirstByUserId(int value );
        public IEnumerable<RepresentantesDTO> GetAllById(int value );
        public IEnumerable<RepresentantesDTO> GetAllByREP_ID(int value );
        public IEnumerable<RepresentantesDTO> GetAllByREP_NOME(string value );
        public IEnumerable<RepresentantesDTO> GetAllByTenantID(int value );
        public IEnumerable<RepresentantesDTO> GetAllByDeleted(bool value );
        public IEnumerable<RepresentantesDTO> GetAllByChanged(DateTime value );
        public IEnumerable<RepresentantesDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration