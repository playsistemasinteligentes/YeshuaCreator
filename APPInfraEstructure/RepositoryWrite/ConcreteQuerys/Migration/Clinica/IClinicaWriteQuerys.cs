using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IClinicaQueryWrite 
     {
        public QueryModel InserirClinicaQuery(IClinicaEntity Clinica);
        public QueryModel UpdateClinicaQuery(IClinicaEntity Clinica);
        public QueryModel UpdateNome(IClinicaEntity entity);
        public QueryModel UpdateEndereco(IClinicaEntity entity);
        public QueryModel UpdateTelefone(IClinicaEntity entity);
        public QueryModel DeleteClinicaQuery(IClinicaEntity Clinica);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration