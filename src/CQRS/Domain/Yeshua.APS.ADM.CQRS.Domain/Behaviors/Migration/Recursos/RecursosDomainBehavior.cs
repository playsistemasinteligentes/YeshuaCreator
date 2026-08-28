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
    public static partial class RecursosDomainBehavior
    {
        public static DomainBehaviorResult Apply(IRecursosEntity recursos, DomainOperationContext context)
        {
            PrepareCustom(recursos, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(recursos, context, result.Errors);
            ValidateCustom(recursos, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(recursos, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IRecursosEntity recursos, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => recursos.isValidInsert(),
                DomainOperation.Alteracao => recursos.isValidUpdate(),
                DomainOperation.Remocao => recursos.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(recursos.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IRecursosEntity recursos, DomainOperationContext context);
        static partial void ValidateCustom(IRecursosEntity recursos, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IRecursosEntity recursos, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration