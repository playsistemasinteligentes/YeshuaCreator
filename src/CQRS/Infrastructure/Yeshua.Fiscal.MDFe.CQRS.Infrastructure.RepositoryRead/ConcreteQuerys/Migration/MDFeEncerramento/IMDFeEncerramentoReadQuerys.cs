// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration
// </yeshua>

using Shered.DB;
namespace IQuery.Read
{
    public interface IMDFeEncerramentoQueryRead 
    {
        public QueryModel MDFeEncerramentoQuery(Command.Read.MDFeEncerramentoReadCommand Command );
        public QueryModel MDFeEncerramentoMDFeIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MDFeEncerramentoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MDFeEncerramentoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByMDFeIdQuery(int value );
        public QueryModel ExistsByChaveAcessoQuery(string value );
        public QueryModel ExistsByUfCarregamentoQuery(string value );
        public QueryModel ExistsByUfDescarregamentoQuery(string value );
        public QueryModel ExistsByPlacaVeiculoQuery(string value );
        public QueryModel ExistsBySolicitadoEmQuery(DateTime value );
        public QueryModel ExistsByAutorizadoEmQuery(DateTime value );
        public QueryModel ExistsByProtocoloQuery(string value );
        public QueryModel ExistsByCodigoRetornoQuery(string value );
        public QueryModel ExistsByMensagemRetornoQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByMDFeIdQuery(int value );
        public QueryModel FirstByChaveAcessoQuery(string value );
        public QueryModel FirstByUfCarregamentoQuery(string value );
        public QueryModel FirstByUfDescarregamentoQuery(string value );
        public QueryModel FirstByPlacaVeiculoQuery(string value );
        public QueryModel FirstBySolicitadoEmQuery(DateTime value );
        public QueryModel FirstByAutorizadoEmQuery(DateTime value );
        public QueryModel FirstByProtocoloQuery(string value );
        public QueryModel FirstByCodigoRetornoQuery(string value );
        public QueryModel FirstByMensagemRetornoQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration