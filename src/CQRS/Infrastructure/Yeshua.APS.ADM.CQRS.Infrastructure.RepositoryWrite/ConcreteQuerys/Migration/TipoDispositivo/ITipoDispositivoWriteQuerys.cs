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

    public interface ITipoDispositivoQueryWrite 
     {
        public QueryModel InserirTipoDispositivoQuery(ITipoDispositivoEntity TipoDispositivo);
        public QueryModel UpdateTipoDispositivoQuery(ITipoDispositivoEntity TipoDispositivo);
        QueryModel UpdateTDI_ID(int id, string value);
        QueryModel UpdateTDI_DESCRICAO(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteTipoDispositivoQuery(ITipoDispositivoEntity TipoDispositivo);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration