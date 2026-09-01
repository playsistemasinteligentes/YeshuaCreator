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
    public partial interface ICenarioPlanejamentoTransporteReadRepository
    {
        public DataPagination<CenarioPlanejamentoTransporteDTO> getCenarioPlanejamentoTransporte(ICommandRead command );
        public bool ExistsByCenarioId(string value );
        public bool ExistsByDescricao(string value );
        public bool ExistsByObjetivo(string value );
        public bool ExistsByQuantidadeCargas(int value );
        public bool ExistsByQuantidadePedidosNaoAtendidos(int value );
        public bool ExistsByCustoTotal(Decimal value );
        public bool ExistsByAderenciaCubagem(Decimal value );
        public bool ExistsByAtrasoPrevisto(Decimal value );
        public bool ExistsByAlertasResumo(string value );
        public CenarioPlanejamentoTransporteDTO FirstByCenarioId(string value );
        public CenarioPlanejamentoTransporteDTO FirstByDescricao(string value );
        public CenarioPlanejamentoTransporteDTO FirstByObjetivo(string value );
        public CenarioPlanejamentoTransporteDTO FirstByQuantidadeCargas(int value );
        public CenarioPlanejamentoTransporteDTO FirstByQuantidadePedidosNaoAtendidos(int value );
        public CenarioPlanejamentoTransporteDTO FirstByCustoTotal(Decimal value );
        public CenarioPlanejamentoTransporteDTO FirstByAderenciaCubagem(Decimal value );
        public CenarioPlanejamentoTransporteDTO FirstByAtrasoPrevisto(Decimal value );
        public CenarioPlanejamentoTransporteDTO FirstByAlertasResumo(string value );
        public IEnumerable<CenarioPlanejamentoTransporteDTO> GetAllByCenarioId(string value );
        public IEnumerable<CenarioPlanejamentoTransporteDTO> GetAllByDescricao(string value );
        public IEnumerable<CenarioPlanejamentoTransporteDTO> GetAllByObjetivo(string value );
        public IEnumerable<CenarioPlanejamentoTransporteDTO> GetAllByQuantidadeCargas(int value );
        public IEnumerable<CenarioPlanejamentoTransporteDTO> GetAllByQuantidadePedidosNaoAtendidos(int value );
        public IEnumerable<CenarioPlanejamentoTransporteDTO> GetAllByCustoTotal(Decimal value );
        public IEnumerable<CenarioPlanejamentoTransporteDTO> GetAllByAderenciaCubagem(Decimal value );
        public IEnumerable<CenarioPlanejamentoTransporteDTO> GetAllByAtrasoPrevisto(Decimal value );
        public IEnumerable<CenarioPlanejamentoTransporteDTO> GetAllByAlertasResumo(string value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration