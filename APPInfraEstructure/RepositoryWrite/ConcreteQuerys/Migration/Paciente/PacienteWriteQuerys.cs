using Dominio.Entitys.Paciente;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.Paciente
{
    public class PacienteWriteQuery : QueryBase
    {
        public QueryModel InserirPacienteQuery(PacienteEntity Paciente)
        {
            this.Query = $@" INSERT INTO Paciente (Nome, Telefone, DataNascimento, Genero, Escolaridade, Profissao, Endereco, NomeResponsavel, TelefoneResponsavel, PrincipaisQueixas, ObservacaoAdicional) VALUES(@Nome, @Telefone, @DataNascimento, @Genero, @Escolaridade, @Profissao, @Endereco, @NomeResponsavel, @TelefoneResponsavel, @PrincipaisQueixas, @ObservacaoAdicional) ";
            this.Parameters = new
            {
                Nome = Paciente.Nome,
                Telefone = Paciente.Telefone,
                DataNascimento = Paciente.DataNascimento,
                Genero = Paciente.Genero,
                Escolaridade = Paciente.Escolaridade,
                Profissao = Paciente.Profissao,
                Endereco = Paciente.Endereco,
                NomeResponsavel = Paciente.NomeResponsavel,
                TelefoneResponsavel = Paciente.TelefoneResponsavel,
                PrincipaisQueixas = Paciente.PrincipaisQueixas,
                ObservacaoAdicional = Paciente.ObservacaoAdicional,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePacienteQuery(PacienteEntity Paciente)
        {
            this.Query = $@" UPDATE Paciente SET Nome = @Nome, Telefone = @Telefone, DataNascimento = @DataNascimento, Genero = @Genero, Escolaridade = @Escolaridade, Profissao = @Profissao, Endereco = @Endereco, NomeResponsavel = @NomeResponsavel, TelefoneResponsavel = @TelefoneResponsavel, PrincipaisQueixas = @PrincipaisQueixas, ObservacaoAdicional = @ObservacaoAdicional WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = Paciente.Nome,
                Telefone = Paciente.Telefone,
                DataNascimento = Paciente.DataNascimento,
                Genero = Paciente.Genero,
                Escolaridade = Paciente.Escolaridade,
                Profissao = Paciente.Profissao,
                Endereco = Paciente.Endereco,
                NomeResponsavel = Paciente.NomeResponsavel,
                TelefoneResponsavel = Paciente.TelefoneResponsavel,
                PrincipaisQueixas = Paciente.PrincipaisQueixas,
                ObservacaoAdicional = Paciente.ObservacaoAdicional,
                Id = Paciente.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeletePacienteQuery(PacienteEntity Paciente)
        {
            this.Query = $@" DELETE FROM Paciente WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Paciente.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteQuerysMigration