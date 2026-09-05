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
    public partial interface IDocumentoFiscalOriginarioReadRepository
    {
        public DataPagination<DocumentoFiscalOriginarioDTO> getDocumentoFiscalOriginario(ICommandRead command );
        public IEnumerable<DocumentoFiscalOriginarioDocumentoFiscalIdDTO> getDocumentoFiscalOriginarioReadFKDocumentoFiscalId(object command );
        public IEnumerable<DocumentoFiscalOriginarioTenantIDDTO> getDocumentoFiscalOriginarioReadFKTenantID(object command );
        public IEnumerable<DocumentoFiscalOriginarioUserIdDTO> getDocumentoFiscalOriginarioReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByDocumentoFiscalId(int value );
        public bool ExistsByCorrelationId(string value );
        public bool ExistsBySourceApplication(string value );
        public bool ExistsBySourceModule(string value );
        public bool ExistsBySourceMessageId(string value );
        public bool ExistsByTipoDocumento(string value );
        public bool ExistsByChaveAcesso(string value );
        public bool ExistsByNumero(string value );
        public bool ExistsBySerie(string value );
        public bool ExistsByEmitenteDocumento(string value );
        public bool ExistsByDestinatarioDocumento(string value );
        public bool ExistsByValorDocumento(Decimal value );
        public bool ExistsByPesoBruto(Decimal value );
        public bool ExistsByVolume(Decimal value );
        public bool ExistsBySnapshotJson(string value );
        public bool ExistsByStatus(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public DocumentoFiscalOriginarioDTO FirstById(int value );
        public DocumentoFiscalOriginarioDTO FirstByDocumentoFiscalId(int value );
        public DocumentoFiscalOriginarioDTO FirstByCorrelationId(string value );
        public DocumentoFiscalOriginarioDTO FirstBySourceApplication(string value );
        public DocumentoFiscalOriginarioDTO FirstBySourceModule(string value );
        public DocumentoFiscalOriginarioDTO FirstBySourceMessageId(string value );
        public DocumentoFiscalOriginarioDTO FirstByTipoDocumento(string value );
        public DocumentoFiscalOriginarioDTO FirstByChaveAcesso(string value );
        public DocumentoFiscalOriginarioDTO FirstByNumero(string value );
        public DocumentoFiscalOriginarioDTO FirstBySerie(string value );
        public DocumentoFiscalOriginarioDTO FirstByEmitenteDocumento(string value );
        public DocumentoFiscalOriginarioDTO FirstByDestinatarioDocumento(string value );
        public DocumentoFiscalOriginarioDTO FirstByValorDocumento(Decimal value );
        public DocumentoFiscalOriginarioDTO FirstByPesoBruto(Decimal value );
        public DocumentoFiscalOriginarioDTO FirstByVolume(Decimal value );
        public DocumentoFiscalOriginarioDTO FirstBySnapshotJson(string value );
        public DocumentoFiscalOriginarioDTO FirstByStatus(int value );
        public DocumentoFiscalOriginarioDTO FirstByTenantID(int value );
        public DocumentoFiscalOriginarioDTO FirstByDeleted(bool value );
        public DocumentoFiscalOriginarioDTO FirstByChanged(DateTime value );
        public DocumentoFiscalOriginarioDTO FirstByUserId(int value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllById(int value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByDocumentoFiscalId(int value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByCorrelationId(string value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllBySourceApplication(string value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllBySourceModule(string value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllBySourceMessageId(string value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByTipoDocumento(string value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByChaveAcesso(string value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByNumero(string value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllBySerie(string value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByEmitenteDocumento(string value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByDestinatarioDocumento(string value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByValorDocumento(Decimal value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByPesoBruto(Decimal value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByVolume(Decimal value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllBySnapshotJson(string value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByStatus(int value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByTenantID(int value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByDeleted(bool value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByChanged(DateTime value );
        public IEnumerable<DocumentoFiscalOriginarioDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration