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
    public static partial class ReciboEntradaDomainBehavior
    {
        public static DomainBehaviorResult Apply(IReciboEntradaEntity reciboentrada, DomainOperationContext context)
        {
            PrepareCustom(reciboentrada, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(reciboentrada, context, result.Errors);
            ValidateCustom(reciboentrada, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(reciboentrada, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IReciboEntradaEntity reciboentrada, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => reciboentrada.isValidInsert(),
                DomainOperation.Alteracao => reciboentrada.isValidUpdate(),
                DomainOperation.Remocao => reciboentrada.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(reciboentrada.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IReciboEntradaEntity reciboentrada, DomainOperationContext context);
        static partial void ValidateCustom(IReciboEntradaEntity reciboentrada, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IReciboEntradaEntity reciboentrada, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration