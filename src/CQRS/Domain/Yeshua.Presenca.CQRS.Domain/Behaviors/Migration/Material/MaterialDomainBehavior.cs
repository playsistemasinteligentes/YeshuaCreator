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
    public static partial class MaterialDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMaterialEntity material, DomainOperationContext context)
        {
            PrepareCustom(material, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(material, context, result.Errors);
            ValidateCustom(material, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(material, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMaterialEntity material, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => material.isValidInsert(),
                DomainOperation.Alteracao => material.isValidUpdate(),
                DomainOperation.Remocao => material.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(material.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMaterialEntity material, DomainOperationContext context);
        static partial void ValidateCustom(IMaterialEntity material, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMaterialEntity material, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration