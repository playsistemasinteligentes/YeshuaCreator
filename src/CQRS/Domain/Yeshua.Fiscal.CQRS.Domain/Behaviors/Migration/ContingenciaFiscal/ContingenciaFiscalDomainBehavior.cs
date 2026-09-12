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
    public static partial class ContingenciaFiscalDomainBehavior
    {
        public static DomainBehaviorResult Apply(IContingenciaFiscalEntity contingenciafiscal, DomainOperationContext context)
        {
            PrepareCustom(contingenciafiscal, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(contingenciafiscal, context, result.Errors);
            ValidateCustom(contingenciafiscal, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(contingenciafiscal, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IContingenciaFiscalEntity contingenciafiscal, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => contingenciafiscal.isValidInsert(),
                DomainOperation.Alteracao => contingenciafiscal.isValidUpdate(),
                DomainOperation.Remocao => contingenciafiscal.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(contingenciafiscal.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IContingenciaFiscalEntity contingenciafiscal, DomainOperationContext context);
        static partial void ValidateCustom(IContingenciaFiscalEntity contingenciafiscal, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IContingenciaFiscalEntity contingenciafiscal, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration