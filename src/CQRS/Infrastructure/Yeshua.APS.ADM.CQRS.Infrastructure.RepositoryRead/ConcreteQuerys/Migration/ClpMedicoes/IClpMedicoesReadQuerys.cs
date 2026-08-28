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
    public interface IClpMedicoesQueryRead 
    {
        public QueryModel ClpMedicoesQuery(Command.Read.ClpMedicoesReadCommand Command );
        public QueryModel ClpMedicoesTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ClpMedicoesUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsById2Query(int value );
        public QueryModel ExistsByMaquinaIdQuery(string value );
        public QueryModel ExistsByDataInicioQuery(DateTime value );
        public QueryModel ExistsByDataFimQuery(DateTime value );
        public QueryModel ExistsByEmissaoQuery(DateTime value );
        public QueryModel ExistsByQuantidadeQuery(Decimal value );
        public QueryModel ExistsByGrupoQuery(Decimal value );
        public QueryModel ExistsByStatusQuery(int value );
        public QueryModel ExistsByTurnoIdQuery(string value );
        public QueryModel ExistsByTurmaIdQuery(string value );
        public QueryModel ExistsByIdLoteClpQuery(int value );
        public QueryModel ExistsByOcorrenciaIdQuery(string value );
        public QueryModel ExistsByFaseQuery(int value );
        public QueryModel ExistsByClpOrigemQuery(string value );
        public QueryModel ExistsByCLP_LOTEQuery(int value );
        public QueryModel ExistsByCOMPACTAQuery(int value );
        public QueryModel ExistsByBOL_IDQuery(string value );
        public QueryModel ExistsByCOR_SEQUENCIAQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstById2Query(int value );
        public QueryModel FirstByMaquinaIdQuery(string value );
        public QueryModel FirstByDataInicioQuery(DateTime value );
        public QueryModel FirstByDataFimQuery(DateTime value );
        public QueryModel FirstByEmissaoQuery(DateTime value );
        public QueryModel FirstByQuantidadeQuery(Decimal value );
        public QueryModel FirstByGrupoQuery(Decimal value );
        public QueryModel FirstByStatusQuery(int value );
        public QueryModel FirstByTurnoIdQuery(string value );
        public QueryModel FirstByTurmaIdQuery(string value );
        public QueryModel FirstByIdLoteClpQuery(int value );
        public QueryModel FirstByOcorrenciaIdQuery(string value );
        public QueryModel FirstByFaseQuery(int value );
        public QueryModel FirstByClpOrigemQuery(string value );
        public QueryModel FirstByCLP_LOTEQuery(int value );
        public QueryModel FirstByCOMPACTAQuery(int value );
        public QueryModel FirstByBOL_IDQuery(string value );
        public QueryModel FirstByCOR_SEQUENCIAQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration