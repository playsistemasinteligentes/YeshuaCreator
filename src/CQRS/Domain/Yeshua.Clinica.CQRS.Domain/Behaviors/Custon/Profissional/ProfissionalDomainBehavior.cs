using Dominio.Entitys;
using Dominio.Patterns.Domain;
namespace Dominio.Behaviors;
public static partial class ProfissionalDomainBehavior
{
    static partial void PrepareCustom(IProfissionalEntity entity,DomainOperationContext context)
    {
        if (!ValidacaoCadastro.Escrita(context)) return;
        entity.Nome=entity.Nome?.Trim()??"";
        entity.Telefone=entity.Telefone?.Trim()??"";
    }
    static partial void ValidateCustom(IProfissionalEntity entity,DomainOperationContext context,List<string> errors)
    {
        if (ValidacaoCadastro.Escrita(context))
        {
            ValidacaoCadastro.Texto(entity.Nome,"Nome do profissional",150,errors);
            ValidacaoCadastro.Telefone(entity.Telefone,"Telefone do profissional",20,errors);
            ValidacaoCadastro.Referencia(entity.EspecialidadeId,"a especialidade",errors);
        }
        if(context.EntryPoint==DomainEntryPoint.Crud && context.Operation==DomainOperation.Registro && entity.UsuarioAcessoId.HasValue)
            errors.Add("Configure o vínculo de acesso pela ação administrativa.");
        if(context.EntryPoint==DomainEntryPoint.Crud && context.Operation==DomainOperation.Registro && entity.ServicoHabitualId.HasValue)
            errors.Add("Defina o serviço habitual no painel Atendimentos após vincular o profissional.");
    }
}
