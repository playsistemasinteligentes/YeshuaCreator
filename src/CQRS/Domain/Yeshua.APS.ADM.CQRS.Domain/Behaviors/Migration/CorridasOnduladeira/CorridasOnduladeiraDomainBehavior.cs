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
    public static partial class CorridasOnduladeiraDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICorridasOnduladeiraEntity corridasonduladeira, DomainOperationContext context)
        {
            PrepareCustom(corridasonduladeira, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(corridasonduladeira, context, result.Errors);
            ValidateCustom(corridasonduladeira, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(corridasonduladeira, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICorridasOnduladeiraEntity corridasonduladeira, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => corridasonduladeira.isValidInsert(),
                DomainOperation.Alteracao => corridasonduladeira.isValidUpdate(),
                DomainOperation.Remocao => corridasonduladeira.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(corridasonduladeira.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICorridasOnduladeiraEntity corridasonduladeira, DomainOperationContext context);
        static partial void ValidateCustom(ICorridasOnduladeiraEntity corridasonduladeira, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICorridasOnduladeiraEntity corridasonduladeira, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration