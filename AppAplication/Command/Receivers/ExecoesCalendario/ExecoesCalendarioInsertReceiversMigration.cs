using Comandos.Pateners.Command;
using Dominio.Entitys.ExecoesCalendario;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.ExecoesCalendario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Receivers.ExecoesCalendario
{
    public class InsertExecoesCalendarioReceiver : ReciverBase
    {
        private readonly IExecoesCalendarioWriteRepository _repository;

        public InsertExecoesCalendarioReceiver(IExecoesCalendarioWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var c = (Comandos.Commands.ExecoesCalendarioCommand)comand;

            var execoescalendario = new ExecoesCalendarioEntity(c.Id, c.De, c.Ate);
            if (!execoescalendario.isValid())
                return new State(300, "Erro ", comand);

            try
            {
                _repository.Insert(execoescalendario);
                return new State(200, "OK", comand);
            }
            catch (Exception e)
            {
                return new State(500, "Erro", comand);
            }
        }
    }
}
