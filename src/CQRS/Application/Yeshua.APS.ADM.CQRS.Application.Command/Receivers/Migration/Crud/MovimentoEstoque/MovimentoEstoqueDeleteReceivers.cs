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
    public class DeleteMovimentoEstoqueReceiver : ReciverBase<ICommand, IMovimentoEstoqueEntity>
    {
        private readonly IMovimentoEstoqueWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public DeleteMovimentoEstoqueReceiver(
            IMovimentoEstoqueWriteRepository repository,
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

        protected override async Task<State<IMovimentoEstoqueEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.MovimentoEstoqueCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Remocao, DomainEntryPoint.Crud, "DeleteMovimentoEstoque", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(DeleteMovimentoEstoqueReceiver), commandName: "Command.Write.MovimentoEstoqueCrudCommand");
                 var movimentoestoque = new MovimentoEstoqueFactory(_logger, _domainTrackingPolicy).Create(context, c.Id, c.ProdutoId, c.OrderId, c.Tipo, c.TurnoId, c.TurmaId, c.Quantidade, c.MOV_PESO_UNITARIO, c.DataHoraCriacao, c.DataHoraEmissao, c.DiaTurma, c.Lote, c.SubLote, c.MaquinaId, c.USE_ID, c.Observacao, c.OcorrenciaId, c.Armazem, c.Endereco, c.Estorno, c.SequenciaTransformacao, c.SequenciaRepeticao, c.ObsOpParcial, c.OcoIdOpParcial, c.MOV_ID_INTEGRACAO, c.MOV_ID_INTEGRACAO_ERP, c.CAR_ID, c.MOV_ID_DESTINO, c.PRO_ID_DESTINO, c.MOV_LOTE_DESTINO, c.MOV_SUB_LOTE_DESTINO, c.MOV_ID_ORIGEM, c.PRO_ID_ORIGEM, c.MOV_LOTE_ORIGEM, c.MOV_SUB_LOTE_ORIGEM, c.MOV_TYPE, c.MOV_DOC, c.MOV_APROVEITAMENTO, c.MOV_RETIDO, c.MOV_VINCOS_ONDULADEIRA, c.BOL_ID, c.ORD_ID_ORIGEM, c.COR_SEQUENCIA, c.VER_ID, c.MOV_TIPO_CUSTO, c.MOV_GRUPO_CONTABIL, c.FOR_ID, c.CLI_ID);
                 var domainResult = MovimentoEstoqueDomainBehavior.Apply(movimentoestoque, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Delete(movimentoestoque);
                     return Success("OK", movimentoestoque);
                 }
                 catch (Exception e)
                 {
                    return Error(e, movimentoestoque);
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