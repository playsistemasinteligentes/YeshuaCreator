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
    public partial interface ICargaPlanejavelWriteRepository
    {
        void Insert(ICargaPlanejavelEntity cargaplanejavel);
        void Update(ICargaPlanejavelEntity cargaplanejavel);
        void Delete(ICargaPlanejavelEntity cargaplanejavel);
        void UpdateStatus(string cargaid, string value);
        void UpdateTransportadoraId(string cargaid, string value);
        void UpdateVeiculoId(string cargaid, string value);
        void UpdateTipoVeiculoId(string cargaid, int value);
        void UpdatePesoTeorico(string cargaid, Decimal value);
        void UpdateVolumeTeorico(string cargaid, Decimal value);
        void UpdateInicioJanelaEmbarque(string cargaid, DateTime value);
        void UpdateFimJanelaEmbarque(string cargaid, DateTime value);
        void UpdateEmbarqueAlvo(string cargaid, DateTime value);
        void UpdateQuantidadePedidos(string cargaid, int value);
        void UpdateAlertasResumo(string cargaid, string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration