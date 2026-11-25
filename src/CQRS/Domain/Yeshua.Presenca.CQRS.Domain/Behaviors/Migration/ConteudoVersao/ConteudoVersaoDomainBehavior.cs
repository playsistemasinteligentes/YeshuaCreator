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
    public static partial class ConteudoVersaoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IConteudoVersaoEntity conteudoversao, DomainOperationContext context)
        {
            PrepareCustom(conteudoversao, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(conteudoversao, context, result.Errors);
            ValidateCustom(conteudoversao, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(conteudoversao, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IConteudoVersaoEntity conteudoversao, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => conteudoversao.isValidInsert(),
                DomainOperation.Alteracao => conteudoversao.isValidUpdate(),
                DomainOperation.Remocao => conteudoversao.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(conteudoversao.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IConteudoVersaoEntity conteudoversao, DomainOperationContext context);
        static partial void ValidateCustom(IConteudoVersaoEntity conteudoversao, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IConteudoVersaoEntity conteudoversao, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration