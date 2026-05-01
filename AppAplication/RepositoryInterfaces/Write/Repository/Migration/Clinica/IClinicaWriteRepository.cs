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
        void UpdateNome(int id, string value);
        void UpdateEndereco(int id, string value);
        void UpdateTelefone(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration