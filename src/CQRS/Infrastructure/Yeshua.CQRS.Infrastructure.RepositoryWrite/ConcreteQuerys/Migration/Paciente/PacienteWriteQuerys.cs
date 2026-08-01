using Dominio.Entitys;
using Shered.DB;
using Command.Write;
using IQuery.Write;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Write
{
    public class PacienteQueryWrite : QueryBase, IPacienteQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public PacienteQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirPacienteQuery(IPacienteEntity Paciente)
        {
            this.Query = $@" INSERT INTO Paciente (Nome, Telefone, DataNascimento, Genero, Escolaridade, Profissao, Endereco, NomeResponsavel, TelefoneResponsavel, Observacao, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@Nome, @Telefone, @DataNascimento, @Genero, @Escolaridade, @Profissao, @Endereco, @NomeResponsavel, @TelefoneResponsavel, @Observacao, @TenantID, @Deleted, @Changed, @UserId) ";
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
                Observacao = Paciente.Observacao,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePacienteQuery(IPacienteEntity Paciente)
        {
            this.Query = $@" UPDATE Paciente SET Nome = @Nome, Telefone = @Telefone, DataNascimento = @DataNascimento, Genero = @Genero, Escolaridade = @Escolaridade, Profissao = @Profissao, Endereco = @Endereco, NomeResponsavel = @NomeResponsavel, TelefoneResponsavel = @TelefoneResponsavel, Observacao = @Observacao, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
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
                Observacao = Paciente.Observacao,
                Changed = Paciente.Changed,
                UserId = _executionContext.UserId,
                Id = Paciente.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNome(int id, string value)
        {
            this.Query = $@" UPDATE Paciente SET Nome = @Nome WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTelefone(int id, string value)
        {
            this.Query = $@" UPDATE Paciente SET Telefone = @Telefone WHERE Id = @Id ";
            this.Parameters = new
            {
                Telefone = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDataNascimento(int id, DateTime value)
        {
            this.Query = $@" UPDATE Paciente SET DataNascimento = @DataNascimento WHERE Id = @Id ";
            this.Parameters = new
            {
                DataNascimento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGenero(int id, int value)
        {
            this.Query = $@" UPDATE Paciente SET Genero = @Genero WHERE Id = @Id ";
            this.Parameters = new
            {
                Genero = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEscolaridade(int id, string value)
        {
            this.Query = $@" UPDATE Paciente SET Escolaridade = @Escolaridade WHERE Id = @Id ";
            this.Parameters = new
            {
                Escolaridade = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProfissao(int id, string value)
        {
            this.Query = $@" UPDATE Paciente SET Profissao = @Profissao WHERE Id = @Id ";
            this.Parameters = new
            {
                Profissao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEndereco(int id, string value)
        {
            this.Query = $@" UPDATE Paciente SET Endereco = @Endereco WHERE Id = @Id ";
            this.Parameters = new
            {
                Endereco = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNomeResponsavel(int id, string value)
        {
            this.Query = $@" UPDATE Paciente SET NomeResponsavel = @NomeResponsavel WHERE Id = @Id ";
            this.Parameters = new
            {
                NomeResponsavel = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTelefoneResponsavel(int id, string value)
        {
            this.Query = $@" UPDATE Paciente SET TelefoneResponsavel = @TelefoneResponsavel WHERE Id = @Id ";
            this.Parameters = new
            {
                TelefoneResponsavel = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateObservacao(int id, string value)
        {
            this.Query = $@" UPDATE Paciente SET Observacao = @Observacao WHERE Id = @Id ";
            this.Parameters = new
            {
                Observacao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Paciente SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Paciente SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Paciente SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Paciente SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
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
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration