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
    public static partial class CTeSolicitacaoFiscalDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICTeSolicitacaoFiscalEntity ctesolicitacaofiscal, DomainOperationContext context)
        {
            PrepareCustom(ctesolicitacaofiscal, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(ctesolicitacaofiscal, context, result.Errors);
            ValidateCustom(ctesolicitacaofiscal, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(ctesolicitacaofiscal, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICTeSolicitacaoFiscalEntity ctesolicitacaofiscal, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => ctesolicitacaofiscal.isValidInsert(),
                DomainOperation.Alteracao => ctesolicitacaofiscal.isValidUpdate(),
                DomainOperation.Remocao => ctesolicitacaofiscal.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(ctesolicitacaofiscal.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICTeSolicitacaoFiscalEntity ctesolicitacaofiscal, DomainOperationContext context);
        static partial void ValidateCustom(ICTeSolicitacaoFiscalEntity ctesolicitacaofiscal, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICTeSolicitacaoFiscalEntity ctesolicitacaofiscal, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration