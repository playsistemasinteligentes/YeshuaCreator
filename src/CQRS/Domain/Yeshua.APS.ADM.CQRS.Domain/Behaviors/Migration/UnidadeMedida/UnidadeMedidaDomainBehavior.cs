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
    public static partial class UnidadeMedidaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IUnidadeMedidaEntity unidademedida, DomainOperationContext context)
        {
            PrepareCustom(unidademedida, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(unidademedida, context, result.Errors);
            ValidateCustom(unidademedida, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(unidademedida, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IUnidadeMedidaEntity unidademedida, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => unidademedida.isValidInsert(),
                DomainOperation.Alteracao => unidademedida.isValidUpdate(),
                DomainOperation.Remocao => unidademedida.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(unidademedida.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IUnidadeMedidaEntity unidademedida, DomainOperationContext context);
        static partial void ValidateCustom(IUnidadeMedidaEntity unidademedida, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IUnidadeMedidaEntity unidademedida, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration