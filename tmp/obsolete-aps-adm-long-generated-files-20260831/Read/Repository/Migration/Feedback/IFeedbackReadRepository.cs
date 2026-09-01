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
    public partial interface IFeedbackReadRepository
    {
        public DataPagination<FeedbackDTO> getFeedback(ICommandRead command );
        public IEnumerable<FeedbackOcorrenciaIdDTO> getFeedbackReadFKOcorrenciaId(object command );
        public IEnumerable<FeedbackTurnoIdDTO> getFeedbackReadFKTurnoId(object command );
        public IEnumerable<FeedbackTurmaIdDTO> getFeedbackReadFKTurmaId(object command );
        public IEnumerable<FeedbackUsuarioIdDTO> getFeedbackReadFKUsuarioId(object command );
        public IEnumerable<FeedbackTenantIDDTO> getFeedbackReadFKTenantID(object command );
        public IEnumerable<FeedbackUserIdDTO> getFeedbackReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByDataInicial(DateTime value );
        public bool ExistsByDatafinal(DateTime value );
        public bool ExistsByMaquinaId(string value );
        public bool ExistsByOcorrenciaId(string value );
        public bool ExistsByTurnoId(string value );
        public bool ExistsByTurmaId(string value );
        public bool ExistsByUsuarioId(int value );
        public bool ExistsByOrderId(string value );
        public bool ExistsByProdutoId(string value );
        public bool ExistsByObservacoes(string value );
        public bool ExistsByGrupo(Decimal value );
        public bool ExistsByDiaTurma(string value );
        public bool ExistsBySequenciaTransformacao(int value );
        public bool ExistsBySequenciaRepeticao(int value );
        public bool ExistsByQuantidadePulsos(Decimal value );
        public bool ExistsByQuantidadePecasPorPulso(Decimal value );
        public bool ExistsByFEE_QTD_TOTAL_PRODUCAO_AJUSTADA(Decimal value );
        public bool ExistsByBOL_ID(string value );
        public bool ExistsByCOR_SEQUENCIA(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public FeedbackDTO FirstById(int value );
        public FeedbackDTO FirstByDataInicial(DateTime value );
        public FeedbackDTO FirstByDatafinal(DateTime value );
        public FeedbackDTO FirstByMaquinaId(string value );
        public FeedbackDTO FirstByOcorrenciaId(string value );
        public FeedbackDTO FirstByTurnoId(string value );
        public FeedbackDTO FirstByTurmaId(string value );
        public FeedbackDTO FirstByUsuarioId(int value );
        public FeedbackDTO FirstByOrderId(string value );
        public FeedbackDTO FirstByProdutoId(string value );
        public FeedbackDTO FirstByObservacoes(string value );
        public FeedbackDTO FirstByGrupo(Decimal value );
        public FeedbackDTO FirstByDiaTurma(string value );
        public FeedbackDTO FirstBySequenciaTransformacao(int value );
        public FeedbackDTO FirstBySequenciaRepeticao(int value );
        public FeedbackDTO FirstByQuantidadePulsos(Decimal value );
        public FeedbackDTO FirstByQuantidadePecasPorPulso(Decimal value );
        public FeedbackDTO FirstByFEE_QTD_TOTAL_PRODUCAO_AJUSTADA(Decimal value );
        public FeedbackDTO FirstByBOL_ID(string value );
        public FeedbackDTO FirstByCOR_SEQUENCIA(int value );
        public FeedbackDTO FirstByTenantID(int value );
        public FeedbackDTO FirstByDeleted(bool value );
        public FeedbackDTO FirstByChanged(DateTime value );
        public FeedbackDTO FirstByUserId(int value );
        public IEnumerable<FeedbackDTO> GetAllById(int value );
        public IEnumerable<FeedbackDTO> GetAllByDataInicial(DateTime value );
        public IEnumerable<FeedbackDTO> GetAllByDatafinal(DateTime value );
        public IEnumerable<FeedbackDTO> GetAllByMaquinaId(string value );
        public IEnumerable<FeedbackDTO> GetAllByOcorrenciaId(string value );
        public IEnumerable<FeedbackDTO> GetAllByTurnoId(string value );
        public IEnumerable<FeedbackDTO> GetAllByTurmaId(string value );
        public IEnumerable<FeedbackDTO> GetAllByUsuarioId(int value );
        public IEnumerable<FeedbackDTO> GetAllByOrderId(string value );
        public IEnumerable<FeedbackDTO> GetAllByProdutoId(string value );
        public IEnumerable<FeedbackDTO> GetAllByObservacoes(string value );
        public IEnumerable<FeedbackDTO> GetAllByGrupo(Decimal value );
        public IEnumerable<FeedbackDTO> GetAllByDiaTurma(string value );
        public IEnumerable<FeedbackDTO> GetAllBySequenciaTransformacao(int value );
        public IEnumerable<FeedbackDTO> GetAllBySequenciaRepeticao(int value );
        public IEnumerable<FeedbackDTO> GetAllByQuantidadePulsos(Decimal value );
        public IEnumerable<FeedbackDTO> GetAllByQuantidadePecasPorPulso(Decimal value );
        public IEnumerable<FeedbackDTO> GetAllByFEE_QTD_TOTAL_PRODUCAO_AJUSTADA(Decimal value );
        public IEnumerable<FeedbackDTO> GetAllByBOL_ID(string value );
        public IEnumerable<FeedbackDTO> GetAllByCOR_SEQUENCIA(int value );
        public IEnumerable<FeedbackDTO> GetAllByTenantID(int value );
        public IEnumerable<FeedbackDTO> GetAllByDeleted(bool value );
        public IEnumerable<FeedbackDTO> GetAllByChanged(DateTime value );
        public IEnumerable<FeedbackDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration