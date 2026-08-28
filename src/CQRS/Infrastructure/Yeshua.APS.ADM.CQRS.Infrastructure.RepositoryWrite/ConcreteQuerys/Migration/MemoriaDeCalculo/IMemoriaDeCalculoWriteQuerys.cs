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

    public interface IMemoriaDeCalculoQueryWrite 
     {
        public QueryModel InserirMemoriaDeCalculoQuery(IMemoriaDeCalculoEntity MemoriaDeCalculo);
        public QueryModel UpdateMemoriaDeCalculoQuery(IMemoriaDeCalculoEntity MemoriaDeCalculo);
        QueryModel UpdateMEM_ID(int id, int value);
        QueryModel UpdateORC_ID(int id, int value);
        QueryModel UpdateMEM_VALOR(int id, Decimal value);
        QueryModel UpdateMEM_DESCRICAO(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteMemoriaDeCalculoQuery(IMemoriaDeCalculoEntity MemoriaDeCalculo);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration