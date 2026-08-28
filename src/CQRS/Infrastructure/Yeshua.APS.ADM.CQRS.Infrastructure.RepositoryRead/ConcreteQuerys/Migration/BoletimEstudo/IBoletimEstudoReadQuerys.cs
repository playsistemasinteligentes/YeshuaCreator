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
    public interface IBoletimEstudoQueryRead 
    {
        public QueryModel BoletimEstudoQuery(Command.Read.BoletimEstudoReadCommand Command );
        public QueryModel BoletimEstudoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel BoletimEstudoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByBOL_IDQuery(string value );
        public QueryModel ExistsByBOL_ID_ORIGEMQuery(string value );
        public QueryModel ExistsByBOL_SOLVERQuery(string value );
        public QueryModel ExistsByBOL_INTEGRACAOQuery(string value );
        public QueryModel ExistsByBOL_SEQUENCIAQuery(Decimal value );
        public QueryModel ExistsByGRP_PAP_GRAMATURA_PROGRAMADOQuery(Decimal value );
        public QueryModel ExistsByGRP_ID_PROGRAMADOQuery(string value );
        public QueryModel ExistsByGRP_PAPEL1_PROGRAMADOQuery(string value );
        public QueryModel ExistsByGRP_PAPEL2_PROGRAMADOQuery(string value );
        public QueryModel ExistsByGRP_PAPEL3_PROGRAMADOQuery(string value );
        public QueryModel ExistsByGRP_PAPEL4_PROGRAMADOQuery(string value );
        public QueryModel ExistsByGRP_PAPEL5_PROGRAMADOQuery(string value );
        public QueryModel ExistsByBOL_STATUS_INTERFACEQuery(string value );
        public QueryModel ExistsByBOL_TIPOQuery(string value );
        public QueryModel ExistsByBOL_FORMATOQuery(int value );
        public QueryModel ExistsByBOL_GRAMATURA_PAPEIS_PROGRAMADOSQuery(Decimal value );
        public QueryModel ExistsByBOL_GRAMATURA_PAPEIS_REALIZADOQuery(Decimal value );
        public QueryModel ExistsByBOL_CUSTO_PAPEIS_PROGRAMADOSQuery(Decimal value );
        public QueryModel ExistsByBOL_CUSTO_PAPEIS_REALIZADOQuery(Decimal value );
        public QueryModel ExistsByBOL_GRAMATURA_RESINA_PROGRAMADOSQuery(Decimal value );
        public QueryModel ExistsByBOL_CUSTO_RESINA_PROGRAMADOSQuery(Decimal value );
        public QueryModel ExistsByBOL_REFILE_OBRIGATORIOQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByBOL_IDQuery(string value );
        public QueryModel FirstByBOL_ID_ORIGEMQuery(string value );
        public QueryModel FirstByBOL_SOLVERQuery(string value );
        public QueryModel FirstByBOL_INTEGRACAOQuery(string value );
        public QueryModel FirstByBOL_SEQUENCIAQuery(Decimal value );
        public QueryModel FirstByGRP_PAP_GRAMATURA_PROGRAMADOQuery(Decimal value );
        public QueryModel FirstByGRP_ID_PROGRAMADOQuery(string value );
        public QueryModel FirstByGRP_PAPEL1_PROGRAMADOQuery(string value );
        public QueryModel FirstByGRP_PAPEL2_PROGRAMADOQuery(string value );
        public QueryModel FirstByGRP_PAPEL3_PROGRAMADOQuery(string value );
        public QueryModel FirstByGRP_PAPEL4_PROGRAMADOQuery(string value );
        public QueryModel FirstByGRP_PAPEL5_PROGRAMADOQuery(string value );
        public QueryModel FirstByBOL_STATUS_INTERFACEQuery(string value );
        public QueryModel FirstByBOL_TIPOQuery(string value );
        public QueryModel FirstByBOL_FORMATOQuery(int value );
        public QueryModel FirstByBOL_GRAMATURA_PAPEIS_PROGRAMADOSQuery(Decimal value );
        public QueryModel FirstByBOL_GRAMATURA_PAPEIS_REALIZADOQuery(Decimal value );
        public QueryModel FirstByBOL_CUSTO_PAPEIS_PROGRAMADOSQuery(Decimal value );
        public QueryModel FirstByBOL_CUSTO_PAPEIS_REALIZADOQuery(Decimal value );
        public QueryModel FirstByBOL_GRAMATURA_RESINA_PROGRAMADOSQuery(Decimal value );
        public QueryModel FirstByBOL_CUSTO_RESINA_PROGRAMADOSQuery(Decimal value );
        public QueryModel FirstByBOL_REFILE_OBRIGATORIOQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration