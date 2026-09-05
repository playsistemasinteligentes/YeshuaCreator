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
    public partial interface IMDFeSolicitacaoFiscalReadRepository
    {
        public DataPagination<MDFeSolicitacaoFiscalDTO> getMDFeSolicitacaoFiscal(ICommandRead command );
        public IEnumerable<MDFeSolicitacaoFiscalTenantIDDTO> getMDFeSolicitacaoFiscalReadFKTenantID(object command );
        public IEnumerable<MDFeSolicitacaoFiscalUserIdDTO> getMDFeSolicitacaoFiscalReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByCorrelationId(string value );
        public bool ExistsByCargaId(string value );
        public bool ExistsByAmbiente(int value );
        public bool ExistsByUFCarregamento(string value );
        public bool ExistsByUFDescarregamento(string value );
        public bool ExistsByPlacaVeiculo(string value );
        public bool ExistsByCondutorDocumento(string value );
        public bool ExistsByDocumentosOriginariosJson(string value );
        public bool ExistsByTransporteSnapshotJson(string value );
        public bool ExistsByStatus(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MDFeSolicitacaoFiscalDTO FirstById(int value );
        public MDFeSolicitacaoFiscalDTO FirstByCorrelationId(string value );
        public MDFeSolicitacaoFiscalDTO FirstByCargaId(string value );
        public MDFeSolicitacaoFiscalDTO FirstByAmbiente(int value );
        public MDFeSolicitacaoFiscalDTO FirstByUFCarregamento(string value );
        public MDFeSolicitacaoFiscalDTO FirstByUFDescarregamento(string value );
        public MDFeSolicitacaoFiscalDTO FirstByPlacaVeiculo(string value );
        public MDFeSolicitacaoFiscalDTO FirstByCondutorDocumento(string value );
        public MDFeSolicitacaoFiscalDTO FirstByDocumentosOriginariosJson(string value );
        public MDFeSolicitacaoFiscalDTO FirstByTransporteSnapshotJson(string value );
        public MDFeSolicitacaoFiscalDTO FirstByStatus(int value );
        public MDFeSolicitacaoFiscalDTO FirstByTenantID(int value );
        public MDFeSolicitacaoFiscalDTO FirstByDeleted(bool value );
        public MDFeSolicitacaoFiscalDTO FirstByChanged(DateTime value );
        public MDFeSolicitacaoFiscalDTO FirstByUserId(int value );
        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllById(int value );
        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByCorrelationId(string value );
        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByCargaId(string value );
        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByAmbiente(int value );
        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByUFCarregamento(string value );
        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByUFDescarregamento(string value );
        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByPlacaVeiculo(string value );
        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByCondutorDocumento(string value );
        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByDocumentosOriginariosJson(string value );
        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByTransporteSnapshotJson(string value );
        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByStatus(int value );
        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByTenantID(int value );
        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByDeleted(bool value );
        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MDFeSolicitacaoFiscalDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration