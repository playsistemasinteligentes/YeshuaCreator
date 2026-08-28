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
    public partial interface IEnderecosReadRepository
    {
        public DataPagination<EnderecosDTO> getEnderecos(ICommandRead command );
        public IEnumerable<EnderecosTenantIDDTO> getEnderecosReadFKTenantID(object command );
        public IEnumerable<EnderecosUserIdDTO> getEnderecosReadFKUserId(object command );
        public bool ExistsByEND_ID(string value );
        public bool ExistsByEND_GRUPO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public EnderecosDTO FirstByEND_ID(string value );
        public EnderecosDTO FirstByEND_GRUPO(string value );
        public EnderecosDTO FirstByTenantID(int value );
        public EnderecosDTO FirstByDeleted(bool value );
        public EnderecosDTO FirstByChanged(DateTime value );
        public EnderecosDTO FirstByUserId(int value );
        public IEnumerable<EnderecosDTO> GetAllByEND_ID(string value );
        public IEnumerable<EnderecosDTO> GetAllByEND_GRUPO(string value );
        public IEnumerable<EnderecosDTO> GetAllByTenantID(int value );
        public IEnumerable<EnderecosDTO> GetAllByDeleted(bool value );
        public IEnumerable<EnderecosDTO> GetAllByChanged(DateTime value );
        public IEnumerable<EnderecosDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration