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
    public static partial class MemoriaDeCalculoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMemoriaDeCalculoEntity memoriadecalculo, DomainOperationContext context)
        {
            PrepareCustom(memoriadecalculo, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(memoriadecalculo, context, result.Errors);
            ValidateCustom(memoriadecalculo, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(memoriadecalculo, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMemoriaDeCalculoEntity memoriadecalculo, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => memoriadecalculo.isValidInsert(),
                DomainOperation.Alteracao => memoriadecalculo.isValidUpdate(),
                DomainOperation.Remocao => memoriadecalculo.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(memoriadecalculo.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMemoriaDeCalculoEntity memoriadecalculo, DomainOperationContext context);
        static partial void ValidateCustom(IMemoriaDeCalculoEntity memoriadecalculo, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMemoriaDeCalculoEntity memoriadecalculo, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration