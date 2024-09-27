using Comandos.Pateners.Command;
using Dominio.Entitys.DisponibilidadeAgenda;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.DisponibilidadeAgenda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Receivers.DisponibilidadeAgenda
{
    public class InsertDisponibilidadeAgendaReceiver : ReciverBase
    {
        private readonly IDisponibilidadeAgendaWriteRepository _repository;

        public InsertDisponibilidadeAgendaReceiver(IDisponibilidadeAgendaWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var c = (Comandos.Commands.DisponibilidadeAgendaCommand)comand;

            var disponibilidadeagenda = new DisponibilidadeAgendaEntity(c.Id, c.ProfissionalId, c.DataHora);
            if (!disponibilidadeagenda.isValid())
                return new State(300, "Erro ", comand);

            try
            {
                _repository.Insert(disponibilidadeagenda);
                return new State(200, "OK", comand);
            }
            catch (Exception e)
            {
                return new State(500, "Erro", comand);
            }
        }
    }
}
