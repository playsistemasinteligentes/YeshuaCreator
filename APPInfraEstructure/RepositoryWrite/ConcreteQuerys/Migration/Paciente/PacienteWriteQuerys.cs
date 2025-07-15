using Dominio.Entitys;
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
        public QueryModel InserirPacienteQuery(IPacienteEntity Paciente)
        {
            this.Query = $@" INSERT INTO Paciente (Nome, Telefone, DataNascimento, Genero, Escolaridade, Profissao, Endereco, NomeResponsavel, TelefoneResponsavel, PrincipaisQueixas, ObservacaoAdicional) OUTPUT INSERTED.Id VALUES(@Nome, @Telefone, @DataNascimento, @Genero, @Escolaridade, @Profissao, @Endereco, @NomeResponsavel, @TelefoneResponsavel, @PrincipaisQueixas, @ObservacaoAdicional) ";
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
        public QueryModel UpdatePacienteQuery(IPacienteEntity Paciente)
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
        public QueryModel UpdateNome(IPacienteEntity entity)
        {
            this.Query = $@" UPDATE Paciente SET Nome = @Nome WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = entity.Nome,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTelefone(IPacienteEntity entity)
        {
            this.Query = $@" UPDATE Paciente SET Telefone = @Telefone WHERE Id = @Id ";
            this.Parameters = new
            {
                Telefone = entity.Telefone,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataNascimento(IPacienteEntity entity)
        {
            this.Query = $@" UPDATE Paciente SET DataNascimento = @DataNascimento WHERE Id = @Id ";
            this.Parameters = new
            {
                DataNascimento = entity.DataNascimento,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGenero(IPacienteEntity entity)
        {
            this.Query = $@" UPDATE Paciente SET Genero = @Genero WHERE Id = @Id ";
            this.Parameters = new
            {
                Genero = entity.Genero,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEscolaridade(IPacienteEntity entity)
        {
            this.Query = $@" UPDATE Paciente SET Escolaridade = @Escolaridade WHERE Id = @Id ";
            this.Parameters = new
            {
                Escolaridade = entity.Escolaridade,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProfissao(IPacienteEntity entity)
        {
            this.Query = $@" UPDATE Paciente SET Profissao = @Profissao WHERE Id = @Id ";
            this.Parameters = new
            {
                Profissao = entity.Profissao,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEndereco(IPacienteEntity entity)
        {
            this.Query = $@" UPDATE Paciente SET Endereco = @Endereco WHERE Id = @Id ";
            this.Parameters = new
            {
                Endereco = entity.Endereco,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNomeResponsavel(IPacienteEntity entity)
        {
            this.Query = $@" UPDATE Paciente SET NomeResponsavel = @NomeResponsavel WHERE Id = @Id ";
            this.Parameters = new
            {
                NomeResponsavel = entity.NomeResponsavel,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTelefoneResponsavel(IPacienteEntity entity)
        {
            this.Query = $@" UPDATE Paciente SET TelefoneResponsavel = @TelefoneResponsavel WHERE Id = @Id ";
            this.Parameters = new
            {
                TelefoneResponsavel = entity.TelefoneResponsavel,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePrincipaisQueixas(IPacienteEntity entity)
        {
            this.Query = $@" UPDATE Paciente SET PrincipaisQueixas = @PrincipaisQueixas WHERE Id = @Id ";
            this.Parameters = new
            {
                PrincipaisQueixas = entity.PrincipaisQueixas,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateObservacaoAdicional(IPacienteEntity entity)
        {
            this.Query = $@" UPDATE Paciente SET ObservacaoAdicional = @ObservacaoAdicional WHERE Id = @Id ";
            this.Parameters = new
            {
                ObservacaoAdicional = entity.ObservacaoAdicional,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeletePacienteQuery(IPacienteEntity Paciente)
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