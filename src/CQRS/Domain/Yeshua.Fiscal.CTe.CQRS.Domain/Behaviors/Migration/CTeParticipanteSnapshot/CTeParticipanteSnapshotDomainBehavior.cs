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
    public static partial class CTeParticipanteSnapshotDomainBehavior
    {
        public static DomainBehaviorResult Apply(ICTeParticipanteSnapshotEntity cteparticipantesnapshot, DomainOperationContext context)
        {
            PrepareCustom(cteparticipantesnapshot, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(cteparticipantesnapshot, context, result.Errors);
            ValidateCustom(cteparticipantesnapshot, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(cteparticipantesnapshot, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ICTeParticipanteSnapshotEntity cteparticipantesnapshot, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => cteparticipantesnapshot.isValidInsert(),
                DomainOperation.Alteracao => cteparticipantesnapshot.isValidUpdate(),
                DomainOperation.Remocao => cteparticipantesnapshot.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(cteparticipantesnapshot.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ICTeParticipanteSnapshotEntity cteparticipantesnapshot, DomainOperationContext context);
        static partial void ValidateCustom(ICTeParticipanteSnapshotEntity cteparticipantesnapshot, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ICTeParticipanteSnapshotEntity cteparticipantesnapshot, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration