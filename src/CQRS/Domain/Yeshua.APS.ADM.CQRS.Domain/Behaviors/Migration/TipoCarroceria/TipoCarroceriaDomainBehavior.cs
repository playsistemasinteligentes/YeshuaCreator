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
    public static partial class TipoCarroceriaDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITipoCarroceriaEntity tipocarroceria, DomainOperationContext context)
        {
            PrepareCustom(tipocarroceria, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(tipocarroceria, context, result.Errors);
            ValidateCustom(tipocarroceria, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(tipocarroceria, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITipoCarroceriaEntity tipocarroceria, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => tipocarroceria.isValidInsert(),
                DomainOperation.Alteracao => tipocarroceria.isValidUpdate(),
                DomainOperation.Remocao => tipocarroceria.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(tipocarroceria.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITipoCarroceriaEntity tipocarroceria, DomainOperationContext context);
        static partial void ValidateCustom(ITipoCarroceriaEntity tipocarroceria, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITipoCarroceriaEntity tipocarroceria, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration