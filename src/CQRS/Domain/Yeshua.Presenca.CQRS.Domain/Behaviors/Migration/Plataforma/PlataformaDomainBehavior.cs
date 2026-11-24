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
    public static partial class PlataformaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IPlataformaEntity plataforma, DomainOperationContext context)
        {
            PrepareCustom(plataforma, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(plataforma, context, result.Errors);
            ValidateCustom(plataforma, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(plataforma, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IPlataformaEntity plataforma, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => plataforma.isValidInsert(),
                DomainOperation.Alteracao => plataforma.isValidUpdate(),
                DomainOperation.Remocao => plataforma.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(plataforma.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IPlataformaEntity plataforma, DomainOperationContext context);
        static partial void ValidateCustom(IPlataformaEntity plataforma, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IPlataformaEntity plataforma, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration