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
    public partial interface IMDFePercursoReadRepository
    {
        public DataPagination<MDFePercursoDTO> getMDFePercurso(ICommandRead command );
        public IEnumerable<MDFePercursoMDFeSolicitacaoFiscalIdDTO> getMDFePercursoReadFKMDFeSolicitacaoFiscalId(object command );
        public IEnumerable<MDFePercursoTenantIDDTO> getMDFePercursoReadFKTenantID(object command );
        public IEnumerable<MDFePercursoUserIdDTO> getMDFePercursoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByMDFeSolicitacaoFiscalId(int value );
        public bool ExistsByUF(string value );
        public bool ExistsByOrdem(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MDFePercursoDTO FirstById(int value );
        public MDFePercursoDTO FirstByMDFeSolicitacaoFiscalId(int value );
        public MDFePercursoDTO FirstByUF(string value );
        public MDFePercursoDTO FirstByOrdem(int value );
        public MDFePercursoDTO FirstByTenantID(int value );
        public MDFePercursoDTO FirstByDeleted(bool value );
        public MDFePercursoDTO FirstByChanged(DateTime value );
        public MDFePercursoDTO FirstByUserId(int value );
        public IEnumerable<MDFePercursoDTO> GetAllById(int value );
        public IEnumerable<MDFePercursoDTO> GetAllByMDFeSolicitacaoFiscalId(int value );
        public IEnumerable<MDFePercursoDTO> GetAllByUF(string value );
        public IEnumerable<MDFePercursoDTO> GetAllByOrdem(int value );
        public IEnumerable<MDFePercursoDTO> GetAllByTenantID(int value );
        public IEnumerable<MDFePercursoDTO> GetAllByDeleted(bool value );
        public IEnumerable<MDFePercursoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MDFePercursoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration