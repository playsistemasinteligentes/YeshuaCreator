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
    public static partial class TipoDispositivoMaquinaDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITipoDispositivoMaquinaEntity tipodispositivomaquina, DomainOperationContext context)
        {
            PrepareCustom(tipodispositivomaquina, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(tipodispositivomaquina, context, result.Errors);
            ValidateCustom(tipodispositivomaquina, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(tipodispositivomaquina, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITipoDispositivoMaquinaEntity tipodispositivomaquina, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => tipodispositivomaquina.isValidInsert(),
                DomainOperation.Alteracao => tipodispositivomaquina.isValidUpdate(),
                DomainOperation.Remocao => tipodispositivomaquina.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(tipodispositivomaquina.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITipoDispositivoMaquinaEntity tipodispositivomaquina, DomainOperationContext context);
        static partial void ValidateCustom(ITipoDispositivoMaquinaEntity tipodispositivomaquina, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITipoDispositivoMaquinaEntity tipodispositivomaquina, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration