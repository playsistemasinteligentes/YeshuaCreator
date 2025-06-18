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
        void Insert(Y_UserEntity y_user);
        void Update(Y_UserEntity y_user);
        void Delete(Y_UserEntity y_user);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration