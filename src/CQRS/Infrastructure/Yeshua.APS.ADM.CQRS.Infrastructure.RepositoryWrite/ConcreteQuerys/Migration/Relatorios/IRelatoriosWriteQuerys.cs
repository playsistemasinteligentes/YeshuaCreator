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

    public interface IRelatoriosQueryWrite 
     {
        public QueryModel InserirRelatoriosQuery(IRelatoriosEntity Relatorios);
        public QueryModel UpdateRelatoriosQuery(IRelatoriosEntity Relatorios);
        QueryModel UpdateREL_NOME_RELATORIO(int rel_id, string value);
        QueryModel UpdateREL_NOME_CAMPO(int rel_id, string value);
        QueryModel UpdateREL_TIPO_CAMPO(int rel_id, string value);
        QueryModel UpdateREL_POS_X(int rel_id, int value);
        QueryModel UpdateREL_POS_Y(int rel_id, int value);
        QueryModel UpdateREL_TAMANHO_FONTE(int rel_id, int value);
        QueryModel UpdateTenantID(int rel_id, int value);
        QueryModel UpdateDeleted(int rel_id, bool value);
        QueryModel UpdateChanged(int rel_id, DateTime value);
        QueryModel UpdateUserId(int rel_id, int value);
        public QueryModel DeleteRelatoriosQuery(IRelatoriosEntity Relatorios);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration