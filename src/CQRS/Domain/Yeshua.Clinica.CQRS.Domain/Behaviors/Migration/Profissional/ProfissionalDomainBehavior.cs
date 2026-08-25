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
    public static partial class ProfissionalDomainBehavior
    {
        public static DomainBehaviorResult Apply(IProfissionalEntity profissional, DomainOperationContext context)
        {
            PrepareCustom(profissional, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(profissional, context, result.Errors);
            ValidateCustom(profissional, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(profissional, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IProfissionalEntity profissional, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => profissional.isValidInsert(),
                DomainOperation.Alteracao => profissional.isValidUpdate(),
                DomainOperation.Remocao => profissional.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(profissional.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IProfissionalEntity profissional, DomainOperationContext context);
        static partial void ValidateCustom(IProfissionalEntity profissional, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IProfissionalEntity profissional, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration