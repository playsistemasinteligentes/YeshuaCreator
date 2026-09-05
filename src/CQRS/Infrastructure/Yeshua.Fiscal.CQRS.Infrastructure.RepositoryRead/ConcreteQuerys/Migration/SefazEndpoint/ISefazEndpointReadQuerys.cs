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
    public interface ISefazEndpointQueryRead 
    {
        public QueryModel SefazEndpointQuery(Command.Read.SefazEndpointReadCommand Command );
        public QueryModel SefazEndpointTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel SefazEndpointUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByProdutoFiscalQuery(int value );
        public QueryModel ExistsByUFQuery(string value );
        public QueryModel ExistsByAmbienteQuery(int value );
        public QueryModel ExistsByServicoQuery(string value );
        public QueryModel ExistsByVersaoQuery(string value );
        public QueryModel ExistsByUrlQuery(string value );
        public QueryModel ExistsByAtivoQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByProdutoFiscalQuery(int value );
        public QueryModel FirstByUFQuery(string value );
        public QueryModel FirstByAmbienteQuery(int value );
        public QueryModel FirstByServicoQuery(string value );
        public QueryModel FirstByVersaoQuery(string value );
        public QueryModel FirstByUrlQuery(string value );
        public QueryModel FirstByAtivoQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration