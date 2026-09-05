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
    public interface ICertificadoDigitalQueryRead 
    {
        public QueryModel CertificadoDigitalQuery(Command.Read.CertificadoDigitalReadCommand Command );
        public QueryModel CertificadoDigitalTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CertificadoDigitalUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByApelidoQuery(string value );
        public QueryModel ExistsByDocumentoTitularQuery(string value );
        public QueryModel ExistsByStorageKeyQuery(string value );
        public QueryModel ExistsByThumbprintQuery(string value );
        public QueryModel ExistsByValidoDeQuery(DateTime value );
        public QueryModel ExistsByValidoAteQuery(DateTime value );
        public QueryModel ExistsByAtivoQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByApelidoQuery(string value );
        public QueryModel FirstByDocumentoTitularQuery(string value );
        public QueryModel FirstByStorageKeyQuery(string value );
        public QueryModel FirstByThumbprintQuery(string value );
        public QueryModel FirstByValidoDeQuery(DateTime value );
        public QueryModel FirstByValidoAteQuery(DateTime value );
        public QueryModel FirstByAtivoQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration