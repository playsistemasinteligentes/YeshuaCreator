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
    public static partial class TemplateTipoTesteDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITemplateTipoTesteEntity templatetipoteste, DomainOperationContext context)
        {
            PrepareCustom(templatetipoteste, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(templatetipoteste, context, result.Errors);
            ValidateCustom(templatetipoteste, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(templatetipoteste, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITemplateTipoTesteEntity templatetipoteste, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => templatetipoteste.isValidInsert(),
                DomainOperation.Alteracao => templatetipoteste.isValidUpdate(),
                DomainOperation.Remocao => templatetipoteste.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(templatetipoteste.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITemplateTipoTesteEntity templatetipoteste, DomainOperationContext context);
        static partial void ValidateCustom(ITemplateTipoTesteEntity templatetipoteste, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITemplateTipoTesteEntity templatetipoteste, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration