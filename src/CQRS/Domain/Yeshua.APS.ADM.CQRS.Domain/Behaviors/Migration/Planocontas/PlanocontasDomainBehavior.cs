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
    public static partial class PlanocontasDomainBehavior
    {
        public static DomainBehaviorResult Apply(IPlanocontasEntity planocontas, DomainOperationContext context)
        {
            PrepareCustom(planocontas, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(planocontas, context, result.Errors);
            ValidateCustom(planocontas, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(planocontas, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IPlanocontasEntity planocontas, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => planocontas.isValidInsert(),
                DomainOperation.Alteracao => planocontas.isValidUpdate(),
                DomainOperation.Remocao => planocontas.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(planocontas.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IPlanocontasEntity planocontas, DomainOperationContext context);
        static partial void ValidateCustom(IPlanocontasEntity planocontas, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IPlanocontasEntity planocontas, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration