using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IProfissionalWriteRepository
    {
        void Insert(IProfissionalEntity profissional);
        void Update(IProfissionalEntity profissional);
        void Delete(IProfissionalEntity profissional);
        void UpdateNome(int id, string value);
        void UpdateEspecialidadeId(int id, int value);
        void UpdateTelefone(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration