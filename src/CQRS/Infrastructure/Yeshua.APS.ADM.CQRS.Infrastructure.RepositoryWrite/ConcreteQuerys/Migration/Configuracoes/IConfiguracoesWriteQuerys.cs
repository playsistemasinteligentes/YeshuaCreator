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

    public interface IConfiguracoesQueryWrite 
     {
        public QueryModel InserirConfiguracoesQuery(IConfiguracoesEntity Configuracoes);
        public QueryModel UpdateConfiguracoesQuery(IConfiguracoesEntity Configuracoes);
        QueryModel UpdateTenantID(int con_id, int value);
        QueryModel UpdateDeleted(int con_id, bool value);
        QueryModel UpdateChanged(int con_id, DateTime value);
        QueryModel UpdateUserId(int con_id, int value);
        public QueryModel DeleteConfiguracoesQuery(IConfiguracoesEntity Configuracoes);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration