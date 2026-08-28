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
    public static partial class TipoDispositivoDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITipoDispositivoEntity tipodispositivo, DomainOperationContext context)
        {
            PrepareCustom(tipodispositivo, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(tipodispositivo, context, result.Errors);
            ValidateCustom(tipodispositivo, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(tipodispositivo, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITipoDispositivoEntity tipodispositivo, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => tipodispositivo.isValidInsert(),
                DomainOperation.Alteracao => tipodispositivo.isValidUpdate(),
                DomainOperation.Remocao => tipodispositivo.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(tipodispositivo.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITipoDispositivoEntity tipodispositivo, DomainOperationContext context);
        static partial void ValidateCustom(ITipoDispositivoEntity tipodispositivo, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITipoDispositivoEntity tipodispositivo, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration