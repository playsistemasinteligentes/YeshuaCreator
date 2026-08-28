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

    public interface IPlanocontasQueryWrite 
     {
        public QueryModel InserirPlanocontasQuery(IPlanocontasEntity Planocontas);
        public QueryModel UpdatePlanocontasQuery(IPlanocontasEntity Planocontas);
        QueryModel UpdatePLA_CODIGO(int pla_id, string value);
        QueryModel UpdatePLA_DESCRICAO(int pla_id, string value);
        QueryModel UpdatePLA_TIPO(int pla_id, int value);
        QueryModel UpdatePLA_NATUREZA(int pla_id, string value);
        QueryModel UpdateTenantID(int pla_id, int value);
        QueryModel UpdateDeleted(int pla_id, bool value);
        QueryModel UpdateChanged(int pla_id, DateTime value);
        QueryModel UpdateUserId(int pla_id, int value);
        public QueryModel DeletePlanocontasQuery(IPlanocontasEntity Planocontas);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration