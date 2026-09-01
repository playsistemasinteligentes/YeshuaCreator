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
    public partial interface ISemaforoReadRepository
    {
        public DataPagination<SemaforoDTO> getSemaforo(ICommandRead command );
        public IEnumerable<SemaforoTenantIDDTO> getSemaforoReadFKTenantID(object command );
        public IEnumerable<SemaforoUserIdDTO> getSemaforoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsBySEM_ID(string value );
        public bool ExistsBySEM_STATUS(string value );
        public bool ExistsBySEM_ORIGEM(string value );
        public bool ExistsBySEM_EMISSAO(DateTime value );
        public bool ExistsBySEM_ID_CONEXAO(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public SemaforoDTO FirstById(int value );
        public SemaforoDTO FirstBySEM_ID(string value );
        public SemaforoDTO FirstBySEM_STATUS(string value );
        public SemaforoDTO FirstBySEM_ORIGEM(string value );
        public SemaforoDTO FirstBySEM_EMISSAO(DateTime value );
        public SemaforoDTO FirstBySEM_ID_CONEXAO(string value );
        public SemaforoDTO FirstByTenantID(int value );
        public SemaforoDTO FirstByDeleted(bool value );
        public SemaforoDTO FirstByChanged(DateTime value );
        public SemaforoDTO FirstByUserId(int value );
        public IEnumerable<SemaforoDTO> GetAllById(int value );
        public IEnumerable<SemaforoDTO> GetAllBySEM_ID(string value );
        public IEnumerable<SemaforoDTO> GetAllBySEM_STATUS(string value );
        public IEnumerable<SemaforoDTO> GetAllBySEM_ORIGEM(string value );
        public IEnumerable<SemaforoDTO> GetAllBySEM_EMISSAO(DateTime value );
        public IEnumerable<SemaforoDTO> GetAllBySEM_ID_CONEXAO(string value );
        public IEnumerable<SemaforoDTO> GetAllByTenantID(int value );
        public IEnumerable<SemaforoDTO> GetAllByDeleted(bool value );
        public IEnumerable<SemaforoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<SemaforoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration