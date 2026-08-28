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

    public interface IOndaQueryWrite 
     {
        public QueryModel InserirOndaQuery(IOndaEntity Onda);
        public QueryModel UpdateOndaQuery(IOndaEntity Onda);
        QueryModel UpdateOND_ESPESSURA(string ond_id, Decimal value);
        QueryModel UpdateOND_PESO_COLA(string ond_id, Decimal value);
        QueryModel UpdateOND_RENDIMENTO_ONDA_1(string ond_id, Decimal value);
        QueryModel UpdateOND_RENDIMENTO_ONDA_2(string ond_id, Decimal value);
        QueryModel UpdateOND_PROFUNDIDADE_VINCO(string ond_id, int value);
        QueryModel UpdateOND_ID_INTEGRACAO(string ond_id, string value);
        QueryModel UpdateVIN_ID(string ond_id, int value);
        QueryModel UpdateTenantID(string ond_id, int value);
        QueryModel UpdateDeleted(string ond_id, bool value);
        QueryModel UpdateChanged(string ond_id, DateTime value);
        QueryModel UpdateUserId(string ond_id, int value);
        public QueryModel DeleteOndaQuery(IOndaEntity Onda);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration