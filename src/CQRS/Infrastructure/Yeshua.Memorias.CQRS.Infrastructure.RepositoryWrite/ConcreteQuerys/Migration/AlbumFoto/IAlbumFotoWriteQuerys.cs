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

    public interface IAlbumFotoQueryWrite 
     {
        public QueryModel InserirAlbumFotoQuery(IAlbumFotoEntity AlbumFoto);
        public QueryModel UpdateAlbumFotoQuery(IAlbumFotoEntity AlbumFoto);
        QueryModel UpdateAlbumId(int id, int value);
        QueryModel UpdateFotoId(int id, int value);
        QueryModel UpdateOrdem(int id, int value);
        QueryModel UpdateLegenda(int id, string value);
        QueryModel UpdateOperationalEntityId(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteAlbumFotoQuery(IAlbumFotoEntity AlbumFoto);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration