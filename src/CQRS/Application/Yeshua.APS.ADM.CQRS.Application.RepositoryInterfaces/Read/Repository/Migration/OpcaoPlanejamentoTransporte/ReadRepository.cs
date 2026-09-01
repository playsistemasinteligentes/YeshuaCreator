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
    public partial interface IOpcaoPlanejamentoTransporteReadRepository
    {
        public DataPagination<OpcaoPlanejamentoTransporteDTO> getOpcaoPlanejamentoTransporte(ICommandRead command );
        public bool ExistsByOpcaoId(string value );
        public bool ExistsByGrupoDecisaoId(string value );
        public bool ExistsByPeso(Decimal value );
        public bool ExistsByVolume(Decimal value );
        public bool ExistsByCustoEstimado(Decimal value );
        public bool ExistsByAderenciaCubagem(Decimal value );
        public bool ExistsByAderenciaJanelaEntrega(Decimal value );
        public bool ExistsByRiscoResumo(string value );
        public bool ExistsByPedidosResumo(string value );
        public bool ExistsByOpcoesConflitantesResumo(string value );
        public OpcaoPlanejamentoTransporteDTO FirstByOpcaoId(string value );
        public OpcaoPlanejamentoTransporteDTO FirstByGrupoDecisaoId(string value );
        public OpcaoPlanejamentoTransporteDTO FirstByPeso(Decimal value );
        public OpcaoPlanejamentoTransporteDTO FirstByVolume(Decimal value );
        public OpcaoPlanejamentoTransporteDTO FirstByCustoEstimado(Decimal value );
        public OpcaoPlanejamentoTransporteDTO FirstByAderenciaCubagem(Decimal value );
        public OpcaoPlanejamentoTransporteDTO FirstByAderenciaJanelaEntrega(Decimal value );
        public OpcaoPlanejamentoTransporteDTO FirstByRiscoResumo(string value );
        public OpcaoPlanejamentoTransporteDTO FirstByPedidosResumo(string value );
        public OpcaoPlanejamentoTransporteDTO FirstByOpcoesConflitantesResumo(string value );
        public IEnumerable<OpcaoPlanejamentoTransporteDTO> GetAllByOpcaoId(string value );
        public IEnumerable<OpcaoPlanejamentoTransporteDTO> GetAllByGrupoDecisaoId(string value );
        public IEnumerable<OpcaoPlanejamentoTransporteDTO> GetAllByPeso(Decimal value );
        public IEnumerable<OpcaoPlanejamentoTransporteDTO> GetAllByVolume(Decimal value );
        public IEnumerable<OpcaoPlanejamentoTransporteDTO> GetAllByCustoEstimado(Decimal value );
        public IEnumerable<OpcaoPlanejamentoTransporteDTO> GetAllByAderenciaCubagem(Decimal value );
        public IEnumerable<OpcaoPlanejamentoTransporteDTO> GetAllByAderenciaJanelaEntrega(Decimal value );
        public IEnumerable<OpcaoPlanejamentoTransporteDTO> GetAllByRiscoResumo(string value );
        public IEnumerable<OpcaoPlanejamentoTransporteDTO> GetAllByPedidosResumo(string value );
        public IEnumerable<OpcaoPlanejamentoTransporteDTO> GetAllByOpcoesConflitantesResumo(string value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration