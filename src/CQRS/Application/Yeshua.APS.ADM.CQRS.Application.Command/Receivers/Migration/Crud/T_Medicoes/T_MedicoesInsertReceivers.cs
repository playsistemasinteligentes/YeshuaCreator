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
    public class InsertT_MedicoesReceiver : ReciverBase<ICommand, IT_MedicoesEntity>
    {
        private readonly IT_MedicoesWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public InsertT_MedicoesReceiver(
            IT_MedicoesWriteRepository repository,
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

        protected override async Task<State<IT_MedicoesEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.T_MedicoesCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Registro, DomainEntryPoint.Crud, "InsertT_Medicoes", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(InsertT_MedicoesReceiver), commandName: "Command.Write.T_MedicoesCrudCommand");
                 var t_medicoes = new T_MedicoesFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.MED_ID, c.IND_ID, c.MET_ID, c.UNI_ID, c.MED_DATA, c.MED_VALOR, c.MED_AC_ANO, c.MED_DATAMEDICAO, c.MED_PONDERACAO, c.DIM_ID, c.DIM_DESCRICAO, c.DIM_SUBDIMENSAO_ID, c.DIM_SUB_DESCRICAO, c.PER_ID, c.PER_DESCRICAO, c.FAT_ID, c.FAT_DESCRICAO, c.MED_SQL, c.DOM_EMPRESA, c.DOM_FILIAL, c.MED_VALOR_DISPER);
                 var domainResult = T_MedicoesDomainBehavior.Apply(t_medicoes, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Insert(t_medicoes);
                     return Success("OK", t_medicoes);
                 }
                 catch (Exception e)
                 {
                    return Error(e, t_medicoes);
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