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

    public interface ICTeParticipanteSnapshotQueryWrite 
     {
        public QueryModel InserirCTeParticipanteSnapshotQuery(ICTeParticipanteSnapshotEntity CTeParticipanteSnapshot);
        public QueryModel UpdateCTeParticipanteSnapshotQuery(ICTeParticipanteSnapshotEntity CTeParticipanteSnapshot);
        QueryModel UpdateCTeSolicitacaoFiscalId(int id, int value);
        QueryModel UpdatePapel(int id, string value);
        QueryModel UpdateDocumento(int id, string value);
        QueryModel UpdateNome(int id, string value);
        QueryModel UpdateInscricaoEstadual(int id, string value);
        QueryModel UpdateUF(int id, string value);
        QueryModel UpdateMunicipioCodigoIbge(int id, string value);
        QueryModel UpdateEnderecoJson(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteCTeParticipanteSnapshotQuery(ICTeParticipanteSnapshotEntity CTeParticipanteSnapshot);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration