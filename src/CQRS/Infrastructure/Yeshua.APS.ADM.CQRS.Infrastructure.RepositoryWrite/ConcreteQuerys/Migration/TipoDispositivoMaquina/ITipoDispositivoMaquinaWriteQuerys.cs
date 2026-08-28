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

    public interface ITipoDispositivoMaquinaQueryWrite 
     {
        public QueryModel InserirTipoDispositivoMaquinaQuery(ITipoDispositivoMaquinaEntity TipoDispositivoMaquina);
        public QueryModel UpdateTipoDispositivoMaquinaQuery(ITipoDispositivoMaquinaEntity TipoDispositivoMaquina);
        QueryModel UpdateTDI_ID(int id, string value);
        QueryModel UpdateMAQ_ID(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteTipoDispositivoMaquinaQuery(ITipoDispositivoMaquinaEntity TipoDispositivoMaquina);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration