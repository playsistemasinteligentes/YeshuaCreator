using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Sesoes
{
    public partial interface ISesoesWriteRepository
    {
        void Insert(ISesoesEntity sesoes);
        void Update(ISesoesEntity sesoes);
        void Delete(ISesoesEntity sesoes);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration