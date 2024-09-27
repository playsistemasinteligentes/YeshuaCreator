using Comandos.Pateners.Command;
using Dominio.Entitys.Servico;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Receivers.Servico
{
    public class InsertServicoReceiver : ReciverBase
    {
        private readonly IServicoWriteRepository _repository;

        public InsertServicoReceiver(IServicoWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var c = (Comandos.Commands.ServicoCommand)comand;

            var servico = new ServicoEntity(c.Id, c.GrupoServicoId, c.Nome, c.Valor);
            if (!servico.isValid())
                return new State(300, "Erro ", comand);

            try
            {
                _repository.Insert(servico);
                return new State(200, "OK", comand);
            }
            catch (Exception e)
            {
                return new State(500, "Erro", comand);
            }
        }
    }
}
