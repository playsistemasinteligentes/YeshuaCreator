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
    public static partial class PlanoAmostralTesteDomainBehavior
    {
        public static DomainBehaviorResult Apply(IPlanoAmostralTesteEntity planoamostralteste, DomainOperationContext context)
        {
            PrepareCustom(planoamostralteste, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(planoamostralteste, context, result.Errors);
            ValidateCustom(planoamostralteste, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(planoamostralteste, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IPlanoAmostralTesteEntity planoamostralteste, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => planoamostralteste.isValidInsert(),
                DomainOperation.Alteracao => planoamostralteste.isValidUpdate(),
                DomainOperation.Remocao => planoamostralteste.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(planoamostralteste.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IPlanoAmostralTesteEntity planoamostralteste, DomainOperationContext context);
        static partial void ValidateCustom(IPlanoAmostralTesteEntity planoamostralteste, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IPlanoAmostralTesteEntity planoamostralteste, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration