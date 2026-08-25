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
    public static partial class TemplateDeTestesDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITemplateDeTestesEntity templatedetestes, DomainOperationContext context)
        {
            PrepareCustom(templatedetestes, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(templatedetestes, context, result.Errors);
            ValidateCustom(templatedetestes, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(templatedetestes, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITemplateDeTestesEntity templatedetestes, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => templatedetestes.isValidInsert(),
                DomainOperation.Alteracao => templatedetestes.isValidUpdate(),
                DomainOperation.Remocao => templatedetestes.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(templatedetestes.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITemplateDeTestesEntity templatedetestes, DomainOperationContext context);
        static partial void ValidateCustom(ITemplateDeTestesEntity templatedetestes, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITemplateDeTestesEntity templatedetestes, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration