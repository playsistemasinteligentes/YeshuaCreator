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
    public static partial class RelatoriosDomainBehavior
    {
        public static DomainBehaviorResult Apply(IRelatoriosEntity relatorios, DomainOperationContext context)
        {
            PrepareCustom(relatorios, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(relatorios, context, result.Errors);
            ValidateCustom(relatorios, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(relatorios, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IRelatoriosEntity relatorios, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => relatorios.isValidInsert(),
                DomainOperation.Alteracao => relatorios.isValidUpdate(),
                DomainOperation.Remocao => relatorios.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(relatorios.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IRelatoriosEntity relatorios, DomainOperationContext context);
        static partial void ValidateCustom(IRelatoriosEntity relatorios, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IRelatoriosEntity relatorios, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration