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
    public static partial class NFeProdutoSnapshotDomainBehavior
    {
        public static DomainBehaviorResult Apply(INFeProdutoSnapshotEntity nfeprodutosnapshot, DomainOperationContext context)
        {
            PrepareCustom(nfeprodutosnapshot, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(nfeprodutosnapshot, context, result.Errors);
            ValidateCustom(nfeprodutosnapshot, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(nfeprodutosnapshot, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(INFeProdutoSnapshotEntity nfeprodutosnapshot, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => nfeprodutosnapshot.isValidInsert(),
                DomainOperation.Alteracao => nfeprodutosnapshot.isValidUpdate(),
                DomainOperation.Remocao => nfeprodutosnapshot.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(nfeprodutosnapshot.getErroMensagens());
            }
        }

        static partial void PrepareCustom(INFeProdutoSnapshotEntity nfeprodutosnapshot, DomainOperationContext context);
        static partial void ValidateCustom(INFeProdutoSnapshotEntity nfeprodutosnapshot, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(INFeProdutoSnapshotEntity nfeprodutosnapshot, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration