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
    public interface IEntradaFiscalContingenciaQueryRead 
    {
        public QueryModel EntradaFiscalContingenciaQuery(Command.Read.EntradaFiscalContingenciaReadCommand Command );
        public QueryModel EntradaFiscalContingenciaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel EntradaFiscalContingenciaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByCorrelationIdQuery(string value );
        public QueryModel ExistsByCargaIdQuery(string value );
        public QueryModel ExistsByTipoSolicitanteQuery(int value );
        public QueryModel ExistsByAmbienteQuery(int value );
        public QueryModel ExistsBySourceApplicationQuery(string value );
        public QueryModel ExistsBySourceModuleQuery(string value );
        public QueryModel ExistsBySourceMessageIdQuery(string value );
        public QueryModel ExistsByEmitenteFiscalDocumentoQuery(string value );
        public QueryModel ExistsByTomadorDocumentoQuery(string value );
        public QueryModel ExistsByTransportadorDocumentoQuery(string value );
        public QueryModel ExistsByRemetenteDocumentoQuery(string value );
        public QueryModel ExistsByDestinatarioDocumentoQuery(string value );
        public QueryModel ExistsByUFInicioQuery(string value );
        public QueryModel ExistsByUFFimQuery(string value );
        public QueryModel ExistsByMunicipioInicioCodigoIbgeQuery(string value );
        public QueryModel ExistsByMunicipioFimCodigoIbgeQuery(string value );
        public QueryModel ExistsByRNTRCQuery(string value );
        public QueryModel ExistsByPlacaVeiculoQuery(string value );
        public QueryModel ExistsByUFVeiculoQuery(string value );
        public QueryModel ExistsByCondutorDocumentoQuery(string value );
        public QueryModel ExistsByCondutorNomeQuery(string value );
        public QueryModel ExistsByQuantidadeDocumentosQuery(int value );
        public QueryModel ExistsByValorCargaQuery(Decimal value );
        public QueryModel ExistsByPesoBrutoQuery(Decimal value );
        public QueryModel ExistsByVolumeQuery(Decimal value );
        public QueryModel ExistsByPendenciasJsonQuery(string value );
        public QueryModel ExistsBySnapshotJsonQuery(string value );
        public QueryModel ExistsByEmissaoFiscalCorrelationIdQuery(string value );
        public QueryModel ExistsByEmissaoFiscalSagaIdQuery(int value );
        public QueryModel ExistsByCriadoEmUtcQuery(DateTime value );
        public QueryModel ExistsByAtualizadoEmUtcQuery(DateTime value );
        public QueryModel ExistsByStatusQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByCorrelationIdQuery(string value );
        public QueryModel FirstByCargaIdQuery(string value );
        public QueryModel FirstByTipoSolicitanteQuery(int value );
        public QueryModel FirstByAmbienteQuery(int value );
        public QueryModel FirstBySourceApplicationQuery(string value );
        public QueryModel FirstBySourceModuleQuery(string value );
        public QueryModel FirstBySourceMessageIdQuery(string value );
        public QueryModel FirstByEmitenteFiscalDocumentoQuery(string value );
        public QueryModel FirstByTomadorDocumentoQuery(string value );
        public QueryModel FirstByTransportadorDocumentoQuery(string value );
        public QueryModel FirstByRemetenteDocumentoQuery(string value );
        public QueryModel FirstByDestinatarioDocumentoQuery(string value );
        public QueryModel FirstByUFInicioQuery(string value );
        public QueryModel FirstByUFFimQuery(string value );
        public QueryModel FirstByMunicipioInicioCodigoIbgeQuery(string value );
        public QueryModel FirstByMunicipioFimCodigoIbgeQuery(string value );
        public QueryModel FirstByRNTRCQuery(string value );
        public QueryModel FirstByPlacaVeiculoQuery(string value );
        public QueryModel FirstByUFVeiculoQuery(string value );
        public QueryModel FirstByCondutorDocumentoQuery(string value );
        public QueryModel FirstByCondutorNomeQuery(string value );
        public QueryModel FirstByQuantidadeDocumentosQuery(int value );
        public QueryModel FirstByValorCargaQuery(Decimal value );
        public QueryModel FirstByPesoBrutoQuery(Decimal value );
        public QueryModel FirstByVolumeQuery(Decimal value );
        public QueryModel FirstByPendenciasJsonQuery(string value );
        public QueryModel FirstBySnapshotJsonQuery(string value );
        public QueryModel FirstByEmissaoFiscalCorrelationIdQuery(string value );
        public QueryModel FirstByEmissaoFiscalSagaIdQuery(int value );
        public QueryModel FirstByCriadoEmUtcQuery(DateTime value );
        public QueryModel FirstByAtualizadoEmUtcQuery(DateTime value );
        public QueryModel FirstByStatusQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration