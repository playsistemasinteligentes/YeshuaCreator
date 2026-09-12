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
    public partial interface IEmissaoFiscalTransporteDocumentoReadRepository
    {
        public DataPagination<EmissaoFiscalTransporteDocumentoDTO> getEmissaoFiscalTransporteDocumento(ICommandRead command );
        public IEnumerable<EmissaoFiscalTransporteDocumentoEmissaoFiscalTransporteIdDTO> getEmissaoFiscalTransporteDocumentoReadFKEmissaoFiscalTransporteId(object command );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDocumentoFiscalIdDTO> getEmissaoFiscalTransporteDocumentoReadFKDocumentoFiscalId(object command );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDocumentoFiscalOriginarioIdDTO> getEmissaoFiscalTransporteDocumentoReadFKDocumentoFiscalOriginarioId(object command );
        public IEnumerable<EmissaoFiscalTransporteDocumentoNFeProdutoSnapshotIdDTO> getEmissaoFiscalTransporteDocumentoReadFKNFeProdutoSnapshotId(object command );
        public IEnumerable<EmissaoFiscalTransporteDocumentoTenantIDDTO> getEmissaoFiscalTransporteDocumentoReadFKTenantID(object command );
        public IEnumerable<EmissaoFiscalTransporteDocumentoUserIdDTO> getEmissaoFiscalTransporteDocumentoReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByEmissaoFiscalTransporteId(int value );
        public bool ExistsByDocumentoFiscalId(int value );
        public bool ExistsByDocumentoFiscalOriginarioId(int value );
        public bool ExistsByNFeProdutoSnapshotId(int value );
        public bool ExistsByProdutoFiscal(int value );
        public bool ExistsByPapel(int value );
        public bool ExistsByTipoEvento(string value );
        public bool ExistsByChaveAcesso(string value );
        public bool ExistsByXmlStorageKey(string value );
        public bool ExistsByPdfStorageKey(string value );
        public bool ExistsByProtocolo(string value );
        public bool ExistsByCodigoRetorno(string value );
        public bool ExistsByMensagemRetorno(string value );
        public bool ExistsByCriadoEmUtc(DateTime value );
        public bool ExistsByStatus(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public EmissaoFiscalTransporteDocumentoDTO FirstById(int value );
        public EmissaoFiscalTransporteDocumentoDTO FirstByEmissaoFiscalTransporteId(int value );
        public EmissaoFiscalTransporteDocumentoDTO FirstByDocumentoFiscalId(int value );
        public EmissaoFiscalTransporteDocumentoDTO FirstByDocumentoFiscalOriginarioId(int value );
        public EmissaoFiscalTransporteDocumentoDTO FirstByNFeProdutoSnapshotId(int value );
        public EmissaoFiscalTransporteDocumentoDTO FirstByProdutoFiscal(int value );
        public EmissaoFiscalTransporteDocumentoDTO FirstByPapel(int value );
        public EmissaoFiscalTransporteDocumentoDTO FirstByTipoEvento(string value );
        public EmissaoFiscalTransporteDocumentoDTO FirstByChaveAcesso(string value );
        public EmissaoFiscalTransporteDocumentoDTO FirstByXmlStorageKey(string value );
        public EmissaoFiscalTransporteDocumentoDTO FirstByPdfStorageKey(string value );
        public EmissaoFiscalTransporteDocumentoDTO FirstByProtocolo(string value );
        public EmissaoFiscalTransporteDocumentoDTO FirstByCodigoRetorno(string value );
        public EmissaoFiscalTransporteDocumentoDTO FirstByMensagemRetorno(string value );
        public EmissaoFiscalTransporteDocumentoDTO FirstByCriadoEmUtc(DateTime value );
        public EmissaoFiscalTransporteDocumentoDTO FirstByStatus(int value );
        public EmissaoFiscalTransporteDocumentoDTO FirstByTenantID(int value );
        public EmissaoFiscalTransporteDocumentoDTO FirstByDeleted(bool value );
        public EmissaoFiscalTransporteDocumentoDTO FirstByChanged(DateTime value );
        public EmissaoFiscalTransporteDocumentoDTO FirstByUserId(int value );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllById(int value );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByEmissaoFiscalTransporteId(int value );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByDocumentoFiscalId(int value );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByDocumentoFiscalOriginarioId(int value );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByNFeProdutoSnapshotId(int value );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByProdutoFiscal(int value );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByPapel(int value );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByTipoEvento(string value );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByChaveAcesso(string value );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByXmlStorageKey(string value );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByPdfStorageKey(string value );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByProtocolo(string value );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByCodigoRetorno(string value );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByMensagemRetorno(string value );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByCriadoEmUtc(DateTime value );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByStatus(int value );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByTenantID(int value );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByDeleted(bool value );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByChanged(DateTime value );
        public IEnumerable<EmissaoFiscalTransporteDocumentoDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration