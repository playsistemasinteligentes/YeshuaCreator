using Shered.DB;
namespace IQuery.Read
{
    public interface IMDFeQueryRead 
    {
        public QueryModel MDFeQuery(Command.Read.MDFeReadCommand Command );
        public QueryModel MDFeTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MDFeUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByChaveAcessoQuery(string value );
        public QueryModel ExistsBySerieQuery(int value );
        public QueryModel ExistsByNumeroQuery(int value );
        public QueryModel ExistsByUfCarregamentoQuery(string value );
        public QueryModel ExistsByUfDescarregamentoQuery(string value );
        public QueryModel ExistsByPlacaVeiculoQuery(string value );
        public QueryModel ExistsByEmitidoEmQuery(DateTime value );
        public QueryModel ExistsByAutorizadoEmQuery(DateTime value );
        public QueryModel ExistsByIniciadoEmQuery(DateTime value );
        public QueryModel ExistsByEncerradoEmQuery(DateTime value );
        public QueryModel ExistsByCanceladoEmQuery(DateTime value );
        public QueryModel ExistsBySituacaoQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByChaveAcessoQuery(string value );
        public QueryModel FirstBySerieQuery(int value );
        public QueryModel FirstByNumeroQuery(int value );
        public QueryModel FirstByUfCarregamentoQuery(string value );
        public QueryModel FirstByUfDescarregamentoQuery(string value );
        public QueryModel FirstByPlacaVeiculoQuery(string value );
        public QueryModel FirstByEmitidoEmQuery(DateTime value );
        public QueryModel FirstByAutorizadoEmQuery(DateTime value );
        public QueryModel FirstByIniciadoEmQuery(DateTime value );
        public QueryModel FirstByEncerradoEmQuery(DateTime value );
        public QueryModel FirstByCanceladoEmQuery(DateTime value );
        public QueryModel FirstBySituacaoQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration