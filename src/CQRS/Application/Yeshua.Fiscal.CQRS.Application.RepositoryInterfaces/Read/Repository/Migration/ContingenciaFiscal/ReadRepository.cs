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
    public partial interface IContingenciaFiscalReadRepository
    {
        public DataPagination<ContingenciaFiscalDTO> getContingenciaFiscal(ICommandRead command );
        public IEnumerable<ContingenciaFiscalEmissaoFiscalTransporteIdDTO> getContingenciaFiscalReadFKEmissaoFiscalTransporteId(object command );
        public IEnumerable<ContingenciaFiscalEntradaFiscalContingenciaIdDTO> getContingenciaFiscalReadFKEntradaFiscalContingenciaId(object command );
        public IEnumerable<ContingenciaFiscalTenantIDDTO> getContingenciaFiscalReadFKTenantID(object command );
        public IEnumerable<ContingenciaFiscalUserIdDTO> getContingenciaFiscalReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByEmissaoFiscalTransporteId(int value );
        public bool ExistsByEntradaFiscalContingenciaId(int value );
        public bool ExistsByCorrelationId(string value );
        public bool ExistsByCargaId(string value );
        public bool ExistsByTipoSolicitante(int value );
        public bool ExistsByAmbiente(int value );
        public bool ExistsByEmitenteDocumento(string value );
        public bool ExistsByTomadorDocumento(string value );
        public bool ExistsByTransportadorDocumento(string value );
        public bool ExistsByQuantidadeDocumentos(int value );
        public bool ExistsByQuantidadeCTe(int value );
        public bool ExistsByQuantidadeMDFe(int value );
        public bool ExistsByValorCarga(Decimal value );
        public bool ExistsByPesoBruto(Decimal value );
        public bool ExistsByUltimaMensagem(string value );
        public bool ExistsByCriadoEmUtc(DateTime value );
        public bool ExistsByAtualizadoEmUtc(DateTime value );
        public bool ExistsByConcluidoEmUtc(DateTime value );
        public bool ExistsByStatus(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public ContingenciaFiscalDTO FirstById(int value );
        public ContingenciaFiscalDTO FirstByEmissaoFiscalTransporteId(int value );
        public ContingenciaFiscalDTO FirstByEntradaFiscalContingenciaId(int value );
        public ContingenciaFiscalDTO FirstByCorrelationId(string value );
        public ContingenciaFiscalDTO FirstByCargaId(string value );
        public ContingenciaFiscalDTO FirstByTipoSolicitante(int value );
        public ContingenciaFiscalDTO FirstByAmbiente(int value );
        public ContingenciaFiscalDTO FirstByEmitenteDocumento(string value );
        public ContingenciaFiscalDTO FirstByTomadorDocumento(string value );
        public ContingenciaFiscalDTO FirstByTransportadorDocumento(string value );
        public ContingenciaFiscalDTO FirstByQuantidadeDocumentos(int value );
        public ContingenciaFiscalDTO FirstByQuantidadeCTe(int value );
        public ContingenciaFiscalDTO FirstByQuantidadeMDFe(int value );
        public ContingenciaFiscalDTO FirstByValorCarga(Decimal value );
        public ContingenciaFiscalDTO FirstByPesoBruto(Decimal value );
        public ContingenciaFiscalDTO FirstByUltimaMensagem(string value );
        public ContingenciaFiscalDTO FirstByCriadoEmUtc(DateTime value );
        public ContingenciaFiscalDTO FirstByAtualizadoEmUtc(DateTime value );
        public ContingenciaFiscalDTO FirstByConcluidoEmUtc(DateTime value );
        public ContingenciaFiscalDTO FirstByStatus(int value );
        public ContingenciaFiscalDTO FirstByTenantID(int value );
        public ContingenciaFiscalDTO FirstByDeleted(bool value );
        public ContingenciaFiscalDTO FirstByChanged(DateTime value );
        public ContingenciaFiscalDTO FirstByUserId(int value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllById(int value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByEmissaoFiscalTransporteId(int value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByEntradaFiscalContingenciaId(int value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByCorrelationId(string value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByCargaId(string value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByTipoSolicitante(int value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByAmbiente(int value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByEmitenteDocumento(string value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByTomadorDocumento(string value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByTransportadorDocumento(string value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByQuantidadeDocumentos(int value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByQuantidadeCTe(int value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByQuantidadeMDFe(int value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByValorCarga(Decimal value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByPesoBruto(Decimal value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByUltimaMensagem(string value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByCriadoEmUtc(DateTime value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByAtualizadoEmUtc(DateTime value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByConcluidoEmUtc(DateTime value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByStatus(int value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByTenantID(int value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByDeleted(bool value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByChanged(DateTime value );
        public IEnumerable<ContingenciaFiscalDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration