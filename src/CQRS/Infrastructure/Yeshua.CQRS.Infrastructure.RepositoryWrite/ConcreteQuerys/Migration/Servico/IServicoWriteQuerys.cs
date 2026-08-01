using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IServicoQueryWrite 
     {
        public QueryModel InserirServicoQuery(IServicoEntity Servico);
        public QueryModel UpdateServicoQuery(IServicoEntity Servico);
        QueryModel UpdateGrupoServicoId(int id, int value);
        QueryModel UpdateNome(int id, string value);
        QueryModel UpdateValor(int id, Decimal value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteServicoQuery(IServicoEntity Servico);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration