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
    public static partial class FotoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IFotoEntity foto, DomainOperationContext context)
        {
            PrepareCustom(foto, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(foto, context, result.Errors);
            ValidateCustom(foto, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(foto, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IFotoEntity foto, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => foto.isValidInsert(),
                DomainOperation.Alteracao => foto.isValidUpdate(),
                DomainOperation.Remocao => foto.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(foto.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IFotoEntity foto, DomainOperationContext context);
        static partial void ValidateCustom(IFotoEntity foto, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IFotoEntity foto, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration