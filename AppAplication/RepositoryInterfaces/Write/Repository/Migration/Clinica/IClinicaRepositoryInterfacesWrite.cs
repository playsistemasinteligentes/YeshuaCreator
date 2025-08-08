using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IClinicaWriteRepository
    {
        void Insert(IClinicaEntity clinica);
        void Update(IClinicaEntity clinica);
        void Delete(IClinicaEntity clinica);
        public void UpdateNome(IClinicaEntity entity);
        public void UpdateEndereco(IClinicaEntity entity);
        public void UpdateTelefone(IClinicaEntity entity);
        public void UpdateTenantID(IClinicaEntity entity);
        public void UpdateDeleted(IClinicaEntity entity);
        public void UpdateChanged(IClinicaEntity entity);
        public void UpdateUserId(IClinicaEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration