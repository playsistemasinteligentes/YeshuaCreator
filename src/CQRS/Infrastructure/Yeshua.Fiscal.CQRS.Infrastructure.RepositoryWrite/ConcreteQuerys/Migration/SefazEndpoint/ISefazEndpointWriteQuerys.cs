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

    public interface ISefazEndpointQueryWrite 
     {
        public QueryModel InserirSefazEndpointQuery(ISefazEndpointEntity SefazEndpoint);
        public QueryModel UpdateSefazEndpointQuery(ISefazEndpointEntity SefazEndpoint);
        QueryModel UpdateProdutoFiscal(int id, int value);
        QueryModel UpdateUF(int id, string value);
        QueryModel UpdateAmbiente(int id, int value);
        QueryModel UpdateServico(int id, string value);
        QueryModel UpdateVersao(int id, string value);
        QueryModel UpdateUrl(int id, string value);
        QueryModel UpdateAtivo(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteSefazEndpointQuery(ISefazEndpointEntity SefazEndpoint);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration