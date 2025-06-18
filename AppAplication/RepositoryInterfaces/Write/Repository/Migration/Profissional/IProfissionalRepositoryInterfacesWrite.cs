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
        void Insert(ProfissionalEntity profissional);
        void Update(ProfissionalEntity profissional);
        void Delete(ProfissionalEntity profissional);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration