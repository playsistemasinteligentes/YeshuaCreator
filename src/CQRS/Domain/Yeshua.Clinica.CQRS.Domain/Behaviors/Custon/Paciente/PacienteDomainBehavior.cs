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
    public static partial class PacienteDomainBehavior
    {
        static partial void PrepareCustom(IPacienteEntity entity, DomainOperationContext context)
        {
            if (!ValidacaoCadastro.Escrita(context)) return;
            entity.Nome = entity.Nome?.Trim() ?? "";
            entity.Telefone = entity.Telefone?.Trim() ?? "";
        }
        static partial void ValidateCustom(IPacienteEntity entity, DomainOperationContext context, List<string> errors)
        {
            if (!ValidacaoCadastro.Escrita(context)) return;
            ValidacaoCadastro.Texto(entity.Nome, "Nome do paciente", 150, errors);
            ValidacaoCadastro.Telefone(entity.Telefone, "Telefone de contato", 20, errors);
            if (entity.DataNascimento?.Date > DateTime.Today) errors.Add("Data de nascimento não pode ser futura.");
            ValidacaoCadastro.Opcao(entity.Genero, 1, 3, "Gênero", errors);
            ValidacaoCadastro.Texto(entity.Escolaridade, "Escolaridade", 60, errors);
            ValidacaoCadastro.Texto(entity.Profissao, "Profissão", 60, errors);
            ValidacaoCadastro.Texto(entity.Endereco, "Endereço", 250, errors);
            ValidacaoCadastro.Texto(entity.NomeResponsavel, "Nome do responsável", 250, errors);
            ValidacaoCadastro.Telefone(entity.TelefoneResponsavel, "Telefone do responsável", 15, errors);
            ValidacaoCadastro.Texto(entity.Observacao, "Observações", 2000, errors);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeDomainBehaviorMigration
