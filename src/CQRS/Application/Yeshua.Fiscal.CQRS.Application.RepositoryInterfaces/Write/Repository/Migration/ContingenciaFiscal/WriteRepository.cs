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
    public partial interface IContingenciaFiscalWriteRepository
    {
        void Insert(IContingenciaFiscalEntity contingenciafiscal);
        void Update(IContingenciaFiscalEntity contingenciafiscal);
        void Delete(IContingenciaFiscalEntity contingenciafiscal);
        void UpdateEmissaoFiscalTransporteId(int id, int value);
        void UpdateEntradaFiscalContingenciaId(int id, int value);
        void UpdateCorrelationId(int id, string value);
        void UpdateCargaId(int id, string value);
        void UpdateTipoSolicitante(int id, int value);
        void UpdateAmbiente(int id, int value);
        void UpdateEmitenteDocumento(int id, string value);
        void UpdateTomadorDocumento(int id, string value);
        void UpdateTransportadorDocumento(int id, string value);
        void UpdateQuantidadeDocumentos(int id, int value);
        void UpdateQuantidadeCTe(int id, int value);
        void UpdateQuantidadeMDFe(int id, int value);
        void UpdateValorCarga(int id, Decimal value);
        void UpdatePesoBruto(int id, Decimal value);
        void UpdateUltimaMensagem(int id, string value);
        void UpdateCriadoEmUtc(int id, DateTime value);
        void UpdateAtualizadoEmUtc(int id, DateTime value);
        void UpdateConcluidoEmUtc(int id, DateTime value);
        void UpdateStatus(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration