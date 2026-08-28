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

    public interface IEnderecosQueryWrite 
     {
        public QueryModel InserirEnderecosQuery(IEnderecosEntity Enderecos);
        public QueryModel UpdateEnderecosQuery(IEnderecosEntity Enderecos);
        QueryModel UpdateEND_GRUPO(string end_id, string value);
        QueryModel UpdateTenantID(string end_id, int value);
        QueryModel UpdateDeleted(string end_id, bool value);
        QueryModel UpdateChanged(string end_id, DateTime value);
        QueryModel UpdateUserId(string end_id, int value);
        public QueryModel DeleteEnderecosQuery(IEnderecosEntity Enderecos);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration