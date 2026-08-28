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

    public interface IRestricoesDeRodagemQueryWrite 
     {
        public QueryModel InserirRestricoesDeRodagemQuery(IRestricoesDeRodagemEntity RestricoesDeRodagem);
        public QueryModel UpdateRestricoesDeRodagemQuery(IRestricoesDeRodagemEntity RestricoesDeRodagem);
        QueryModel UpdateRES_ID(int id, int value);
        QueryModel UpdateRES_TIPO(int id, string value);
        QueryModel UpdateRES_HORA_INI(int id, string value);
        QueryModel UpdateRES_HORA_FIM(int id, string value);
        QueryModel UpdateRES_VELOCIDADE_HORA_RUSH(int id, Decimal value);
        QueryModel UpdateTVE_ID(int id, int value);
        QueryModel UpdateMAP_ID(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteRestricoesDeRodagemQuery(IRestricoesDeRodagemEntity RestricoesDeRodagem);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration