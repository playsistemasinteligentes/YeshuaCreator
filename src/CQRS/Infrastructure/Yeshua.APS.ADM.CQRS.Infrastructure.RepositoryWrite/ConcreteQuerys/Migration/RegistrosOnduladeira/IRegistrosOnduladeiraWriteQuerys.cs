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

    public interface IRegistrosOnduladeiraQueryWrite 
     {
        public QueryModel InserirRegistrosOnduladeiraQuery(IRegistrosOnduladeiraEntity RegistrosOnduladeira);
        public QueryModel UpdateRegistrosOnduladeiraQuery(IRegistrosOnduladeiraEntity RegistrosOnduladeira);
        QueryModel UpdateREG_ID(int id, int value);
        QueryModel UpdateREG_RESPOSTA(int id, string value);
        QueryModel UpdateREG_STATUS(int id, string value);
        QueryModel UpdateREG_DATA_INICIO(int id, DateTime value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteRegistrosOnduladeiraQuery(IRegistrosOnduladeiraEntity RegistrosOnduladeira);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration