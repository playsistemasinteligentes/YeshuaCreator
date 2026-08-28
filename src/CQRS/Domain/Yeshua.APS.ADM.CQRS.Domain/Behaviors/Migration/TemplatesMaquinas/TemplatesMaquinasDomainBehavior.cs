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
    public static partial class TemplatesMaquinasDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITemplatesMaquinasEntity templatesmaquinas, DomainOperationContext context)
        {
            PrepareCustom(templatesmaquinas, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(templatesmaquinas, context, result.Errors);
            ValidateCustom(templatesmaquinas, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(templatesmaquinas, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITemplatesMaquinasEntity templatesmaquinas, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => templatesmaquinas.isValidInsert(),
                DomainOperation.Alteracao => templatesmaquinas.isValidUpdate(),
                DomainOperation.Remocao => templatesmaquinas.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(templatesmaquinas.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITemplatesMaquinasEntity templatesmaquinas, DomainOperationContext context);
        static partial void ValidateCustom(ITemplatesMaquinasEntity templatesmaquinas, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITemplatesMaquinasEntity templatesmaquinas, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration