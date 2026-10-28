using Dominio.Migration;
using Yeshua.Studio.AppClinicas.Domain.Entities;

namespace AppClinicas;

[Migration(000008)]
public sealed class M000008 : MigrationBase
{
    public override void Up()
    {
        // Search projections are deliberately smaller than the complete edit form.
        AlterEntity("Clinica");
        AddQuery<Clinica>("Standard", q => q.Where("Geral", s => s.Nome.Contains(""))
            .Select(s => new { s.Id, s.Nome, s.Telefone }));
        AlterEntity("Especialidade");
        AddQuery<Especialidade>("Standard", q => q.Where("Geral", s => s.Descricao.Contains(""))
            .Select(s => new { s.Id, s.Descricao }));
        AlterEntity("Profissional");
        AddQuery<Profissional>("Standard", q => q.Where("Geral", s => s.Nome.Contains(""))
            .Select(s => new { s.Id, s.Nome, s.Telefone }));
        AlterEntity("DisponibilidadeAgenda");
        AddQuery<DisponibilidadeAgenda>("Standard", q => q.Where("Geral", s => s.ProfissionalId == 0 && s.DataHora >= DateTime.Today)
            .Select(s => new { s.Id, s.ProfissionalId, s.DataHora }));
        AlterEntity("GrupoServico");
        AddQuery<GrupoServico>("Standard", q => q.Where("Geral", s => s.Descricao.Contains(""))
            .Select(s => new { s.Id, s.Descricao }));
        AlterEntity("Servico");
        AddQuery<Servico>("Standard", q => q.Where("Geral", s => s.Nome.Contains(""))
            .Select(s => new { s.Id, s.Nome, s.Valor, s.ModeloConsulta }));
        AlterEntity("Paciente")
            .AlterColumn("Genero", "Gênero").Int().Enumerable(1, "Masculino").Enumerable(2, "Feminino").Enumerable(3, "Outros")
            .AlterColumn("DataNascimento", "Data de nascimento").DateTime()
            .AlterColumn("NomeResponsavel", "Nome do responsável").Varchar(250)
            .AlterColumn("TelefoneResponsavel", "Telefone do responsável").Varchar(15)
            .AlterColumn("Observacao", "Observações").Varchar(2000, true);
        AddQuery<Paciente>("Standard", q => q.Where("Geral", s => s.Nome.Contains("") && s.Telefone == "")
            .Select(s => new { s.Id, s.Nome, s.Telefone, s.DataNascimento }));
        AlterEntity("Sesoes");
        AddQuery<Sesoes>("Standard", q => q.Where("Geral", s => s.PacienteId == 0 && s.DataInicio >= DateTime.Today)
            .Select(s => new { s.Id, s.PacienteId, s.DataInicio, s.DataFim, s.StatusAgendamento }));
        AlterEntity("RevisaoRegistroSessao");
        AddQuery<RevisaoRegistroSessao>("Standard", q => q.Where("Geral", s => s.SessaoId == 0)
            .Select(s => new { s.Id, s.SessaoId, s.Versao, s.RevisadoEm }));
        AlterEntity("MovimentacaoFinanceira");
        AddQuery<MovimentacaoFinanceira>("Standard", q => q.Where("Geral", s => s.PacienteId == 0 && s.DataMovimentacao >= DateTime.Today)
            .Select(s => new { s.Id, s.PacienteId, s.Valor, s.TipoMovimentacao, s.DataMovimentacao }));
        AlterEntity("PlanoConta");
        AddQuery<PlanoConta>("Standard", q => q.Where("Geral", s => s.Nome.Contains("") && s.Codigo.Contains(""))
            .Select(s => new { s.Id, s.Codigo, s.Nome, s.Tipo }));
        AlterEntity("MovimentoFinanceiro");
        AddQuery<MovimentoFinanceiro>("Standard", q => q.Where("Geral", s => s.IdOrigem.Contains("") && s.DataMovimento >= DateTime.Today)
            .Select(s => new { s.Id, s.IdOrigem, s.Valor, s.DataMovimento, s.Status }));
    }
}
