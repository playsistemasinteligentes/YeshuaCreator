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
    public static partial class ConteudoDomainBehavior
    {
        public static DomainBehaviorResult Apply(IConteudoEntity conteudo, DomainOperationContext context)
        {
            PrepareCustom(conteudo, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(conteudo, context, result.Errors);
            ValidateCustom(conteudo, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(conteudo, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IConteudoEntity conteudo, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => conteudo.isValidInsert(),
                DomainOperation.Alteracao => conteudo.isValidUpdate(),
                DomainOperation.Remocao => conteudo.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(conteudo.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IConteudoEntity conteudo, DomainOperationContext context);
        static partial void ValidateCustom(IConteudoEntity conteudo, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IConteudoEntity conteudo, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration