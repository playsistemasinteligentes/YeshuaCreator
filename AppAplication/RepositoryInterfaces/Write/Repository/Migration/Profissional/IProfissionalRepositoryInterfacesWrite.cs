using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Profissional
{
    public partial interface IProfissionalWriteRepository
    {
        void Insert(IProfissionalEntity profissional);
        void Update(IProfissionalEntity profissional);
        void Delete(IProfissionalEntity profissional);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration