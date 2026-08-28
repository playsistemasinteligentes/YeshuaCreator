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

    public interface IOrcamentoQueryWrite 
     {
        public QueryModel InserirOrcamentoQuery(IOrcamentoEntity Orcamento);
        public QueryModel UpdateOrcamentoQuery(IOrcamentoEntity Orcamento);
        QueryModel UpdateORC_ID(int id, int value);
        QueryModel UpdateREP_ID(int id, string value);
        QueryModel UpdateCON_ID(int id, string value);
        QueryModel UpdateORC_TIPO_FRETE(int id, string value);
        QueryModel UpdateORC_EMISSAO(int id, DateTime value);
        QueryModel UpdateCLI_ID(int id, string value);
        QueryModel UpdateVER_ID(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteOrcamentoQuery(IOrcamentoEntity Orcamento);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration