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
    public partial interface IRoteiroReadRepository
    {
        public DataPagination<RoteiroDTO> getRoteiro(ICommandRead command );
        public IEnumerable<RoteiroMaquinaIdDTO> getRoteiroReadFKMaquinaId(object command );
        public IEnumerable<RoteiroProdutoIdDTO> getRoteiroReadFKProdutoId(object command );
        public IEnumerable<RoteiroGrupoMaquinaIdDTO> getRoteiroReadFKGrupoMaquinaId(object command );
        public IEnumerable<RoteiroTemplateDeTestesIdDTO> getRoteiroReadFKTemplateDeTestesId(object command );
        public IEnumerable<RoteiroTenantIDDTO> getRoteiroReadFKTenantID(object command );
        public IEnumerable<RoteiroUserIdDTO> getRoteiroReadFKUserId(object command );
        public bool ExistsByMaquinaId(string value );
        public bool ExistsByProdutoId(string value );
        public bool ExistsBySequenciaTransformacao(int value );
        public bool ExistsByGrupoMaquinaId(string value );
        public bool ExistsByPecasPorPulso(Decimal value );
        public bool ExistsByPrioridadeInformada(Decimal value );
        public bool ExistsByAcao(string value );
        public bool ExistsByPerformance(Decimal value );
        public bool ExistsByTempoSetup(Decimal value );
        public bool ExistsByTempoSetupAjuste(Decimal value );
        public bool ExistsByProximaSequenciaTransformacao(int value );
        public bool ExistsByStatus(string value );
        public bool ExistsByHierarquiaSequenciaTransformacao(Decimal value );
        public bool ExistsByAvaliaCusto(int value );
        public bool ExistsByOperacoes(string value );
        public bool ExistsByExcecaoOperacoes(string value );
        public bool ExistsByPercentualInicioPassoAnterior(Decimal value );
        public bool ExistsByLinhaDireta(string value );
        public bool ExistsByTemplateDeTestesId(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public RoteiroDTO FirstByMaquinaId(string value );
        public RoteiroDTO FirstByProdutoId(string value );
        public RoteiroDTO FirstBySequenciaTransformacao(int value );
        public RoteiroDTO FirstByGrupoMaquinaId(string value );
        public RoteiroDTO FirstByPecasPorPulso(Decimal value );
        public RoteiroDTO FirstByPrioridadeInformada(Decimal value );
        public RoteiroDTO FirstByAcao(string value );
        public RoteiroDTO FirstByPerformance(Decimal value );
        public RoteiroDTO FirstByTempoSetup(Decimal value );
        public RoteiroDTO FirstByTempoSetupAjuste(Decimal value );
        public RoteiroDTO FirstByProximaSequenciaTransformacao(int value );
        public RoteiroDTO FirstByStatus(string value );
        public RoteiroDTO FirstByHierarquiaSequenciaTransformacao(Decimal value );
        public RoteiroDTO FirstByAvaliaCusto(int value );
        public RoteiroDTO FirstByOperacoes(string value );
        public RoteiroDTO FirstByExcecaoOperacoes(string value );
        public RoteiroDTO FirstByPercentualInicioPassoAnterior(Decimal value );
        public RoteiroDTO FirstByLinhaDireta(string value );
        public RoteiroDTO FirstByTemplateDeTestesId(int value );
        public RoteiroDTO FirstByTenantID(int value );
        public RoteiroDTO FirstByDeleted(bool value );
        public RoteiroDTO FirstByChanged(DateTime value );
        public RoteiroDTO FirstByUserId(int value );
        public IEnumerable<RoteiroDTO> GetAllByMaquinaId(string value );
        public IEnumerable<RoteiroDTO> GetAllByProdutoId(string value );
        public IEnumerable<RoteiroDTO> GetAllBySequenciaTransformacao(int value );
        public IEnumerable<RoteiroDTO> GetAllByGrupoMaquinaId(string value );
        public IEnumerable<RoteiroDTO> GetAllByPecasPorPulso(Decimal value );
        public IEnumerable<RoteiroDTO> GetAllByPrioridadeInformada(Decimal value );
        public IEnumerable<RoteiroDTO> GetAllByAcao(string value );
        public IEnumerable<RoteiroDTO> GetAllByPerformance(Decimal value );
        public IEnumerable<RoteiroDTO> GetAllByTempoSetup(Decimal value );
        public IEnumerable<RoteiroDTO> GetAllByTempoSetupAjuste(Decimal value );
        public IEnumerable<RoteiroDTO> GetAllByProximaSequenciaTransformacao(int value );
        public IEnumerable<RoteiroDTO> GetAllByStatus(string value );
        public IEnumerable<RoteiroDTO> GetAllByHierarquiaSequenciaTransformacao(Decimal value );
        public IEnumerable<RoteiroDTO> GetAllByAvaliaCusto(int value );
        public IEnumerable<RoteiroDTO> GetAllByOperacoes(string value );
        public IEnumerable<RoteiroDTO> GetAllByExcecaoOperacoes(string value );
        public IEnumerable<RoteiroDTO> GetAllByPercentualInicioPassoAnterior(Decimal value );
        public IEnumerable<RoteiroDTO> GetAllByLinhaDireta(string value );
        public IEnumerable<RoteiroDTO> GetAllByTemplateDeTestesId(int value );
        public IEnumerable<RoteiroDTO> GetAllByTenantID(int value );
        public IEnumerable<RoteiroDTO> GetAllByDeleted(bool value );
        public IEnumerable<RoteiroDTO> GetAllByChanged(DateTime value );
        public IEnumerable<RoteiroDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration