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

    public interface IConsultasQueryWrite 
     {
        public QueryModel InserirConsultasQuery(IConsultasEntity Consultas);
        public QueryModel UpdateConsultasQuery(IConsultasEntity Consultas);
        QueryModel UpdateCON_CASAS_DECIMAIS(int id, string value);
        QueryModel UpdateCON_CONEXAO(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteConsultasQuery(IConsultasEntity Consultas);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration