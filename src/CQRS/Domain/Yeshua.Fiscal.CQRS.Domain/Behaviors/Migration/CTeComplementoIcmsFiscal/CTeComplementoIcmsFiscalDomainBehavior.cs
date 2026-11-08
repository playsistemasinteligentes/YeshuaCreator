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
    public static partial class CTeComplementoIcmsFiscalDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICTeComplementoIcmsFiscalEntity ctecomplementoicmsfiscal, DomainOperationContext context)
        {
            PrepareCustom(ctecomplementoicmsfiscal, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(ctecomplementoicmsfiscal, context, result.Errors);
            ValidateCustom(ctecomplementoicmsfiscal, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(ctecomplementoicmsfiscal, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICTeComplementoIcmsFiscalEntity ctecomplementoicmsfiscal, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => ctecomplementoicmsfiscal.isValidInsert(),
                DomainOperation.Alteracao => ctecomplementoicmsfiscal.isValidUpdate(),
                DomainOperation.Remocao => ctecomplementoicmsfiscal.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(ctecomplementoicmsfiscal.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICTeComplementoIcmsFiscalEntity ctecomplementoicmsfiscal, DomainOperationContext context);
        static partial void ValidateCustom(ICTeComplementoIcmsFiscalEntity ctecomplementoicmsfiscal, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICTeComplementoIcmsFiscalEntity ctecomplementoicmsfiscal, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration