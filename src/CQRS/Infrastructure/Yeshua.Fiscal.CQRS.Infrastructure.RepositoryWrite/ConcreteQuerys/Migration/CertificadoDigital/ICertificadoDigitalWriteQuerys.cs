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

    public interface ICertificadoDigitalQueryWrite 
     {
        public QueryModel InserirCertificadoDigitalQuery(ICertificadoDigitalEntity CertificadoDigital);
        public QueryModel UpdateCertificadoDigitalQuery(ICertificadoDigitalEntity CertificadoDigital);
        QueryModel UpdateApelido(int id, string value);
        QueryModel UpdateDocumentoTitular(int id, string value);
        QueryModel UpdateStorageKey(int id, string value);
        QueryModel UpdateThumbprint(int id, string value);
        QueryModel UpdateValidoDe(int id, DateTime value);
        QueryModel UpdateValidoAte(int id, DateTime value);
        QueryModel UpdateAtivo(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteCertificadoDigitalQuery(ICertificadoDigitalEntity CertificadoDigital);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration