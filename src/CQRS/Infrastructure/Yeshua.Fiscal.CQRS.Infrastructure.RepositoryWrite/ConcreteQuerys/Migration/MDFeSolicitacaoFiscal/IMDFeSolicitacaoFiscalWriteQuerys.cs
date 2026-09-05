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

    public interface IMDFeSolicitacaoFiscalQueryWrite 
     {
        public QueryModel InserirMDFeSolicitacaoFiscalQuery(IMDFeSolicitacaoFiscalEntity MDFeSolicitacaoFiscal);
        public QueryModel UpdateMDFeSolicitacaoFiscalQuery(IMDFeSolicitacaoFiscalEntity MDFeSolicitacaoFiscal);
        QueryModel UpdateCorrelationId(int id, string value);
        QueryModel UpdateCargaId(int id, string value);
        QueryModel UpdateAmbiente(int id, int value);
        QueryModel UpdateUFCarregamento(int id, string value);
        QueryModel UpdateUFDescarregamento(int id, string value);
        QueryModel UpdatePlacaVeiculo(int id, string value);
        QueryModel UpdateCondutorDocumento(int id, string value);
        QueryModel UpdateDocumentosOriginariosJson(int id, string value);
        QueryModel UpdateTransporteSnapshotJson(int id, string value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteMDFeSolicitacaoFiscalQuery(IMDFeSolicitacaoFiscalEntity MDFeSolicitacaoFiscal);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration