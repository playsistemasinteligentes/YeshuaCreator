using Dominio.Entitys.Atendimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Atendimento
{
    public partial interface IAtendimentoWriteRepository
    {
        void Insert(AtendimentoEntity atendimento);
        void InsertSmall(AtendimentoEntity atendimento);
    }
}
