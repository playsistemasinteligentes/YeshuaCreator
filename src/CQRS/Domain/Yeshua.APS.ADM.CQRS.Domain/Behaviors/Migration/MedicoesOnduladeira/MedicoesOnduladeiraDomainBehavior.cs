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
    public static partial class MedicoesOnduladeiraDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMedicoesOnduladeiraEntity medicoesonduladeira, DomainOperationContext context)
        {
            PrepareCustom(medicoesonduladeira, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(medicoesonduladeira, context, result.Errors);
            ValidateCustom(medicoesonduladeira, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(medicoesonduladeira, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMedicoesOnduladeiraEntity medicoesonduladeira, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => medicoesonduladeira.isValidInsert(),
                DomainOperation.Alteracao => medicoesonduladeira.isValidUpdate(),
                DomainOperation.Remocao => medicoesonduladeira.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(medicoesonduladeira.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMedicoesOnduladeiraEntity medicoesonduladeira, DomainOperationContext context);
        static partial void ValidateCustom(IMedicoesOnduladeiraEntity medicoesonduladeira, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMedicoesOnduladeiraEntity medicoesonduladeira, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration