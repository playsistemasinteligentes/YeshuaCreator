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

    public interface IProtocoloOnduladeiraQueryWrite 
     {
        public QueryModel InserirProtocoloOnduladeiraQuery(IProtocoloOnduladeiraEntity ProtocoloOnduladeira);
        public QueryModel UpdateProtocoloOnduladeiraQuery(IProtocoloOnduladeiraEntity ProtocoloOnduladeira);
        QueryModel UpdatePTO_ID(int id, string value);
        QueryModel UpdatePTO_CHAVE(int id, string value);
        QueryModel UpdateMAQ_ID(int id, string value);
        QueryModel UpdatePTO_COMANDO(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteProtocoloOnduladeiraQuery(IProtocoloOnduladeiraEntity ProtocoloOnduladeira);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration