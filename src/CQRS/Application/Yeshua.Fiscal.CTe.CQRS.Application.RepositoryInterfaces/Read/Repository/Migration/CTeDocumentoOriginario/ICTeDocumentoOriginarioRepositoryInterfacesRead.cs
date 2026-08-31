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
    public partial interface ICTeDocumentoOriginarioReadRepository
    {
        public DataPagination<CTeDocumentoOriginarioDTO> getCTeDocumentoOriginario(ICommandRead command );
        public IEnumerable<CTeDocumentoOriginarioCTeSolicitacaoFiscalIdDTO> getCTeDocumentoOriginarioReadFKCTeSolicitacaoFiscalId(object command );
        public IEnumerable<CTeDocumentoOriginarioTenantIDDTO> getCTeDocumentoOriginarioReadFKTenantID(object command );
        public IEnumerable<CTeDocumentoOriginarioUserIdDTO> getCTeDocumentoOriginarioReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCTeSolicitacaoFiscalId(int value );
        public bool ExistsByTipoDocumento(string value );
        public bool ExistsByChaveAcesso(string value );
        public bool ExistsByNumero(string value );
        public bool ExistsBySerie(string value );
        public bool ExistsByEmitenteDocumento(string value );
        public bool ExistsByDestinatarioDocumento(string value );
        public bool ExistsByValorDocumento(Decimal value );
        public bool ExistsByPesoBruto(Decimal value );
        public bool ExistsBySnapshotJson(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public CTeDocumentoOriginarioDTO FirstById(int value );
        public CTeDocumentoOriginarioDTO FirstByCTeSolicitacaoFiscalId(int value );
        public CTeDocumentoOriginarioDTO FirstByTipoDocumento(string value );
        public CTeDocumentoOriginarioDTO FirstByChaveAcesso(string value );
        public CTeDocumentoOriginarioDTO FirstByNumero(string value );
        public CTeDocumentoOriginarioDTO FirstBySerie(string value );
        public CTeDocumentoOriginarioDTO FirstByEmitenteDocumento(string value );
        public CTeDocumentoOriginarioDTO FirstByDestinatarioDocumento(string value );
        public CTeDocumentoOriginarioDTO FirstByValorDocumento(Decimal value );
        public CTeDocumentoOriginarioDTO FirstByPesoBruto(Decimal value );
        public CTeDocumentoOriginarioDTO FirstBySnapshotJson(string value );
        public CTeDocumentoOriginarioDTO FirstByTenantID(int value );
        public CTeDocumentoOriginarioDTO FirstByDeleted(bool value );
        public CTeDocumentoOriginarioDTO FirstByChanged(DateTime value );
        public CTeDocumentoOriginarioDTO FirstByUserId(int value );
        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllById(int value );
        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByCTeSolicitacaoFiscalId(int value );
        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByTipoDocumento(string value );
        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByChaveAcesso(string value );
        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByNumero(string value );
        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllBySerie(string value );
        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByEmitenteDocumento(string value );
        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByDestinatarioDocumento(string value );
        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByValorDocumento(Decimal value );
        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByPesoBruto(Decimal value );
        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllBySnapshotJson(string value );
        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByTenantID(int value );
        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByDeleted(bool value );
        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByChanged(DateTime value );
        public IEnumerable<CTeDocumentoOriginarioDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration