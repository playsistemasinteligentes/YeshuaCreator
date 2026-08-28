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
    public static partial class UnidadeDomainBehavior
    {
        public static DomainBehaviorResult Apply(IUnidadeEntity unidade, DomainOperationContext context)
        {
            PrepareCustom(unidade, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(unidade, context, result.Errors);
            ValidateCustom(unidade, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(unidade, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IUnidadeEntity unidade, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => unidade.isValidInsert(),
                DomainOperation.Alteracao => unidade.isValidUpdate(),
                DomainOperation.Remocao => unidade.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(unidade.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IUnidadeEntity unidade, DomainOperationContext context);
        static partial void ValidateCustom(IUnidadeEntity unidade, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IUnidadeEntity unidade, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration