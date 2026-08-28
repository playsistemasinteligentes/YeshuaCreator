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

    public interface ITabelaQueryWrite 
     {
        public QueryModel InserirTabelaQuery(ITabelaEntity Tabela);
        public QueryModel UpdateTabelaQuery(ITabelaEntity Tabela);
        QueryModel UpdateCODIGO(int id_tabela, string value);
        QueryModel UpdateNOME(int id_tabela, string value);
        QueryModel UpdateTenantID(int id_tabela, int value);
        QueryModel UpdateDeleted(int id_tabela, bool value);
        QueryModel UpdateChanged(int id_tabela, DateTime value);
        QueryModel UpdateUserId(int id_tabela, int value);
        public QueryModel DeleteTabelaQuery(ITabelaEntity Tabela);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration