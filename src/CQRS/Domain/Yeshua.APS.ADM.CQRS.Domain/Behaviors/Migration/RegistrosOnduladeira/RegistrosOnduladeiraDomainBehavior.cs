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
    public static partial class RegistrosOnduladeiraDomainBehavior
    {
        public static DomainBehaviorResult Apply(IRegistrosOnduladeiraEntity registrosonduladeira, DomainOperationContext context)
        {
            PrepareCustom(registrosonduladeira, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(registrosonduladeira, context, result.Errors);
            ValidateCustom(registrosonduladeira, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(registrosonduladeira, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IRegistrosOnduladeiraEntity registrosonduladeira, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => registrosonduladeira.isValidInsert(),
                DomainOperation.Alteracao => registrosonduladeira.isValidUpdate(),
                DomainOperation.Remocao => registrosonduladeira.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(registrosonduladeira.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IRegistrosOnduladeiraEntity registrosonduladeira, DomainOperationContext context);
        static partial void ValidateCustom(IRegistrosOnduladeiraEntity registrosonduladeira, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IRegistrosOnduladeiraEntity registrosonduladeira, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration