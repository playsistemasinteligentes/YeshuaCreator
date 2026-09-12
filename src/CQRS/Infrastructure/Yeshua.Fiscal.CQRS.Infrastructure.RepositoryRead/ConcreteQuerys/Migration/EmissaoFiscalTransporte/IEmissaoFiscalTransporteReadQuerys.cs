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
    public interface IEmissaoFiscalTransporteQueryRead 
    {
        public QueryModel EmissaoFiscalTransporteQuery(Command.Read.EmissaoFiscalTransporteReadCommand Command );
        public QueryModel EmissaoFiscalTransporteTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel EmissaoFiscalTransporteUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByCorrelationIdQuery(string value );
        public QueryModel ExistsByOrigemFluxoQuery(int value );
        public QueryModel ExistsByCargaIdQuery(string value );
        public QueryModel ExistsByRomaneioIdQuery(string value );
        public QueryModel ExistsByAmbienteQuery(int value );
        public QueryModel ExistsByEmitenteDocumentoQuery(string value );
        public QueryModel ExistsByTomadorDocumentoQuery(string value );
        public QueryModel ExistsByTransportadorDocumentoQuery(string value );
        public QueryModel ExistsByUFInicioQuery(string value );
        public QueryModel ExistsByUFFimQuery(string value );
        public QueryModel ExistsByMunicipioInicioCodigoIbgeQuery(string value );
        public QueryModel ExistsByMunicipioFimCodigoIbgeQuery(string value );
        public QueryModel ExistsByQuantidadeNFeQuery(int value );
        public QueryModel ExistsByQuantidadeCTeQuery(int value );
        public QueryModel ExistsByQuantidadeMDFeQuery(int value );
        public QueryModel ExistsByValorCargaQuery(Decimal value );
        public QueryModel ExistsByPesoBrutoQuery(Decimal value );
        public QueryModel ExistsByVolumeQuery(Decimal value );
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
        public QueryModel FirstByCorrelationIdQuery(string value );
        public QueryModel FirstByOrigemFluxoQuery(int value );
        public QueryModel FirstByCargaIdQuery(string value );
        public QueryModel FirstByRomaneioIdQuery(string value );
        public QueryModel FirstByAmbienteQuery(int value );
        public QueryModel FirstByEmitenteDocumentoQuery(string value );
        public QueryModel FirstByTomadorDocumentoQuery(string value );
        public QueryModel FirstByTransportadorDocumentoQuery(string value );
        public QueryModel FirstByUFInicioQuery(string value );
        public QueryModel FirstByUFFimQuery(string value );
        public QueryModel FirstByMunicipioInicioCodigoIbgeQuery(string value );
        public QueryModel FirstByMunicipioFimCodigoIbgeQuery(string value );
        public QueryModel FirstByQuantidadeNFeQuery(int value );
        public QueryModel FirstByQuantidadeCTeQuery(int value );
        public QueryModel FirstByQuantidadeMDFeQuery(int value );
        public QueryModel FirstByValorCargaQuery(Decimal value );
        public QueryModel FirstByPesoBrutoQuery(Decimal value );
        public QueryModel FirstByVolumeQuery(Decimal value );
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