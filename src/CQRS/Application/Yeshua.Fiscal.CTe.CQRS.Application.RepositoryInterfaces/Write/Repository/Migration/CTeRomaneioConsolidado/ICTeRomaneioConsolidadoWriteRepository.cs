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
    public partial interface ICTeRomaneioConsolidadoWriteRepository
    {
        void Insert(ICTeRomaneioConsolidadoEntity cteromaneioconsolidado);
        void Update(ICTeRomaneioConsolidadoEntity cteromaneioconsolidado);
        void Delete(ICTeRomaneioConsolidadoEntity cteromaneioconsolidado);
        void UpdateEntradaOficialId(int id, int value);
        void UpdateCorrelationId(int id, string value);
        void UpdateRomaneioId(int id, string value);
        void UpdateCargaId(int id, string value);
        void UpdateConsolidadoEmUtc(int id, DateTime value);
        void UpdateUFInicio(int id, string value);
        void UpdateUFFim(int id, string value);
        void UpdateMunicipioInicioCodigoIbge(int id, string value);
        void UpdateMunicipioFimCodigoIbge(int id, string value);
        void UpdateEmitenteDocumento(int id, string value);
        void UpdateTomadorDocumento(int id, string value);
        void UpdateRotaSnapshotJson(int id, string value);
        void UpdateCargaSnapshotJson(int id, string value);
        void UpdatePreferenciasFiscaisJson(int id, string value);
        void UpdateStatus(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration