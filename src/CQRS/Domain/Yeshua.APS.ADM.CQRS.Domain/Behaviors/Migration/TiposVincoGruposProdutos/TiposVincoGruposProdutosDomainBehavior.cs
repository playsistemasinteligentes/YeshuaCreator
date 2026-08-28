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
    public static partial class TiposVincoGruposProdutosDomainBehavior
    {
        public static DomainBehaviorResult Apply(ITiposVincoGruposProdutosEntity tiposvincogruposprodutos, DomainOperationContext context)
        {
            PrepareCustom(tiposvincogruposprodutos, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(tiposvincogruposprodutos, context, result.Errors);
            ValidateCustom(tiposvincogruposprodutos, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(tiposvincogruposprodutos, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(ITiposVincoGruposProdutosEntity tiposvincogruposprodutos, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => tiposvincogruposprodutos.isValidInsert(),
                DomainOperation.Alteracao => tiposvincogruposprodutos.isValidUpdate(),
                DomainOperation.Remocao => tiposvincogruposprodutos.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(tiposvincogruposprodutos.getErroMensagens());
            }
        }

        static partial void PrepareCustom(ITiposVincoGruposProdutosEntity tiposvincogruposprodutos, DomainOperationContext context);
        static partial void ValidateCustom(ITiposVincoGruposProdutosEntity tiposvincogruposprodutos, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(ITiposVincoGruposProdutosEntity tiposvincogruposprodutos, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration