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
    public static partial class VariavelDomainBehavior
    {
        public static DomainBehaviorResult Apply(IVariavelEntity variavel, DomainOperationContext context)
        {
            PrepareCustom(variavel, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(variavel, context, result.Errors);
            ValidateCustom(variavel, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(variavel, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IVariavelEntity variavel, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => variavel.isValidInsert(),
                DomainOperation.Alteracao => variavel.isValidUpdate(),
                DomainOperation.Remocao => variavel.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(variavel.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IVariavelEntity variavel, DomainOperationContext context);
        static partial void ValidateCustom(IVariavelEntity variavel, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IVariavelEntity variavel, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration