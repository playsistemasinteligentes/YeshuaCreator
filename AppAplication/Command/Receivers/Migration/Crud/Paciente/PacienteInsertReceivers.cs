using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertPacienteReceiver : ReciverBase <IPacienteEntity>
    {
        private readonly IPacienteWriteRepository _repository;
        private readonly ILogger _logger;

        public InsertPacienteReceiver(IPacienteWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IPacienteEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.PacienteCrudCommand c) 
             {    
                 var paciente = new PacienteFactory(_logger).Create(c.Id, c.Nome, c.Telefone, c.DataNascimento, c.Genero, c.Escolaridade, c.Profissao, c.Endereco, c.NomeResponsavel, c.TelefoneResponsavel, c.Observacao);
                 if (!paciente.isValidInsert())
                     return ValidationError(paciente.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(paciente);
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