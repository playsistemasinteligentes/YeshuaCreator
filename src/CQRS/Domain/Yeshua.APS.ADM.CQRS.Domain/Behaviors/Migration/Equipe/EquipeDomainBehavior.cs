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
    public static partial class EquipeDomainBehavior
    {
        public static DomainBehaviorResult Apply(IEquipeEntity equipe, DomainOperationContext context)
        {
            PrepareCustom(equipe, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(equipe, context, result.Errors);
            ValidateCustom(equipe, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(equipe, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IEquipeEntity equipe, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => equipe.isValidInsert(),
                DomainOperation.Alteracao => equipe.isValidUpdate(),
                DomainOperation.Remocao => equipe.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(equipe.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IEquipeEntity equipe, DomainOperationContext context);
        static partial void ValidateCustom(IEquipeEntity equipe, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IEquipeEntity equipe, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration