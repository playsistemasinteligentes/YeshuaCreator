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
        protected readonly ICurrentUser _currentUser;
        public PacienteQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
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
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
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
                UserId = _currentUser.UserId,
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
        public QueryModel UpdateObservacao(IPacienteEntity entity)
        {
            this.Query = $@" UPDATE Paciente SET Observacao = @Observacao WHERE Id = @Id ";
            this.Parameters = new
            {
                Observacao = entity.Observacao,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IPacienteEntity entity)
        {
            this.Query = $@" UPDATE Paciente SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IPacienteEntity entity)
        {
            this.Query = $@" UPDATE Paciente SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IPacienteEntity entity)
        {
            this.Query = $@" UPDATE Paciente SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IPacienteEntity entity)
        {
            this.Query = $@" UPDATE Paciente SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
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
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration