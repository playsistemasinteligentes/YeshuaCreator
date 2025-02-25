using Comandos.Pateners.Command;
using Dominio.Entitys.Profissional;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Profissional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class DeleteProfissionalReceiver : ReciverBase
    {
        private readonly IProfissionalWriteRepository _repository;

        public DeleteProfissionalReceiver(IProfissionalWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var c = (Command.Commands.ProfissionalCrudCommand)comand;

            var profissional = new ProfissionalEntity(c.Id, c.Nome, c.EspecialidadeId, c.Telefone);
            if (!profissional.isValid())
                return new State(300, "Erro ", comand);

            try
            {
                _repository.Delete(profissional);
                return new State(200, "OK", comand);
            }
            catch (Exception e)
            {
                return new State(500, "Erro", comand);
            }
        }
    }
}
