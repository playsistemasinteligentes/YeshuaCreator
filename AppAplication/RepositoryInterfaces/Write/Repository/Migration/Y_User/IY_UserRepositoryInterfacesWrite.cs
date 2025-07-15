using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Y_User
{
    public partial interface IY_UserWriteRepository
    {
        void Insert(IY_UserEntity y_user);
        void Update(IY_UserEntity y_user);
        void Delete(IY_UserEntity y_user);
        public void UpdateNome(IY_UserEntity entity);
        public void UpdateEmail(IY_UserEntity entity);
        public void UpdateSenha(IY_UserEntity entity);
        public void UpdateTenantID(IY_UserEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration