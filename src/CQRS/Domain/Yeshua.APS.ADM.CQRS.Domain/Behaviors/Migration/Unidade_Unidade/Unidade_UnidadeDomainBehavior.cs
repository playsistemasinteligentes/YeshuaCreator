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
    public static partial class Unidade_UnidadeDomainBehavior
    {
        public static DomainBehaviorResult Apply(IUnidade_UnidadeEntity unidade_unidade, DomainOperationContext context)
        {
            PrepareCustom(unidade_unidade, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(unidade_unidade, context, result.Errors);
            ValidateCustom(unidade_unidade, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(unidade_unidade, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IUnidade_UnidadeEntity unidade_unidade, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => unidade_unidade.isValidInsert(),
                DomainOperation.Alteracao => unidade_unidade.isValidUpdate(),
                DomainOperation.Remocao => unidade_unidade.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(unidade_unidade.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IUnidade_UnidadeEntity unidade_unidade, DomainOperationContext context);
        static partial void ValidateCustom(IUnidade_UnidadeEntity unidade_unidade, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IUnidade_UnidadeEntity unidade_unidade, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration