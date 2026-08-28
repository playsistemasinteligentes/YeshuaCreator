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
    public interface ICorridasOnduladeiraEstudoQueryRead 
    {
        public QueryModel CorridasOnduladeiraEstudoQuery(Command.Read.CorridasOnduladeiraEstudoReadCommand Command );
        public QueryModel CorridasOnduladeiraEstudoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel CorridasOnduladeiraEstudoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByBOL_IDQuery(string value );
        public QueryModel ExistsByBOL_ID_ORIGEMQuery(string value );
        public QueryModel ExistsByPRO_LARGURA_PECAQuery(Decimal value );
        public QueryModel ExistsByPRO_LARGURA_PECA_PROGRAMADOQuery(Decimal value );
        public QueryModel ExistsByPRO_COMPRIMENTO_PECAQuery(Decimal value );
        public QueryModel ExistsByPRO_COMPRIMENTO_PECA_PROGRAMADOQuery(Decimal value );
        public QueryModel ExistsByPRO_UTILIZOU_REFILE_OBRIGATORIOQuery(Decimal value );
        public QueryModel ExistsByPRO_VINCOS_RECALCULADOSQuery(string value );
        public QueryModel ExistsByCOR_SOLVERQuery(string value );
        public QueryModel ExistsByCOR_GRAMATURA_PAPEIS_PROGRAMADOSQuery(Decimal value );
        public QueryModel ExistsByCOR_CUSTO_PAPEIS_PROGRAMADOSQuery(Decimal value );
        public QueryModel ExistsByCOR_GRAMATURA_RESINA_PROGRAMADOSQuery(Decimal value );
        public QueryModel ExistsByCOR_CUSTO_RESINA_PROGRAMADOSQuery(Decimal value );
        public QueryModel ExistsByCOR_TOLERANCIA_MENOSQuery(Decimal value );
        public QueryModel ExistsByCOR_TOLERANCIA_MAISQuery(Decimal value );
        public QueryModel ExistsByCOR_PILHAS_POR_PALETEQuery(int value );
        public QueryModel ExistsByCOR_M_LINEAR_REALIZADOQuery(Decimal value );
        public QueryModel ExistsByPRO_ID_PALETEQuery(string value );
        public QueryModel ExistsByCOR_STATUS_PALETEQuery(string value );
        public QueryModel ExistsByCOR_GRUPO_PRODUTIVOQuery(Decimal value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByBOL_IDQuery(string value );
        public QueryModel FirstByBOL_ID_ORIGEMQuery(string value );
        public QueryModel FirstByPRO_LARGURA_PECAQuery(Decimal value );
        public QueryModel FirstByPRO_LARGURA_PECA_PROGRAMADOQuery(Decimal value );
        public QueryModel FirstByPRO_COMPRIMENTO_PECAQuery(Decimal value );
        public QueryModel FirstByPRO_COMPRIMENTO_PECA_PROGRAMADOQuery(Decimal value );
        public QueryModel FirstByPRO_UTILIZOU_REFILE_OBRIGATORIOQuery(Decimal value );
        public QueryModel FirstByPRO_VINCOS_RECALCULADOSQuery(string value );
        public QueryModel FirstByCOR_SOLVERQuery(string value );
        public QueryModel FirstByCOR_GRAMATURA_PAPEIS_PROGRAMADOSQuery(Decimal value );
        public QueryModel FirstByCOR_CUSTO_PAPEIS_PROGRAMADOSQuery(Decimal value );
        public QueryModel FirstByCOR_GRAMATURA_RESINA_PROGRAMADOSQuery(Decimal value );
        public QueryModel FirstByCOR_CUSTO_RESINA_PROGRAMADOSQuery(Decimal value );
        public QueryModel FirstByCOR_TOLERANCIA_MENOSQuery(Decimal value );
        public QueryModel FirstByCOR_TOLERANCIA_MAISQuery(Decimal value );
        public QueryModel FirstByCOR_PILHAS_POR_PALETEQuery(int value );
        public QueryModel FirstByCOR_M_LINEAR_REALIZADOQuery(Decimal value );
        public QueryModel FirstByPRO_ID_PALETEQuery(string value );
        public QueryModel FirstByCOR_STATUS_PALETEQuery(string value );
        public QueryModel FirstByCOR_GRUPO_PRODUTIVOQuery(Decimal value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration