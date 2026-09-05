// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
// </yeshua>

using Dominio.Entitys;
using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Behaviors
{
    public static partial class MDFeSolicitacaoFiscalDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMDFeSolicitacaoFiscalEntity mdfesolicitacaofiscal, DomainOperationContext context)
        {
            PrepareCustom(mdfesolicitacaofiscal, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(mdfesolicitacaofiscal, context, result.Errors);
            ValidateCustom(mdfesolicitacaofiscal, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(mdfesolicitacaofiscal, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMDFeSolicitacaoFiscalEntity mdfesolicitacaofiscal, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => mdfesolicitacaofiscal.isValidInsert(),
                DomainOperation.Alteracao => mdfesolicitacaofiscal.isValidUpdate(),
                DomainOperation.Remocao => mdfesolicitacaofiscal.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(mdfesolicitacaofiscal.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMDFeSolicitacaoFiscalEntity mdfesolicitacaofiscal, DomainOperationContext context);
        static partial void ValidateCustom(IMDFeSolicitacaoFiscalEntity mdfesolicitacaofiscal, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMDFeSolicitacaoFiscalEntity mdfesolicitacaofiscal, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration