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
    public static partial class T_NegocioDomainBehavior
    {
        public static DomainBehaviorResult Apply(IT_NegocioEntity t_negocio, DomainOperationContext context)
        {
            PrepareCustom(t_negocio, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(t_negocio, context, result.Errors);
            ValidateCustom(t_negocio, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(t_negocio, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IT_NegocioEntity t_negocio, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => t_negocio.isValidInsert(),
                DomainOperation.Alteracao => t_negocio.isValidUpdate(),
                DomainOperation.Remocao => t_negocio.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(t_negocio.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IT_NegocioEntity t_negocio, DomainOperationContext context);
        static partial void ValidateCustom(IT_NegocioEntity t_negocio, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IT_NegocioEntity t_negocio, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration