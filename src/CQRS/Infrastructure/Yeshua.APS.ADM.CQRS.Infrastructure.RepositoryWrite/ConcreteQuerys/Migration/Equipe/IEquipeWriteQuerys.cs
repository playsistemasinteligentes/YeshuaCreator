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

    public interface IEquipeQueryWrite 
     {
        public QueryModel InserirEquipeQuery(IEquipeEntity Equipe);
        public QueryModel UpdateEquipeQuery(IEquipeEntity Equipe);
        QueryModel UpdateEQU_ID(int id, string value);
        QueryModel UpdateEQU_HIERARQUIA_SEQ_TRANSFORMACAO(int id, Decimal value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteEquipeQuery(IEquipeEntity Equipe);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration