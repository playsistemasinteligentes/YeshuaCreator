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
    public static partial class MunicipioDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMunicipioEntity municipio, DomainOperationContext context)
        {
            PrepareCustom(municipio, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(municipio, context, result.Errors);
            ValidateCustom(municipio, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(municipio, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMunicipioEntity municipio, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => municipio.isValidInsert(),
                DomainOperation.Alteracao => municipio.isValidUpdate(),
                DomainOperation.Remocao => municipio.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(municipio.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMunicipioEntity municipio, DomainOperationContext context);
        static partial void ValidateCustom(IMunicipioEntity municipio, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMunicipioEntity municipio, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration