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
    public partial interface IDocumentoFiscalReadRepository
    {
        public DataPagination<DocumentoFiscalDTO> getDocumentoFiscal(ICommandRead command );
        public IEnumerable<DocumentoFiscalTenantIDDTO> getDocumentoFiscalReadFKTenantID(object command );
        public IEnumerable<DocumentoFiscalUserIdDTO> getDocumentoFiscalReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCorrelationId(string value );
        public bool ExistsByProdutoFiscal(int value );
        public bool ExistsByChaveAcesso(string value );
        public bool ExistsBySerie(int value );
        public bool ExistsByNumero(int value );
        public bool ExistsByAmbiente(int value );
        public bool ExistsByUFEmitente(string value );
        public bool ExistsByEmitenteDocumento(string value );
        public bool ExistsByDestinatarioDocumento(string value );
        public bool ExistsByXmlStorageKey(string value );
        public bool ExistsByXmlHash(string value );
        public bool ExistsByProtocoloAutorizacao(string value );
        public bool ExistsByCodigoRetorno(string value );
        public bool ExistsByMensagemRetorno(string value );
        public bool ExistsByStatus(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public DocumentoFiscalDTO FirstById(int value );
        public DocumentoFiscalDTO FirstByCorrelationId(string value );
        public DocumentoFiscalDTO FirstByProdutoFiscal(int value );
        public DocumentoFiscalDTO FirstByChaveAcesso(string value );
        public DocumentoFiscalDTO FirstBySerie(int value );
        public DocumentoFiscalDTO FirstByNumero(int value );
        public DocumentoFiscalDTO FirstByAmbiente(int value );
        public DocumentoFiscalDTO FirstByUFEmitente(string value );
        public DocumentoFiscalDTO FirstByEmitenteDocumento(string value );
        public DocumentoFiscalDTO FirstByDestinatarioDocumento(string value );
        public DocumentoFiscalDTO FirstByXmlStorageKey(string value );
        public DocumentoFiscalDTO FirstByXmlHash(string value );
        public DocumentoFiscalDTO FirstByProtocoloAutorizacao(string value );
        public DocumentoFiscalDTO FirstByCodigoRetorno(string value );
        public DocumentoFiscalDTO FirstByMensagemRetorno(string value );
        public DocumentoFiscalDTO FirstByStatus(int value );
        public DocumentoFiscalDTO FirstByTenantID(int value );
        public DocumentoFiscalDTO FirstByDeleted(bool value );
        public DocumentoFiscalDTO FirstByChanged(DateTime value );
        public DocumentoFiscalDTO FirstByUserId(int value );
        public IEnumerable<DocumentoFiscalDTO> GetAllById(int value );
        public IEnumerable<DocumentoFiscalDTO> GetAllByCorrelationId(string value );
        public IEnumerable<DocumentoFiscalDTO> GetAllByProdutoFiscal(int value );
        public IEnumerable<DocumentoFiscalDTO> GetAllByChaveAcesso(string value );
        public IEnumerable<DocumentoFiscalDTO> GetAllBySerie(int value );
        public IEnumerable<DocumentoFiscalDTO> GetAllByNumero(int value );
        public IEnumerable<DocumentoFiscalDTO> GetAllByAmbiente(int value );
        public IEnumerable<DocumentoFiscalDTO> GetAllByUFEmitente(string value );
        public IEnumerable<DocumentoFiscalDTO> GetAllByEmitenteDocumento(string value );
        public IEnumerable<DocumentoFiscalDTO> GetAllByDestinatarioDocumento(string value );
        public IEnumerable<DocumentoFiscalDTO> GetAllByXmlStorageKey(string value );
        public IEnumerable<DocumentoFiscalDTO> GetAllByXmlHash(string value );
        public IEnumerable<DocumentoFiscalDTO> GetAllByProtocoloAutorizacao(string value );
        public IEnumerable<DocumentoFiscalDTO> GetAllByCodigoRetorno(string value );
        public IEnumerable<DocumentoFiscalDTO> GetAllByMensagemRetorno(string value );
        public IEnumerable<DocumentoFiscalDTO> GetAllByStatus(int value );
        public IEnumerable<DocumentoFiscalDTO> GetAllByTenantID(int value );
        public IEnumerable<DocumentoFiscalDTO> GetAllByDeleted(bool value );
        public IEnumerable<DocumentoFiscalDTO> GetAllByChanged(DateTime value );
        public IEnumerable<DocumentoFiscalDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration