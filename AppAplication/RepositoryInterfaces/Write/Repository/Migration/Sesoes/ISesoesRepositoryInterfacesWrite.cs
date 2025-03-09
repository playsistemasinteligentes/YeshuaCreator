using Dominio.Entitys.Sesoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Sesoes
{
    public partial interface ISesoesWriteRepository
    {
        void Insert(SesoesEntity sesoes);
        void Update(SesoesEntity sesoes);
        void Delete(SesoesEntity sesoes);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration