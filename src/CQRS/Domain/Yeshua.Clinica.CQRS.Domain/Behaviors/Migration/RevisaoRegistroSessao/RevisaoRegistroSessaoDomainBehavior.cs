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
    public static partial class RevisaoRegistroSessaoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IRevisaoRegistroSessaoEntity revisaoregistrosessao, DomainOperationContext context)
        {
            PrepareCustom(revisaoregistrosessao, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(revisaoregistrosessao, context, result.Errors);
            ValidateCustom(revisaoregistrosessao, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(revisaoregistrosessao, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IRevisaoRegistroSessaoEntity revisaoregistrosessao, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => revisaoregistrosessao.isValidInsert(),
                DomainOperation.Alteracao => revisaoregistrosessao.isValidUpdate(),
                DomainOperation.Remocao => revisaoregistrosessao.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(revisaoregistrosessao.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IRevisaoRegistroSessaoEntity revisaoregistrosessao, DomainOperationContext context);
        static partial void ValidateCustom(IRevisaoRegistroSessaoEntity revisaoregistrosessao, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IRevisaoRegistroSessaoEntity revisaoregistrosessao, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration