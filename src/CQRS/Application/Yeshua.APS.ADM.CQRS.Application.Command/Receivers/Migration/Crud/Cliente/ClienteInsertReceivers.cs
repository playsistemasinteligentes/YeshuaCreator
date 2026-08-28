// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration
// </yeshua>

using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Behaviors;
using Dominio.Entitys;
using Dominio.Interfaces;
using Dominio.Patterns.Domain;
using IRepository.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertClienteReceiver : ReciverBase<ICommand, IClienteEntity>
    {
        private readonly IClienteWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertClienteReceiver(
            IClienteWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Dominio.Interfaces.IDomainTrackingPolicy domainTrackingPolicy,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
            _domainTrackingPolicy = domainTrackingPolicy;
            _executionContext = context;
        }

        protected override async Task<State<IClienteEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.ClienteCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertCliente", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertClienteReceiver), commandName: "Command.Write.ClienteCrudCommand");
                 var cliente = new ClienteFactory(_logger, _domainTrackingPolicy).Create(context, c.CLI_ID, c.CLI_NOME, c.CLI_FONE, c.CLI_OBS, c.CLI_ENDERECO_ENTREGA, c.CLI_CPF_CNPJ, c.CLI_BAIRRO_ENTREGA, c.CLI_CEP_ENTREGA, c.CLI_EMAIL, c.CLI_INTEGRACAO, c.MUN_ID_ENTREGA, c.CLI_TRANSLADO, c.CLI_REGIAO_ENTREGA, c.CLI_EXIGENTE_NA_IMPRESSAO, c.CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO, c.CLI_TEMPO_DESCARREGAMENTO_UNITARIO, c.CLI_PERCENTUAL_JANELA_EMBARQUE, c.REP_ID, c.CLI_RAZAO_SOCIAL, c.CLI_EMAIL_MONITORAMENTO_TRANSPORTE, c.CLI_CONTATO, c.CLI_SETOR, c.SEG_ID, c.CLI_TIPO, c.CLI_INTEGRACAO_ERP, c.CLI_LATITUDE_ENTREGA, c.CLI_LONGITUDE_ENTREGA);
                 var domainResult = ClienteDomainBehavior.Apply(cliente, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(cliente);
                     return Success("OK", cliente);
                 }
                 catch (Exception e)
                 {
                    return Error(e, cliente);
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