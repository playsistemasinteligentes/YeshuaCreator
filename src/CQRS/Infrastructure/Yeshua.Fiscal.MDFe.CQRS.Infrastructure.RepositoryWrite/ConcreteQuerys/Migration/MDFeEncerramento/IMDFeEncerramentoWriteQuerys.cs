using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IMDFeEncerramentoQueryWrite 
     {
        public QueryModel InserirMDFeEncerramentoQuery(IMDFeEncerramentoEntity MDFeEncerramento);
        public QueryModel UpdateMDFeEncerramentoQuery(IMDFeEncerramentoEntity MDFeEncerramento);
        QueryModel UpdateMDFeId(int id, int value);
        QueryModel UpdateChaveAcesso(int id, string value);
        QueryModel UpdateUfCarregamento(int id, string value);
        QueryModel UpdateUfDescarregamento(int id, string value);
        QueryModel UpdatePlacaVeiculo(int id, string value);
        QueryModel UpdateSolicitadoEm(int id, DateTime value);
        QueryModel UpdateAutorizadoEm(int id, DateTime value);
        QueryModel UpdateProtocolo(int id, string value);
        QueryModel UpdateCodigoRetorno(int id, string value);
        QueryModel UpdateMensagemRetorno(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteMDFeEncerramentoQuery(IMDFeEncerramentoEntity MDFeEncerramento);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration