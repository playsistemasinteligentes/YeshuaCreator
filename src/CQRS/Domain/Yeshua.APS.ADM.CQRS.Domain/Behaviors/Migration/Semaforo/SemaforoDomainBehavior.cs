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
    public static partial class SemaforoDomainBehavior
    {
        public static DomainBehaviorResult Apply(ISemaforoEntity semaforo, DomainOperationContext context)
        {
            PrepareCustom(semaforo, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(semaforo, context, result.Errors);
            ValidateCustom(semaforo, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(semaforo, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ISemaforoEntity semaforo, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => semaforo.isValidInsert(),
                DomainOperation.Alteracao => semaforo.isValidUpdate(),
                DomainOperation.Remocao => semaforo.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(semaforo.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ISemaforoEntity semaforo, DomainOperationContext context);
        static partial void ValidateCustom(ISemaforoEntity semaforo, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ISemaforoEntity semaforo, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration