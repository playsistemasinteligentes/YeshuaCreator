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
    public static partial class MensagemDomainBehavior
    {
        public static DomainBehaviorResult Apply(IMensagemEntity mensagem, DomainOperationContext context)
        {
            PrepareCustom(mensagem, context);

            var result = new DomainBehaviorResult();
            ValidateGenerated(mensagem, context, result.Errors);
            ValidateCustom(mensagem, context, result.Errors);

            if (result.IsValid)
            {
                CollectEventsCustom(mensagem, context, result.Events);
            }

            return result;
        }

        private static void ValidateGenerated(IMensagemEntity mensagem, DomainOperationContext context, List<string> errors)
        {
            var isValid = context.Operation switch
            {
                DomainOperation.Registro => mensagem.isValidInsert(),
                DomainOperation.Alteracao => mensagem.isValidUpdate(),
                DomainOperation.Remocao => mensagem.isValidDelete(),
                _ => true
            };

            if (!isValid)
            {
                errors.AddRange(mensagem.getErroMensagens());
            }
        }

        static partial void PrepareCustom(IMensagemEntity mensagem, DomainOperationContext context);
        static partial void ValidateCustom(IMensagemEntity mensagem, DomainOperationContext context, List<string> errors);
        static partial void CollectEventsCustom(IMensagemEntity mensagem, DomainOperationContext context, List<IDomainEvent> events);
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration