using Comandos.Pateners.Command;
using Dominio.Entitys.Profissional;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Profissional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Receivers.Profissional
{
    public class UpdateProfissionalReceiver : ReciverBase
    {
        private readonly IProfissionalWriteRepository _repository;

        public UpdateProfissionalReceiver(IProfissionalWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var c = (Comandos.Commands.ProfissionalCommand)comand;

            var profissional = new ProfissionalEntity(c.Id, c.Nome, c.EspecialidadeId, c.Telefone);
            if (!profissional.isValid())
                return new State(300, "Erro ", comand);

            try
            {
                _repository.Update(profissional);
                return new State(200, "OK", comand);
            }
            catch (Exception e)
            {
                return new State(500, "Erro", comand);
            }
        }
    }
}
