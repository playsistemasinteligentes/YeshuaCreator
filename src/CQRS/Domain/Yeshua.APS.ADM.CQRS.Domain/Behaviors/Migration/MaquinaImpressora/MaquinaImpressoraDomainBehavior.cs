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
    public static partial class MaquinaImpressoraDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMaquinaImpressoraEntity maquinaimpressora, DomainOperationContext context)
        {
            PrepareCustom(maquinaimpressora, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(maquinaimpressora, context, result.Errors);
            ValidateCustom(maquinaimpressora, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(maquinaimpressora, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMaquinaImpressoraEntity maquinaimpressora, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => maquinaimpressora.isValidInsert(),
                DomainOperation.Alteracao => maquinaimpressora.isValidUpdate(),
                DomainOperation.Remocao => maquinaimpressora.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(maquinaimpressora.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMaquinaImpressoraEntity maquinaimpressora, DomainOperationContext context);
        static partial void ValidateCustom(IMaquinaImpressoraEntity maquinaimpressora, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMaquinaImpressoraEntity maquinaimpressora, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration