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

    public interface ITesteFisicoQueryWrite 
     {
        public QueryModel InserirTesteFisicoQuery(ITesteFisicoEntity TesteFisico);
        public QueryModel UpdateTesteFisicoQuery(ITesteFisicoEntity TesteFisico);
        QueryModel UpdateTES_ID(int id, int value);
        QueryModel UpdateITE_ID(int id, int value);
        QueryModel UpdateUSR_ID(int id, int value);
        QueryModel UpdateTES_NOME_TECNICO(int id, string value);
        QueryModel UpdateTES_AMOSTRA(int id, int value);
        QueryModel UpdateTES_OP(int id, string value);
        QueryModel UpdateTES_VALOR_NUMERICO(int id, Decimal value);
        QueryModel UpdateTES_VALOR_DATA(int id, DateTime value);
        QueryModel UpdateTES_VALOR_TEXTO(int id, string value);
        QueryModel UpdateTES_EMISSAO(int id, DateTime value);
        QueryModel UpdateORD_ID(int id, string value);
        QueryModel UpdatePRO_ID(int id, string value);
        QueryModel UpdateMAQ_ID(int id, string value);
        QueryModel UpdateFPR_SEQ_REPETICAO(int id, int value);
        QueryModel UpdateFPR_SEQ_TRANFORMACAO(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteTesteFisicoQuery(ITesteFisicoEntity TesteFisico);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration