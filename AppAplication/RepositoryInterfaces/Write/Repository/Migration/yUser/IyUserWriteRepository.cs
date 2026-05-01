using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IyUserWriteRepository
    {
        void Insert(IyUserEntity yuser);
        void Update(IyUserEntity yuser);
        void Delete(IyUserEntity yuser);
        void UpdateNome(int id, string value);
        void UpdateEmail(int id, string value);
        void UpdateSenha(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration