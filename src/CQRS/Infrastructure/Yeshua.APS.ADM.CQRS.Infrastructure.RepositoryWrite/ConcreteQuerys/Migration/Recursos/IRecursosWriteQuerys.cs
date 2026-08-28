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

    public interface IRecursosQueryWrite 
     {
        public QueryModel InserirRecursosQuery(IRecursosEntity Recursos);
        public QueryModel UpdateRecursosQuery(IRecursosEntity Recursos);
        QueryModel UpdateREC_DESCRICAO(string rec_id, string value);
        QueryModel UpdateCAL_ID(string rec_id, int value);
        QueryModel UpdateREC_CONTROL_IP(string rec_id, string value);
        QueryModel UpdateGRE_ID(string rec_id, string value);
        QueryModel UpdateTenantID(string rec_id, int value);
        QueryModel UpdateDeleted(string rec_id, bool value);
        QueryModel UpdateChanged(string rec_id, DateTime value);
        QueryModel UpdateUserId(string rec_id, int value);
        public QueryModel DeleteRecursosQuery(IRecursosEntity Recursos);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration