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
    public class ClinicaQueryWrite : QueryBase, IClinicaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ClinicaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirClinicaQuery(IClinicaEntity Clinica)
        {
            this.Query = $@" INSERT INTO Clinica (Nome, Endereco, Telefone, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@Nome, @Endereco, @Telefone, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Nome = Clinica.Nome,
                Endereco = Clinica.Endereco,
                Telefone = Clinica.Telefone,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateClinicaQuery(IClinicaEntity Clinica)
        {
            this.Query = $@" UPDATE Clinica SET Nome = @Nome, Endereco = @Endereco, Telefone = @Telefone, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = Clinica.Nome,
                Endereco = Clinica.Endereco,
                Telefone = Clinica.Telefone,
                Changed = Clinica.Changed,
                UserId = _executionContext.UserId,
                Id = Clinica.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNome(int id, string value)
        {
            this.Query = $@" UPDATE Clinica SET Nome = @Nome WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEndereco(int id, string value)
        {
            this.Query = $@" UPDATE Clinica SET Endereco = @Endereco WHERE Id = @Id ";
            this.Parameters = new
            {
                Endereco = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTelefone(int id, string value)
        {
            this.Query = $@" UPDATE Clinica SET Telefone = @Telefone WHERE Id = @Id ";
            this.Parameters = new
            {
                Telefone = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Clinica SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Clinica SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Clinica SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Clinica SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteClinicaQuery(IClinicaEntity Clinica)
        {
            this.Query = $@" DELETE FROM Clinica WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Clinica.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration