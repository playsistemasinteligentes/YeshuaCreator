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
    public partial interface IRoteiroPedidoReadRepository
    {
        public DataPagination<RoteiroPedidoDTO> getRoteiroPedido(ICommandRead command );
        public IEnumerable<RoteiroPedidoPedidoIdDTO> getRoteiroPedidoReadFKPedidoId(object command );
        public IEnumerable<RoteiroPedidoMaquinaIdDTO> getRoteiroPedidoReadFKMaquinaId(object command );
        public IEnumerable<RoteiroPedidoProdutoIdDTO> getRoteiroPedidoReadFKProdutoId(object command );
        public bool ExistsByPedidoId(string value );
        public bool ExistsByMaquinaId(string value );
        public bool ExistsByProdutoId(string value );
        public bool ExistsBySequenciaTransformacao(int value );
        public bool ExistsByStatusCadastro(string value );
        public bool ExistsByTipoPlanejamento(string value );
        public bool ExistsByCalendarioId(int value );
        public bool ExistsByHierarquiaSequenciaTransformacao(Decimal value );
        public bool ExistsByProximaSequenciaTransformacao(int value );
        public bool ExistsByPerformance(Decimal value );
        public bool ExistsByTempoSetup(Decimal value );
        public bool ExistsByTempoSetupAjuste(Decimal value );
        public bool ExistsByPecasPorPulso(Decimal value );
        public bool ExistsByPrioridadeInformada(Decimal value );
        public bool ExistsByStatus(string value );
        public bool ExistsByOperacoes(string value );
        public bool ExistsByExcecaoOperacoes(string value );
        public bool ExistsByLinhaDireta(string value );
        public bool ExistsByAvaliaCusto(int value );
        public bool ExistsByPercentualInicioPassoAnterior(Decimal value );
        public bool ExistsByMaquinaLarguraUtil(Decimal value );
        public bool ExistsByGrupoTipo(Decimal value );
        public bool ExistsByGrupoPerformanceMetroLinear(Decimal value );
        public RoteiroPedidoDTO FirstByPedidoId(string value );
        public RoteiroPedidoDTO FirstByMaquinaId(string value );
        public RoteiroPedidoDTO FirstByProdutoId(string value );
        public RoteiroPedidoDTO FirstBySequenciaTransformacao(int value );
        public RoteiroPedidoDTO FirstByStatusCadastro(string value );
        public RoteiroPedidoDTO FirstByTipoPlanejamento(string value );
        public RoteiroPedidoDTO FirstByCalendarioId(int value );
        public RoteiroPedidoDTO FirstByHierarquiaSequenciaTransformacao(Decimal value );
        public RoteiroPedidoDTO FirstByProximaSequenciaTransformacao(int value );
        public RoteiroPedidoDTO FirstByPerformance(Decimal value );
        public RoteiroPedidoDTO FirstByTempoSetup(Decimal value );
        public RoteiroPedidoDTO FirstByTempoSetupAjuste(Decimal value );
        public RoteiroPedidoDTO FirstByPecasPorPulso(Decimal value );
        public RoteiroPedidoDTO FirstByPrioridadeInformada(Decimal value );
        public RoteiroPedidoDTO FirstByStatus(string value );
        public RoteiroPedidoDTO FirstByOperacoes(string value );
        public RoteiroPedidoDTO FirstByExcecaoOperacoes(string value );
        public RoteiroPedidoDTO FirstByLinhaDireta(string value );
        public RoteiroPedidoDTO FirstByAvaliaCusto(int value );
        public RoteiroPedidoDTO FirstByPercentualInicioPassoAnterior(Decimal value );
        public RoteiroPedidoDTO FirstByMaquinaLarguraUtil(Decimal value );
        public RoteiroPedidoDTO FirstByGrupoTipo(Decimal value );
        public RoteiroPedidoDTO FirstByGrupoPerformanceMetroLinear(Decimal value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByPedidoId(string value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByMaquinaId(string value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByProdutoId(string value );
        public IEnumerable<RoteiroPedidoDTO> GetAllBySequenciaTransformacao(int value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByStatusCadastro(string value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByTipoPlanejamento(string value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByCalendarioId(int value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByHierarquiaSequenciaTransformacao(Decimal value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByProximaSequenciaTransformacao(int value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByPerformance(Decimal value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByTempoSetup(Decimal value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByTempoSetupAjuste(Decimal value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByPecasPorPulso(Decimal value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByPrioridadeInformada(Decimal value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByStatus(string value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByOperacoes(string value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByExcecaoOperacoes(string value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByLinhaDireta(string value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByAvaliaCusto(int value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByPercentualInicioPassoAnterior(Decimal value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByMaquinaLarguraUtil(Decimal value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByGrupoTipo(Decimal value );
        public IEnumerable<RoteiroPedidoDTO> GetAllByGrupoPerformanceMetroLinear(Decimal value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration