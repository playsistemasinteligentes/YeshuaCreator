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
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration