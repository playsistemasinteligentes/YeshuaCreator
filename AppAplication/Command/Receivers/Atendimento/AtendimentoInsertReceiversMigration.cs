using Comandos.Pateners.Command;
using Dominio.Entitys.Atendimento;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Atendimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Receivers.Atendimento
{
    public class InsertAtendimentoReceiver : ReciverBase
    {
        private readonly IAtendimentoWriteRepository _repository;

        public InsertAtendimentoReceiver(IAtendimentoWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var c = (Comandos.Commands.AtendimentoCommand)comand;

            var atendimento = new AtendimentoEntity(c.Id, c.Status, c.UltimaInteracao);
            if (!atendimento.isValid())
                return new State(300, "Erro ", comand);

            try
            {
                _repository.Insert(atendimento);
                return new State(200, "OK", comand);
            }
            catch (Exception e)
            {
                return new State(500, "Erro", comand);
            }
        }
    }
}
