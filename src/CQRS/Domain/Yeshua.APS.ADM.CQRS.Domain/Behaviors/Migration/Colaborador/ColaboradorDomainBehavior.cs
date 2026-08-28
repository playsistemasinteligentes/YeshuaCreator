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
    public static partial class ColaboradorDomainBehavior
    {
        public static DomainBehaviorResult Apply(IColaboradorEntity colaborador, DomainOperationContext context)
        {
            PrepareCustom(colaborador, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(colaborador, context, result.Errors);
            ValidateCustom(colaborador, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(colaborador, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IColaboradorEntity colaborador, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => colaborador.isValidInsert(),
                DomainOperation.Alteracao => colaborador.isValidUpdate(),
                DomainOperation.Remocao => colaborador.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(colaborador.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IColaboradorEntity colaborador, DomainOperationContext context);
        static partial void ValidateCustom(IColaboradorEntity colaborador, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IColaboradorEntity colaborador, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration