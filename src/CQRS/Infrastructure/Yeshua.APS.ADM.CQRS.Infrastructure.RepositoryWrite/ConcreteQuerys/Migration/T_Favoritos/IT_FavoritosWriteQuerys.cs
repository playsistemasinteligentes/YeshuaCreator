// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IT_FavoritosQueryWrite 
     {
        public QueryModel InserirT_FavoritosQuery(IT_FavoritosEntity T_Favoritos);
        public QueryModel UpdateT_FavoritosQuery(IT_FavoritosEntity T_Favoritos);
        QueryModel UpdateUSE_ID(int idfavorito, int value);
        QueryModel UpdateID_INDICADOR(int idfavorito, int value);
        QueryModel UpdateTenantID(int idfavorito, int value);
        QueryModel UpdateDeleted(int idfavorito, bool value);
        QueryModel UpdateChanged(int idfavorito, DateTime value);
        QueryModel UpdateUserId(int idfavorito, int value);
        public QueryModel DeleteT_FavoritosQuery(IT_FavoritosEntity T_Favoritos);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration