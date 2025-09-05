using System;

namespace MyApp.Domain.Entities
{
    public class Sesoes
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public int ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }

        public int MovimentacaoFinanceiraId { get; set; }
        public MovimentacaoFinanceira MovimentacaoFinanceira { get; set; }

        public static MyApp.QueryBuilder.Query<Sesoes> Query() => new MyApp.QueryBuilder.Query<Sesoes>();
    }

    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
    }

    public class Profissional
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; }
    }

    public class Especialidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }

    public class MovimentacaoFinanceira
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
    }
}
