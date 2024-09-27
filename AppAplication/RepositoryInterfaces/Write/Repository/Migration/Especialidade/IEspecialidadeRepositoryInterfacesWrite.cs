using Dominio.Entitys.Especialidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Especialidade
{
    public partial interface IEspecialidadeWriteRepository
    {
        void Insert(EspecialidadeEntity especialidade);
        void InsertSmall(EspecialidadeEntity especialidade);
    }
}
