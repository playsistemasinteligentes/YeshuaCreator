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
    public interface ICTeSolicitacaoFiscalQueryRead 
    {
        public QueryModel CTeSolicitacaoFiscalQuery(Command.Read.CTeSolicitacaoFiscalReadCommand Command );
        public QueryModel CTeSolicitacaoFiscalEntradaOficialIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CTeSolicitacaoFiscalRomaneioConsolidadoIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CTeSolicitacaoFiscalTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CTeSolicitacaoFiscalUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByEntradaOficialIdQuery(int value );
        public QueryModel ExistsByRomaneioConsolidadoIdQuery(int value );
        public QueryModel ExistsByCorrelationIdQuery(string value );
        public QueryModel ExistsByAmbienteQuery(int value );
        public QueryModel ExistsByUFEmitenteQuery(string value );
        public QueryModel ExistsByEmitenteDocumentoQuery(string value );
        public QueryModel ExistsByProdutoFiscalQuery(int value );
        public QueryModel ExistsByTipoCTeQuery(int value );
        public QueryModel ExistsByTipoServicoQuery(int value );
        public QueryModel ExistsByModalQuery(int value );
        public QueryModel ExistsByGlobalizadoQuery(int value );
        public QueryModel ExistsByUFInicioQuery(string value );
        public QueryModel ExistsByUFFimQuery(string value );
        public QueryModel ExistsByMunicipioInicioCodigoIbgeQuery(string value );
        public QueryModel ExistsByMunicipioFimCodigoIbgeQuery(string value );
        public QueryModel ExistsByValorServicoQuery(Decimal value );
        public QueryModel ExistsByValorCargaQuery(Decimal value );
        public QueryModel ExistsByPreferenciasManifestoJsonQuery(string value );
        public QueryModel ExistsByStatusQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByEntradaOficialIdQuery(int value );
        public QueryModel FirstByRomaneioConsolidadoIdQuery(int value );
        public QueryModel FirstByCorrelationIdQuery(string value );
        public QueryModel FirstByAmbienteQuery(int value );
        public QueryModel FirstByUFEmitenteQuery(string value );
        public QueryModel FirstByEmitenteDocumentoQuery(string value );
        public QueryModel FirstByProdutoFiscalQuery(int value );
        public QueryModel FirstByTipoCTeQuery(int value );
        public QueryModel FirstByTipoServicoQuery(int value );
        public QueryModel FirstByModalQuery(int value );
        public QueryModel FirstByGlobalizadoQuery(int value );
        public QueryModel FirstByUFInicioQuery(string value );
        public QueryModel FirstByUFFimQuery(string value );
        public QueryModel FirstByMunicipioInicioCodigoIbgeQuery(string value );
        public QueryModel FirstByMunicipioFimCodigoIbgeQuery(string value );
        public QueryModel FirstByValorServicoQuery(Decimal value );
        public QueryModel FirstByValorCargaQuery(Decimal value );
        public QueryModel FirstByPreferenciasManifestoJsonQuery(string value );
        public QueryModel FirstByStatusQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration