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
    public partial interface IExperienciaPlanejamentoTransporteWriteRepository
    {
        void Insert(IExperienciaPlanejamentoTransporteEntity experienciaplanejamentotransporte);
        void Update(IExperienciaPlanejamentoTransporteEntity experienciaplanejamentotransporte);
        void Delete(IExperienciaPlanejamentoTransporteEntity experienciaplanejamentotransporte);
        void UpdateTipo(int id, int value);
        void UpdateReferencia(int id, string value);
        void UpdatePedidoId(int id, string value);
        void UpdateClienteId(int id, string value);
        void UpdateMunicipio(int id, string value);
        void UpdateRegiao(int id, string value);
        void UpdateRotaId(int id, string value);
        void UpdatePeso(int id, Decimal value);
        void UpdateVolume(int id, Decimal value);
        void UpdateObservacao(int id, string value);
        void UpdateCriadoEm(int id, DateTime value);
        void UpdateCriadoPor(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration