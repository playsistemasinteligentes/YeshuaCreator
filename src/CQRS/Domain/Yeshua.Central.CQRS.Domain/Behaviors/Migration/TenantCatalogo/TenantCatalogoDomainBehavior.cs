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
    public static partial class TenantCatalogoDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITenantCatalogoEntity tenantcatalogo, DomainOperationContext context)
        {
            PrepareCustom(tenantcatalogo, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(tenantcatalogo, context, result.Errors);
            ValidateCustom(tenantcatalogo, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(tenantcatalogo, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITenantCatalogoEntity tenantcatalogo, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => tenantcatalogo.isValidInsert(),
                DomainOperation.Alteracao => tenantcatalogo.isValidUpdate(),
                DomainOperation.Remocao => tenantcatalogo.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(tenantcatalogo.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITenantCatalogoEntity tenantcatalogo, DomainOperationContext context);
        static partial void ValidateCustom(ITenantCatalogoEntity tenantcatalogo, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITenantCatalogoEntity tenantcatalogo, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration