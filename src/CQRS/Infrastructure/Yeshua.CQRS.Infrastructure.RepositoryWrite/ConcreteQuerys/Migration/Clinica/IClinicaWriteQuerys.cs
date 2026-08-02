using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IClinicaQueryWrite 
     {
        public QueryModel InserirClinicaQuery(IClinicaEntity Clinica);
        public QueryModel UpdateClinicaQuery(IClinicaEntity Clinica);
        QueryModel UpdateNome(int id, string value);
        QueryModel UpdateEndereco(int id, string value);
        QueryModel UpdateTelefone(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteClinicaQuery(IClinicaEntity Clinica);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration