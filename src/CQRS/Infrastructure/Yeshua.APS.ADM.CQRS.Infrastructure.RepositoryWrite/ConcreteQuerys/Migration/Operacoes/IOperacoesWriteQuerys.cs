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

    public interface IOperacoesQueryWrite 
     {
        public QueryModel InserirOperacoesQuery(IOperacoesEntity Operacoes);
        public QueryModel UpdateOperacoesQuery(IOperacoesEntity Operacoes);
        QueryModel UpdateOPE_TIPO_REGISTRO(int id, string value);
        QueryModel UpdateOPE_ID(int id, string value);
        QueryModel UpdateGMA_ID(int id, string value);
        QueryModel UpdateMAQ_ID(int id, string value);
        QueryModel UpdatePRO_ID(int id, string value);
        QueryModel UpdateOPE_EXCECAO(int id, string value);
        QueryModel UpdateROT_SEQ_TRANFORMACAO(int id, int value);
        QueryModel UpdateORD_ID(int id, string value);
        QueryModel UpdateFPR_SEQ_REPETICAO(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteOperacoesQuery(IOperacoesEntity Operacoes);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration