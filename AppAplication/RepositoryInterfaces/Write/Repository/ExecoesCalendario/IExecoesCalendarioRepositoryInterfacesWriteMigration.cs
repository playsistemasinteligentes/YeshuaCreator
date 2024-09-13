using Dominio.Entitys.ExecoesCalendario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.ExecoesCalendario
{
    public partial interface IExecoesCalendarioWriteRepository
    {
        void Insert(ExecoesCalendarioEntity execoescalendario);
        void InsertSmall(ExecoesCalendarioEntity execoescalendario);
    }
}
