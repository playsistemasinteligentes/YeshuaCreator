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

    public interface ICTeEntradaOficialQueryWrite 
     {
        public QueryModel InserirCTeEntradaOficialQuery(ICTeEntradaOficialEntity CTeEntradaOficial);
        public QueryModel UpdateCTeEntradaOficialQuery(ICTeEntradaOficialEntity CTeEntradaOficial);
        QueryModel UpdateCorrelationId(int id, string value);
        QueryModel UpdateSourceApplication(int id, string value);
        QueryModel UpdateSourceModule(int id, string value);
        QueryModel UpdateSourceMessageId(int id, string value);
        QueryModel UpdateMessageType(int id, string value);
        QueryModel UpdateMessageVersion(int id, string value);
        QueryModel UpdateReceivedAtUtc(int id, DateTime value);
        QueryModel UpdatePayloadHash(int id, string value);
        QueryModel UpdatePayloadStorageKey(int id, string value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteCTeEntradaOficialQuery(ICTeEntradaOficialEntity CTeEntradaOficial);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration