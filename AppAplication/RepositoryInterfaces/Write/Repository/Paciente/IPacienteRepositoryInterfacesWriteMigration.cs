using Dominio.Entitys.Paciente;
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
        void InsertSmall(PacienteEntity paciente);
    }
}
