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
    public partial interface IOpcaoPlanejamentoTransporteWriteRepository
    {
        void Insert(IOpcaoPlanejamentoTransporteEntity opcaoplanejamentotransporte);
        void Update(IOpcaoPlanejamentoTransporteEntity opcaoplanejamentotransporte);
        void Delete(IOpcaoPlanejamentoTransporteEntity opcaoplanejamentotransporte);
        void UpdateGrupoDecisaoId(string opcaoid, string value);
        void UpdatePeso(string opcaoid, Decimal value);
        void UpdateVolume(string opcaoid, Decimal value);
        void UpdateCustoEstimado(string opcaoid, Decimal value);
        void UpdateAderenciaCubagem(string opcaoid, Decimal value);
        void UpdateAderenciaJanelaEntrega(string opcaoid, Decimal value);
        void UpdateRiscoResumo(string opcaoid, string value);
        void UpdatePedidosResumo(string opcaoid, string value);
        void UpdateOpcoesConflitantesResumo(string opcaoid, string value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration