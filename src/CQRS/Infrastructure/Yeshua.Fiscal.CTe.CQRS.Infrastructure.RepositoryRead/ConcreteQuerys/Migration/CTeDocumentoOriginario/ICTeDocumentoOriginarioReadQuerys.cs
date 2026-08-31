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
    public interface ICTeDocumentoOriginarioQueryRead 
    {
        public QueryModel CTeDocumentoOriginarioQuery(Command.Read.CTeDocumentoOriginarioReadCommand Command );
        public QueryModel CTeDocumentoOriginarioCTeSolicitacaoFiscalIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CTeDocumentoOriginarioTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CTeDocumentoOriginarioUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByCTeSolicitacaoFiscalIdQuery(int value );
        public QueryModel ExistsByTipoDocumentoQuery(string value );
        public QueryModel ExistsByChaveAcessoQuery(string value );
        public QueryModel ExistsByNumeroQuery(string value );
        public QueryModel ExistsBySerieQuery(string value );
        public QueryModel ExistsByEmitenteDocumentoQuery(string value );
        public QueryModel ExistsByDestinatarioDocumentoQuery(string value );
        public QueryModel ExistsByValorDocumentoQuery(Decimal value );
        public QueryModel ExistsByPesoBrutoQuery(Decimal value );
        public QueryModel ExistsBySnapshotJsonQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByCTeSolicitacaoFiscalIdQuery(int value );
        public QueryModel FirstByTipoDocumentoQuery(string value );
        public QueryModel FirstByChaveAcessoQuery(string value );
        public QueryModel FirstByNumeroQuery(string value );
        public QueryModel FirstBySerieQuery(string value );
        public QueryModel FirstByEmitenteDocumentoQuery(string value );
        public QueryModel FirstByDestinatarioDocumentoQuery(string value );
        public QueryModel FirstByValorDocumentoQuery(Decimal value );
        public QueryModel FirstByPesoBrutoQuery(Decimal value );
        public QueryModel FirstBySnapshotJsonQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration