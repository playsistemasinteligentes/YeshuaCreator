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
    public static partial class ContratacaoUsoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IContratacaoUsoEntity contratacaouso, DomainOperationContext context)
        {
            PrepareCustom(contratacaouso, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(contratacaouso, context, result.Errors);
            ValidateCustom(contratacaouso, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(contratacaouso, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IContratacaoUsoEntity contratacaouso, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => contratacaouso.isValidInsert(),
                DomainOperation.Alteracao => contratacaouso.isValidUpdate(),
                DomainOperation.Remocao => contratacaouso.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(contratacaouso.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IContratacaoUsoEntity contratacaouso, DomainOperationContext context);
        static partial void ValidateCustom(IContratacaoUsoEntity contratacaouso, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IContratacaoUsoEntity contratacaouso, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration