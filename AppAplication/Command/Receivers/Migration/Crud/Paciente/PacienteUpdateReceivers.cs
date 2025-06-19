using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdatePacienteReceiver : ReciverBase <PacienteEntity>
    {
        private readonly IPacienteWriteRepository _repository;

        public UpdatePacienteReceiver(IPacienteWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State<PacienteEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.PacienteCrudCommand c) 
             {    
                 var paciente = new PacienteEntity(c.Id, c.Nome, c.Telefone, c.DataNascimento, c.Genero, c.Escolaridade, c.Profissao, c.Endereco, c.NomeResponsavel, c.TelefoneResponsavel, c.PrincipaisQueixas, c.ObservacaoAdicional);
                 if (!paciente.isValidUpdate())
                     return ValidationError(paciente.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(paciente);
                     return Success("OK", paciente);
                 }
                 catch (Exception e)
                 {
                    return Error(e, paciente);
                 }
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration