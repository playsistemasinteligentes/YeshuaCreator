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
    public static partial class ObjetoControlavelDomainBehavior
    {
        public static DomainBehaviorResult Apply(IObjetoControlavelEntity objetocontrolavel, DomainOperationContext context)
        {
            PrepareCustom(objetocontrolavel, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(objetocontrolavel, context, result.Errors);
            ValidateCustom(objetocontrolavel, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(objetocontrolavel, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IObjetoControlavelEntity objetocontrolavel, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => objetocontrolavel.isValidInsert(),
                DomainOperation.Alteracao => objetocontrolavel.isValidUpdate(),
                DomainOperation.Remocao => objetocontrolavel.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(objetocontrolavel.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IObjetoControlavelEntity objetocontrolavel, DomainOperationContext context);
        static partial void ValidateCustom(IObjetoControlavelEntity objetocontrolavel, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IObjetoControlavelEntity objetocontrolavel, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration