using Dominio.Entitys.Clinica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Clinica
{
    public partial interface IClinicaWriteRepository
    {
        void Insert(ClinicaEntity clinica);
        void InsertSmall(ClinicaEntity clinica);
    }
}
