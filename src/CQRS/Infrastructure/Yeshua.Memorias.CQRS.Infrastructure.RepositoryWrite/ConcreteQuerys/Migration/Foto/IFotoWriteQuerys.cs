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

    public interface IFotoQueryWrite 
     {
        public QueryModel InserirFotoQuery(IFotoEntity Foto);
        public QueryModel UpdateFotoQuery(IFotoEntity Foto);
        QueryModel UpdateStorageKey(int id, string value);
        QueryModel UpdateNomeOriginal(int id, string value);
        QueryModel UpdateContentType(int id, string value);
        QueryModel UpdateHashArquivo(int id, string value);
        QueryModel UpdateCapturadaEmUtc(int id, DateTime value);
        QueryModel UpdateLargura(int id, int value);
        QueryModel UpdateAltura(int id, int value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateOperationalEntityId(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteFotoQuery(IFotoEntity Foto);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration