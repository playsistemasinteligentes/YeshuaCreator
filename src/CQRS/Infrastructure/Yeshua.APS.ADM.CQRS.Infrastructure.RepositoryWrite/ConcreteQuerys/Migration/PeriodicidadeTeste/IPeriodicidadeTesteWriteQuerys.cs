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

    public interface IPeriodicidadeTesteQueryWrite 
     {
        public QueryModel InserirPeriodicidadeTesteQuery(IPeriodicidadeTesteEntity PeriodicidadeTeste);
        public QueryModel UpdatePeriodicidadeTesteQuery(IPeriodicidadeTesteEntity PeriodicidadeTeste);
        QueryModel UpdatePER_ID(int id, int value);
        QueryModel UpdatePER_QTD(int id, string value);
        QueryModel UpdateUNI_ID(int id, string value);
        QueryModel UpdateGRP_ID(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeletePeriodicidadeTesteQuery(IPeriodicidadeTesteEntity PeriodicidadeTeste);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration