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
    public interface IContingenciaFiscalQueryRead 
    {
        public QueryModel ContingenciaFiscalQuery(Command.Read.ContingenciaFiscalReadCommand Command );
        public QueryModel ContingenciaFiscalEmissaoFiscalTransporteIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ContingenciaFiscalEntradaFiscalContingenciaIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ContingenciaFiscalTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ContingenciaFiscalUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByEmissaoFiscalTransporteIdQuery(int value );
        public QueryModel ExistsByEntradaFiscalContingenciaIdQuery(int value );
        public QueryModel ExistsByCorrelationIdQuery(string value );
        public QueryModel ExistsByCargaIdQuery(string value );
        public QueryModel ExistsByTipoSolicitanteQuery(int value );
        public QueryModel ExistsByAmbienteQuery(int value );
        public QueryModel ExistsByEmitenteDocumentoQuery(string value );
        public QueryModel ExistsByTomadorDocumentoQuery(string value );
        public QueryModel ExistsByTransportadorDocumentoQuery(string value );
        public QueryModel ExistsByQuantidadeDocumentosQuery(int value );
        public QueryModel ExistsByQuantidadeCTeQuery(int value );
        public QueryModel ExistsByQuantidadeMDFeQuery(int value );
        public QueryModel ExistsByValorCargaQuery(Decimal value );
        public QueryModel ExistsByPesoBrutoQuery(Decimal value );
        public QueryModel ExistsByUltimaMensagemQuery(string value );
        public QueryModel ExistsByCriadoEmUtcQuery(DateTime value );
        public QueryModel ExistsByAtualizadoEmUtcQuery(DateTime value );
        public QueryModel ExistsByConcluidoEmUtcQuery(DateTime value );
        public QueryModel ExistsByStatusQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByEmissaoFiscalTransporteIdQuery(int value );
        public QueryModel FirstByEntradaFiscalContingenciaIdQuery(int value );
        public QueryModel FirstByCorrelationIdQuery(string value );
        public QueryModel FirstByCargaIdQuery(string value );
        public QueryModel FirstByTipoSolicitanteQuery(int value );
        public QueryModel FirstByAmbienteQuery(int value );
        public QueryModel FirstByEmitenteDocumentoQuery(string value );
        public QueryModel FirstByTomadorDocumentoQuery(string value );
        public QueryModel FirstByTransportadorDocumentoQuery(string value );
        public QueryModel FirstByQuantidadeDocumentosQuery(int value );
        public QueryModel FirstByQuantidadeCTeQuery(int value );
        public QueryModel FirstByQuantidadeMDFeQuery(int value );
        public QueryModel FirstByValorCargaQuery(Decimal value );
        public QueryModel FirstByPesoBrutoQuery(Decimal value );
        public QueryModel FirstByUltimaMensagemQuery(string value );
        public QueryModel FirstByCriadoEmUtcQuery(DateTime value );
        public QueryModel FirstByAtualizadoEmUtcQuery(DateTime value );
        public QueryModel FirstByConcluidoEmUtcQuery(DateTime value );
        public QueryModel FirstByStatusQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration