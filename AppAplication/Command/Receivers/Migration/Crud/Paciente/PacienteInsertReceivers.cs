using Comandos.Pateners.Command;
using Dominio.Entitys.Paciente;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertPacienteReceiver : ReciverBase
    {
        private readonly IPacienteWriteRepository _repository;

        public InsertPacienteReceiver(IPacienteWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.PacienteCrudCommand c) 
             {    
                 var paciente = new PacienteEntity(c.Id, c.Nome, c.Telefone, c.DataNascimento, c.Genero, c.Escolaridade, c.Profissao, c.Endereco, c.NomeResponsavel, c.TelefoneResponsavel, c.PrincipaisQueixas, c.ObservacaoAdicional);
                 if (!paciente.isValidInsert())
                     return ValidationError(paciente.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(paciente);
                     return Success("OK", paciente);
                 }
                 catch (Exception e)
                 {
                     return Error(e, comand);
                 }
            }
            else 
            {
                 return Error("ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration