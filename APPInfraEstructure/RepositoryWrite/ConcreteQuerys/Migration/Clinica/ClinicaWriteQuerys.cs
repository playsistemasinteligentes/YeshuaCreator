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
        protected readonly ICurrentUser _currentUser;
        public ClinicaQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InserirClinicaQuery(IClinicaEntity Clinica)
        {
            this.Query = $@" INSERT INTO Clinica (Nome, Endereco, Telefone, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@Nome, @Endereco, @Telefone, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Nome = Clinica.Nome,
                Endereco = Clinica.Endereco,
                Telefone = Clinica.Telefone,
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateClinicaQuery(IClinicaEntity Clinica)
        {
            this.Query = $@" UPDATE Clinica SET Nome = @Nome, Endereco = @Endereco, Telefone = @Telefone, TenantID = @TenantID, Deleted = @Deleted, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = Clinica.Nome,
                Endereco = Clinica.Endereco,
                Telefone = Clinica.Telefone,
                TenantID = Clinica.TenantID,
                Deleted = Clinica.Deleted,
                Changed = Clinica.Changed,
                UserId = Clinica.UserId,
                Id = Clinica.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNome(IClinicaEntity entity)
        {
            this.Query = $@" UPDATE Clinica SET Nome = @Nome WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = entity.Nome,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEndereco(IClinicaEntity entity)
        {
            this.Query = $@" UPDATE Clinica SET Endereco = @Endereco WHERE Id = @Id ";
            this.Parameters = new
            {
                Endereco = entity.Endereco,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTelefone(IClinicaEntity entity)
        {
            this.Query = $@" UPDATE Clinica SET Telefone = @Telefone WHERE Id = @Id ";
            this.Parameters = new
            {
                Telefone = entity.Telefone,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IClinicaEntity entity)
        {
            this.Query = $@" UPDATE Clinica SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IClinicaEntity entity)
        {
            this.Query = $@" UPDATE Clinica SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IClinicaEntity entity)
        {
            this.Query = $@" UPDATE Clinica SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IClinicaEntity entity)
        {
            this.Query = $@" UPDATE Clinica SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
                Id = entity.Id,
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