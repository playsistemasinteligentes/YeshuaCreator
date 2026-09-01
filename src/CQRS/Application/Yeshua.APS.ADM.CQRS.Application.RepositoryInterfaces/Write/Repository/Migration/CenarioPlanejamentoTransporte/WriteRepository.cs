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
    public partial interface ICenarioPlanejamentoTransporteWriteRepository
    {
        void Insert(ICenarioPlanejamentoTransporteEntity cenarioplanejamentotransporte);
        void Update(ICenarioPlanejamentoTransporteEntity cenarioplanejamentotransporte);
        void Delete(ICenarioPlanejamentoTransporteEntity cenarioplanejamentotransporte);
        void UpdateDescricao(string cenarioid, string value);
        void UpdateObjetivo(string cenarioid, string value);
        void UpdateQuantidadeCargas(string cenarioid, int value);
        void UpdateQuantidadePedidosNaoAtendidos(string cenarioid, int value);
        void UpdateCustoTotal(string cenarioid, Decimal value);
        void UpdateAderenciaCubagem(string cenarioid, Decimal value);
        void UpdateAtrasoPrevisto(string cenarioid, Decimal value);
        void UpdateAlertasResumo(string cenarioid, string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration