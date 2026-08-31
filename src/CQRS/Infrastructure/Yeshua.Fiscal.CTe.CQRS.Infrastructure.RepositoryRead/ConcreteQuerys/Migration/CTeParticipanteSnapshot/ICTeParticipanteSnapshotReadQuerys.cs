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
    public interface ICTeParticipanteSnapshotQueryRead 
    {
        public QueryModel CTeParticipanteSnapshotQuery(Command.Read.CTeParticipanteSnapshotReadCommand Command );
        public QueryModel CTeParticipanteSnapshotCTeSolicitacaoFiscalIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CTeParticipanteSnapshotTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CTeParticipanteSnapshotUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByCTeSolicitacaoFiscalIdQuery(int value );
        public QueryModel ExistsByPapelQuery(string value );
        public QueryModel ExistsByDocumentoQuery(string value );
        public QueryModel ExistsByNomeQuery(string value );
        public QueryModel ExistsByInscricaoEstadualQuery(string value );
        public QueryModel ExistsByUFQuery(string value );
        public QueryModel ExistsByMunicipioCodigoIbgeQuery(string value );
        public QueryModel ExistsByEnderecoJsonQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByCTeSolicitacaoFiscalIdQuery(int value );
        public QueryModel FirstByPapelQuery(string value );
        public QueryModel FirstByDocumentoQuery(string value );
        public QueryModel FirstByNomeQuery(string value );
        public QueryModel FirstByInscricaoEstadualQuery(string value );
        public QueryModel FirstByUFQuery(string value );
        public QueryModel FirstByMunicipioCodigoIbgeQuery(string value );
        public QueryModel FirstByEnderecoJsonQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration