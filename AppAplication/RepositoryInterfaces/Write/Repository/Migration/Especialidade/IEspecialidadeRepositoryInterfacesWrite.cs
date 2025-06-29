using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Especialidade
{
    public partial interface IEspecialidadeWriteRepository
    {
        void Insert(IEspecialidadeEntity especialidade);
        void Update(IEspecialidadeEntity especialidade);
        void Delete(IEspecialidadeEntity especialidade);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration