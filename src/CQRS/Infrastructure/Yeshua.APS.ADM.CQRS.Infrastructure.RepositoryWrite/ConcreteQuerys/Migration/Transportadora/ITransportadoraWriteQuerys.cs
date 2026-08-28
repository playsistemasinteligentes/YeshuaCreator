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

    public interface ITransportadoraQueryWrite 
     {
        public QueryModel InserirTransportadoraQuery(ITransportadoraEntity Transportadora);
        public QueryModel UpdateTransportadoraQuery(ITransportadoraEntity Transportadora);
        QueryModel UpdateTRA_ID(int id, string value);
        QueryModel UpdateTRA_NOME(int id, string value);
        QueryModel UpdateTRA_EMAIL(int id, string value);
        QueryModel UpdateTRA_RESPONSAVEL(int id, string value);
        QueryModel UpdateTRA_FONE(int id, string value);
        QueryModel UpdateTRA_ID_INTEGRACAO(int id, string value);
        QueryModel UpdateTRA_ID_INTEGRACAO_ERP(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteTransportadoraQuery(ITransportadoraEntity Transportadora);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration