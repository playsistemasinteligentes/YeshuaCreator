// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
// </yeshua>

using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IEntradaFiscalContingenciaWriteRepository
    {
        void Insert(IEntradaFiscalContingenciaEntity entradafiscalcontingencia);
        void Update(IEntradaFiscalContingenciaEntity entradafiscalcontingencia);
        void Delete(IEntradaFiscalContingenciaEntity entradafiscalcontingencia);
        void UpdateCorrelationId(int id, string value);
        void UpdateCargaId(int id, string value);
        void UpdateTipoSolicitante(int id, int value);
        void UpdateAmbiente(int id, int value);
        void UpdateSourceApplication(int id, string value);
        void UpdateSourceModule(int id, string value);
        void UpdateSourceMessageId(int id, string value);
        void UpdateEmitenteFiscalDocumento(int id, string value);
        void UpdateTomadorDocumento(int id, string value);
        void UpdateTransportadorDocumento(int id, string value);
        void UpdateRemetenteDocumento(int id, string value);
        void UpdateDestinatarioDocumento(int id, string value);
        void UpdateUFInicio(int id, string value);
        void UpdateUFFim(int id, string value);
        void UpdateMunicipioInicioCodigoIbge(int id, string value);
        void UpdateMunicipioFimCodigoIbge(int id, string value);
        void UpdateRNTRC(int id, string value);
        void UpdatePlacaVeiculo(int id, string value);
        void UpdateUFVeiculo(int id, string value);
        void UpdateCondutorDocumento(int id, string value);
        void UpdateCondutorNome(int id, string value);
        void UpdateQuantidadeDocumentos(int id, int value);
        void UpdateValorCarga(int id, Decimal value);
        void UpdatePesoBruto(int id, Decimal value);
        void UpdateVolume(int id, Decimal value);
        void UpdatePendenciasJson(int id, string value);
        void UpdateSnapshotJson(int id, string value);
        void UpdateEmissaoFiscalCorrelationId(int id, string value);
        void UpdateEmissaoFiscalSagaId(int id, int value);
        void UpdateCriadoEmUtc(int id, DateTime value);
        void UpdateAtualizadoEmUtc(int id, DateTime value);
        void UpdateStatus(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration