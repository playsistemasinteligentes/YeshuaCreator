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
        void Insert(IPacienteEntity paciente);
        void Update(IPacienteEntity paciente);
        void Delete(IPacienteEntity paciente);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration