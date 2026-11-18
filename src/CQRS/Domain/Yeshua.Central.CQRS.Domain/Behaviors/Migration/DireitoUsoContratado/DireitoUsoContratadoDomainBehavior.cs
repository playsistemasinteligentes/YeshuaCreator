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
    public static partial class DireitoUsoContratadoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IDireitoUsoContratadoEntity direitousocontratado, DomainOperationContext context)
        {
            PrepareCustom(direitousocontratado, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(direitousocontratado, context, result.Errors);
            ValidateCustom(direitousocontratado, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(direitousocontratado, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IDireitoUsoContratadoEntity direitousocontratado, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => direitousocontratado.isValidInsert(),
                DomainOperation.Alteracao => direitousocontratado.isValidUpdate(),
                DomainOperation.Remocao => direitousocontratado.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(direitousocontratado.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IDireitoUsoContratadoEntity direitousocontratado, DomainOperationContext context);
        static partial void ValidateCustom(IDireitoUsoContratadoEntity direitousocontratado, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IDireitoUsoContratadoEntity direitousocontratado, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration