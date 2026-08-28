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
    public class UpdateGrupoProdutoAbstratoReceiver : ReciverBase<ICommand, IGrupoProdutoAbstratoEntity>
    {
        private readonly IGrupoProdutoAbstratoWriteRepository _repository;
        private readonly ILogger _logger;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy;
        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;

        public UpdateGrupoProdutoAbstratoReceiver(
            IGrupoProdutoAbstratoWriteRepository repository,
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

        protected override async Task<State<IGrupoProdutoAbstratoEntity>> ActionAsync(ICommand comand, CancellationToken cancellationToken = default)
        {
             if(comand is Command.Write.GrupoProdutoAbstratoCrudCommand c) 
             {    
                 var context = DomainOperationContext.Create(DomainOperation.Alteracao, DomainEntryPoint.Crud, "UpdateGrupoProdutoAbstrato", _executionContext.TenantID, _executionContext.UserId, traceId: _executionContext.TraceId, receiverName: nameof(UpdateGrupoProdutoAbstratoReceiver), commandName: "Command.Write.GrupoProdutoAbstratoCrudCommand");
                 var grupoprodutoabstrato = new GrupoProdutoAbstratoFactory(_logger, _domainTrackingPolicy).Create(context, c.GRP_ID, c.GRP_DESCRICAO, c.TEM_ID, c.GRP_TIPO, c.GRP_PAP_ONDA, c.GRP_PAP_GRAMATURA, c.GRP_PAP_ALTURA, c.GRP_PAP_NOME_COMERCIAL, c.GRP_ATIVO, c.GRP_DT_CRIACAO, c.GRP_PAPEL1, c.GRP_PAPEL2, c.GRP_PAPEL3, c.GRP_PAPEL4, c.GRP_PAPEL5, c.GRP_ID_INTEGRACAO, c.GRP_ID_INTEGRACAO_ERP, c.GRP_TYPE, c.GRP_PERFORMANCE, c.GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, c.GRP_RESINA, c.GRP_ENDURECEDOR_MIOLO, c.VIN_ID, c.GRP_COLUNA_DE, c.GRP_COLUNA_ATE, c.GRP_CRUSH, c.GRP_ID_FAMILIA, c.GRP_REFILE_LARGURA, c.GRP_REFILE_COMPRIMENTO, c.GRP_TIPO_LAP, c.GRP_LAP_PROLONGADO, c.GRP_TAMANHO_LAP_OND_SIMPLES, c.GRP_TAMANHO_LAP_OND_DUPLA, c.GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, c.GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, c.GRP_FEFCO, c.GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, c.GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, c.GRP_PREFIXO_ID_PRODUTO, c.GRP_COLUNA_CAIXA, c.GRP_COLUNA_CHAPA, c.GRP_MULLEN, c.GRP_TENDENCIA_TOLERANCIA_PEDIDO, c.GRP_PERCENTUAL_PERDA_MEDIA, c.GRP_FILTRA_SEQ_TRANS, c.GRP_IMG_CAIXA);
                 var domainResult = GrupoProdutoAbstratoDomainBehavior.Apply(grupoprodutoabstrato, context);
                 if (!domainResult.IsValid)
                     return ValidationError(domainResult.Errors, null);

                 try
                 {
                     _repository.Update(grupoprodutoabstrato);
                     return Success("OK", grupoprodutoabstrato);
                 }
                 catch (Exception e)
                 {
                    return Error(e, grupoprodutoabstrato);
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