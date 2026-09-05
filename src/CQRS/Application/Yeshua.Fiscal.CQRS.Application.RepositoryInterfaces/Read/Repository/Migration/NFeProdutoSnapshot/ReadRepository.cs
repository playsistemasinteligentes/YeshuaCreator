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
    public partial interface INFeProdutoSnapshotReadRepository
    {
        public DataPagination<NFeProdutoSnapshotDTO> getNFeProdutoSnapshot(ICommandRead command );
        public IEnumerable<NFeProdutoSnapshotDocumentoFiscalOriginarioIdDTO> getNFeProdutoSnapshotReadFKDocumentoFiscalOriginarioId(object command );
        public IEnumerable<NFeProdutoSnapshotTenantIDDTO> getNFeProdutoSnapshotReadFKTenantID(object command );
        public IEnumerable<NFeProdutoSnapshotUserIdDTO> getNFeProdutoSnapshotReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByDocumentoFiscalOriginarioId(int value );
        public bool ExistsByCorrelationId(string value );
        public bool ExistsByCargaId(string value );
        public bool ExistsByPedidoId(string value );
        public bool ExistsByChaveAcesso(string value );
        public bool ExistsByEmitenteDocumento(string value );
        public bool ExistsByDestinatarioDocumento(string value );
        public bool ExistsByUFOrigem(string value );
        public bool ExistsByUFDestino(string value );
        public bool ExistsByMunicipioOrigemCodigoIbge(string value );
        public bool ExistsByMunicipioDestinoCodigoIbge(string value );
        public bool ExistsByValorDocumento(Decimal value );
        public bool ExistsByPesoBruto(Decimal value );
        public bool ExistsByVolume(Decimal value );
        public bool ExistsByXmlStorageKey(string value );
        public bool ExistsBySnapshotJson(string value );
        public bool ExistsByStatus(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public NFeProdutoSnapshotDTO FirstById(int value );
        public NFeProdutoSnapshotDTO FirstByDocumentoFiscalOriginarioId(int value );
        public NFeProdutoSnapshotDTO FirstByCorrelationId(string value );
        public NFeProdutoSnapshotDTO FirstByCargaId(string value );
        public NFeProdutoSnapshotDTO FirstByPedidoId(string value );
        public NFeProdutoSnapshotDTO FirstByChaveAcesso(string value );
        public NFeProdutoSnapshotDTO FirstByEmitenteDocumento(string value );
        public NFeProdutoSnapshotDTO FirstByDestinatarioDocumento(string value );
        public NFeProdutoSnapshotDTO FirstByUFOrigem(string value );
        public NFeProdutoSnapshotDTO FirstByUFDestino(string value );
        public NFeProdutoSnapshotDTO FirstByMunicipioOrigemCodigoIbge(string value );
        public NFeProdutoSnapshotDTO FirstByMunicipioDestinoCodigoIbge(string value );
        public NFeProdutoSnapshotDTO FirstByValorDocumento(Decimal value );
        public NFeProdutoSnapshotDTO FirstByPesoBruto(Decimal value );
        public NFeProdutoSnapshotDTO FirstByVolume(Decimal value );
        public NFeProdutoSnapshotDTO FirstByXmlStorageKey(string value );
        public NFeProdutoSnapshotDTO FirstBySnapshotJson(string value );
        public NFeProdutoSnapshotDTO FirstByStatus(int value );
        public NFeProdutoSnapshotDTO FirstByTenantID(int value );
        public NFeProdutoSnapshotDTO FirstByDeleted(bool value );
        public NFeProdutoSnapshotDTO FirstByChanged(DateTime value );
        public NFeProdutoSnapshotDTO FirstByUserId(int value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllById(int value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByDocumentoFiscalOriginarioId(int value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByCorrelationId(string value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByCargaId(string value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByPedidoId(string value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByChaveAcesso(string value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByEmitenteDocumento(string value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByDestinatarioDocumento(string value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByUFOrigem(string value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByUFDestino(string value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByMunicipioOrigemCodigoIbge(string value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByMunicipioDestinoCodigoIbge(string value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByValorDocumento(Decimal value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByPesoBruto(Decimal value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByVolume(Decimal value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByXmlStorageKey(string value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllBySnapshotJson(string value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByStatus(int value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByTenantID(int value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByDeleted(bool value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByChanged(DateTime value );
        public IEnumerable<NFeProdutoSnapshotDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration