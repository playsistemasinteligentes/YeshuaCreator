// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
// </yeshua>

using Dominio.Entitys;
using Dominio.Patterns.Domain;
using System.Collections.Generic;

namespace Dominio.Behaviors
{
    public static partial class ClinicaDomainBehavior
    {
        static partial void PrepareCustom(IClinicaEntity entity, DomainOperationContext context)
        {
            if (!ValidacaoCadastro.Escrita(context)) return;
            entity.Nome = entity.Nome?.Trim() ?? "";
            entity.Endereco = entity.Endereco?.Trim() ?? "";
            entity.Telefone = entity.Telefone?.Trim() ?? "";
        }
        static partial void ValidateCustom(IClinicaEntity entity, DomainOperationContext context, List<string> errors)
        {
            if (!ValidacaoCadastro.Escrita(context)) return;
            ValidacaoCadastro.Texto(entity.Nome, "Nome da clínica", 150, errors);
            ValidacaoCadastro.Texto(entity.Endereco, "Endereço da clínica", 250, errors);
            ValidacaoCadastro.Telefone(entity.Telefone, "Telefone da clínica", 20, errors);
            ValidacaoCadastro.Opcao(entity.TipoEstrutura, 1, 2, "Estrutura da clínica", errors);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
