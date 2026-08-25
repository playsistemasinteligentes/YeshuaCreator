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
    public interface IConsultaPedidoQueryRead 
    {
        public QueryModel ConsultaPedidoQuery(Command.Read.ConsultaPedidoReadCommand Command );
        public QueryModel ConsultaPedidoProdutoIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByPedidoIdQuery(string value );
        public QueryModel ExistsByClienteIdQuery(string value );
        public QueryModel ExistsByClienteNomeQuery(string value );
        public QueryModel ExistsByRazaoSocialQuery(string value );
        public QueryModel ExistsByProdutoIdQuery(string value );
        public QueryModel ExistsByProdutoDescricaoQuery(string value );
        public QueryModel ExistsByStatusQuery(string value );
        public QueryModel ExistsByEstagioQuery(string value );
        public QueryModel ExistsByDataEntregaDeQuery(DateTime value );
        public QueryModel ExistsByDataEntregaAteQuery(DateTime value );
        public QueryModel ExistsByEmbarqueAlvoQuery(DateTime value );
        public QueryModel ExistsByQuantidadeQuery(Decimal value );
        public QueryModel ExistsBySaldoAProduzirQuery(Decimal value );
        public QueryModel ExistsBySaldoAExpedirQuery(Decimal value );
        public QueryModel ExistsByCorFilaQuery(string value );
        public QueryModel ExistsByPedidoClienteQuery(string value );
        public QueryModel FirstByPedidoIdQuery(string value );
        public QueryModel FirstByClienteIdQuery(string value );
        public QueryModel FirstByClienteNomeQuery(string value );
        public QueryModel FirstByRazaoSocialQuery(string value );
        public QueryModel FirstByProdutoIdQuery(string value );
        public QueryModel FirstByProdutoDescricaoQuery(string value );
        public QueryModel FirstByStatusQuery(string value );
        public QueryModel FirstByEstagioQuery(string value );
        public QueryModel FirstByDataEntregaDeQuery(DateTime value );
        public QueryModel FirstByDataEntregaAteQuery(DateTime value );
        public QueryModel FirstByEmbarqueAlvoQuery(DateTime value );
        public QueryModel FirstByQuantidadeQuery(Decimal value );
        public QueryModel FirstBySaldoAProduzirQuery(Decimal value );
        public QueryModel FirstBySaldoAExpedirQuery(Decimal value );
        public QueryModel FirstByCorFilaQuery(string value );
        public QueryModel FirstByPedidoClienteQuery(string value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration