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
    public partial interface IMDFeCondutorReadRepository
    {
        public DataPagination<MDFeCondutorDTO> getMDFeCondutor(ICommandRead command );
        public IEnumerable<MDFeCondutorMDFeSolicitacaoFiscalIdDTO> getMDFeCondutorReadFKMDFeSolicitacaoFiscalId(object command );
        public IEnumerable<MDFeCondutorTenantIDDTO> getMDFeCondutorReadFKTenantID(object command );
        public IEnumerable<MDFeCondutorUserIdDTO> getMDFeCondutorReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByMDFeSolicitacaoFiscalId(int value );
        public bool ExistsByNome(string value );
        public bool ExistsByDocumento(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MDFeCondutorDTO FirstById(int value );
        public MDFeCondutorDTO FirstByMDFeSolicitacaoFiscalId(int value );
        public MDFeCondutorDTO FirstByNome(string value );
        public MDFeCondutorDTO FirstByDocumento(string value );
        public MDFeCondutorDTO FirstByTenantID(int value );
        public MDFeCondutorDTO FirstByDeleted(bool value );
        public MDFeCondutorDTO FirstByChanged(DateTime value );
        public MDFeCondutorDTO FirstByUserId(int value );
        public IEnumerable<MDFeCondutorDTO> GetAllById(int value );
        public IEnumerable<MDFeCondutorDTO> GetAllByMDFeSolicitacaoFiscalId(int value );
        public IEnumerable<MDFeCondutorDTO> GetAllByNome(string value );
        public IEnumerable<MDFeCondutorDTO> GetAllByDocumento(string value );
        public IEnumerable<MDFeCondutorDTO> GetAllByTenantID(int value );
        public IEnumerable<MDFeCondutorDTO> GetAllByDeleted(bool value );
        public IEnumerable<MDFeCondutorDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MDFeCondutorDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration