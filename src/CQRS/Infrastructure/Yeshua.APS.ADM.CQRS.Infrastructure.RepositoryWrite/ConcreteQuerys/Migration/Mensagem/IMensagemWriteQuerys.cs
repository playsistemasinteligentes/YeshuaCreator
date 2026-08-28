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

    public interface IMensagemQueryWrite 
     {
        public QueryModel InserirMensagemQuery(IMensagemEntity Mensagem);
        public QueryModel UpdateMensagemQuery(IMensagemEntity Mensagem);
        QueryModel UpdateMEN_SEND(string men_id, string value);
        QueryModel UpdateMEN_EMISSION(string men_id, DateTime value);
        QueryModel UpdateMEN_STATUS(string men_id, string value);
        QueryModel UpdateMEN_RECEIVE(string men_id, string value);
        QueryModel UpdateMEN_TYPE(string men_id, string value);
        QueryModel UpdateMEN_QTD_TRY_SEND(string men_id, Decimal value);
        QueryModel UpdateMEN_DATE_TRY_SEND(string men_id, DateTime value);
        QueryModel UpdateTenantID(string men_id, int value);
        QueryModel UpdateDeleted(string men_id, bool value);
        QueryModel UpdateChanged(string men_id, DateTime value);
        QueryModel UpdateUserId(string men_id, int value);
        public QueryModel DeleteMensagemQuery(IMensagemEntity Mensagem);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration