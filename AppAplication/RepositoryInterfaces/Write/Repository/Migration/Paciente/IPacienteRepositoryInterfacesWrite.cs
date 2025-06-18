using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Paciente
{
    public partial interface IPacienteWriteRepository
    {
        void Insert(PacienteEntity paciente);
        void Update(PacienteEntity paciente);
        void Delete(PacienteEntity paciente);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration