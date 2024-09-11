using Comandos.Pateners.Command;
using Dominio.Entitys.Clinica;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Clinica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Receivers.Clinica
{
    public class InsertClinicaReceiver : ReciverBase
    {
        private readonly IClinicaWriteRepository _repository;

        public InsertClinicaReceiver(IClinicaWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var c = (Comandos.Commands.ClinicaCommand)comand;

            var clinica = new ClinicaEntity(c.Id, c.RazaoSocial, c.NomeReduzido);
            if (!clinica.isValid())
                return new State(300, "Erro ", comand);

            try
            {
                _repository.Insert(clinica);
                return new State(200, "OK", comand);
            }
            catch (Exception e)
            {
                return new State(500, "Erro", comand);
            }
        }
    }
}
