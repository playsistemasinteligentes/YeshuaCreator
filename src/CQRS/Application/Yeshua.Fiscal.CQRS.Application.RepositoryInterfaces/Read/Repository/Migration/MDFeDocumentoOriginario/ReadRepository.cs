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
    public partial interface IMDFeDocumentoOriginarioReadRepository
    {
        public DataPagination<MDFeDocumentoOriginarioDTO> getMDFeDocumentoOriginario(ICommandRead command );
        public IEnumerable<MDFeDocumentoOriginarioMDFeSolicitacaoFiscalIdDTO> getMDFeDocumentoOriginarioReadFKMDFeSolicitacaoFiscalId(object command );
        public IEnumerable<MDFeDocumentoOriginarioDocumentoFiscalOriginarioIdDTO> getMDFeDocumentoOriginarioReadFKDocumentoFiscalOriginarioId(object command );
        public IEnumerable<MDFeDocumentoOriginarioTenantIDDTO> getMDFeDocumentoOriginarioReadFKTenantID(object command );
        public IEnumerable<MDFeDocumentoOriginarioUserIdDTO> getMDFeDocumentoOriginarioReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByMDFeSolicitacaoFiscalId(int value );
        public bool ExistsByDocumentoFiscalOriginarioId(int value );
        public bool ExistsByTipoDocumento(string value );
        public bool ExistsByChaveAcesso(string value );
        public bool ExistsBySnapshotJson(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MDFeDocumentoOriginarioDTO FirstById(int value );
        public MDFeDocumentoOriginarioDTO FirstByMDFeSolicitacaoFiscalId(int value );
        public MDFeDocumentoOriginarioDTO FirstByDocumentoFiscalOriginarioId(int value );
        public MDFeDocumentoOriginarioDTO FirstByTipoDocumento(string value );
        public MDFeDocumentoOriginarioDTO FirstByChaveAcesso(string value );
        public MDFeDocumentoOriginarioDTO FirstBySnapshotJson(string value );
        public MDFeDocumentoOriginarioDTO FirstByTenantID(int value );
        public MDFeDocumentoOriginarioDTO FirstByDeleted(bool value );
        public MDFeDocumentoOriginarioDTO FirstByChanged(DateTime value );
        public MDFeDocumentoOriginarioDTO FirstByUserId(int value );
        public IEnumerable<MDFeDocumentoOriginarioDTO> GetAllById(int value );
        public IEnumerable<MDFeDocumentoOriginarioDTO> GetAllByMDFeSolicitacaoFiscalId(int value );
        public IEnumerable<MDFeDocumentoOriginarioDTO> GetAllByDocumentoFiscalOriginarioId(int value );
        public IEnumerable<MDFeDocumentoOriginarioDTO> GetAllByTipoDocumento(string value );
        public IEnumerable<MDFeDocumentoOriginarioDTO> GetAllByChaveAcesso(string value );
        public IEnumerable<MDFeDocumentoOriginarioDTO> GetAllBySnapshotJson(string value );
        public IEnumerable<MDFeDocumentoOriginarioDTO> GetAllByTenantID(int value );
        public IEnumerable<MDFeDocumentoOriginarioDTO> GetAllByDeleted(bool value );
        public IEnumerable<MDFeDocumentoOriginarioDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MDFeDocumentoOriginarioDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration