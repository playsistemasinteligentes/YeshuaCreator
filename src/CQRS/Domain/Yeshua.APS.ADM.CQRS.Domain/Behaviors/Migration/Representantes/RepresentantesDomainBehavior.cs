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
    public static partial class RepresentantesDomainBehavior
    {
        public static DomainBehaviorResult Apply(IRepresentantesEntity representantes, DomainOperationContext context)
        {
            PrepareCustom(representantes, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(representantes, context, result.Errors);
            ValidateCustom(representantes, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(representantes, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IRepresentantesEntity representantes, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => representantes.isValidInsert(),
                DomainOperation.Alteracao => representantes.isValidUpdate(),
                DomainOperation.Remocao => representantes.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(representantes.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IRepresentantesEntity representantes, DomainOperationContext context);
        static partial void ValidateCustom(IRepresentantesEntity representantes, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IRepresentantesEntity representantes, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration