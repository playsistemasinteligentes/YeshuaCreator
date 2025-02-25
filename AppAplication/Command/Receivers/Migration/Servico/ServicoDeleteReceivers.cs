using Comandos.Pateners.Command;
using Dominio.Entitys.Servico;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class DeleteServicoReceiver : ReciverBase
    {
        private readonly IServicoWriteRepository _repository;

        public DeleteServicoReceiver(IServicoWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var c = (Command.Commands.ServicoCrudCommand)comand;

            var servico = new ServicoEntity(c.Id, c.GrupoServicoId, c.Nome, c.Valor);
            if (!servico.isValid())
                return new State(300, "Erro ", comand);

            try
            {
                _repository.Delete(servico);
                return new State(200, "OK", comand);
            }
            catch (Exception e)
            {
                return new State(500, "Erro", comand);
            }
        }
    }
}
