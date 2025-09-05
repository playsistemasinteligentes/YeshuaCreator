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
    public class ProfissionalQueryWrite : QueryBase, IProfissionalQueryWrite
    {
        protected readonly ICurrentUser _currentUser;
        public ProfissionalQueryWrite(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public QueryModel InserirProfissionalQuery(IProfissionalEntity Profissional)
        {
            this.Query = $@" INSERT INTO Profissional (Nome, EspecialidadeId, Telefone, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@Nome, @EspecialidadeId, @Telefone, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Nome = Profissional.Nome,
                EspecialidadeId = Profissional.EspecialidadeId,
                Telefone = Profissional.Telefone,
                TenantID = _currentUser.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _currentUser.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProfissionalQuery(IProfissionalEntity Profissional)
        {
            this.Query = $@" UPDATE Profissional SET Nome = @Nome, EspecialidadeId = @EspecialidadeId, Telefone = @Telefone, TenantID = @TenantID, Deleted = @Deleted, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = Profissional.Nome,
                EspecialidadeId = Profissional.EspecialidadeId,
                Telefone = Profissional.Telefone,
                TenantID = Profissional.TenantID,
                Deleted = Profissional.Deleted,
                Changed = Profissional.Changed,
                UserId = Profissional.UserId,
                Id = Profissional.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNome(IProfissionalEntity entity)
        {
            this.Query = $@" UPDATE Profissional SET Nome = @Nome WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = entity.Nome,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEspecialidadeId(IProfissionalEntity entity)
        {
            this.Query = $@" UPDATE Profissional SET EspecialidadeId = @EspecialidadeId WHERE Id = @Id ";
            this.Parameters = new
            {
                EspecialidadeId = entity.EspecialidadeId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTelefone(IProfissionalEntity entity)
        {
            this.Query = $@" UPDATE Profissional SET Telefone = @Telefone WHERE Id = @Id ";
            this.Parameters = new
            {
                Telefone = entity.Telefone,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(IProfissionalEntity entity)
        {
            this.Query = $@" UPDATE Profissional SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = entity.TenantID,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(IProfissionalEntity entity)
        {
            this.Query = $@" UPDATE Profissional SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = entity.Deleted,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(IProfissionalEntity entity)
        {
            this.Query = $@" UPDATE Profissional SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = entity.Changed,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(IProfissionalEntity entity)
        {
            this.Query = $@" UPDATE Profissional SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = entity.UserId,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteProfissionalQuery(IProfissionalEntity Profissional)
        {
            this.Query = $@" DELETE FROM Profissional WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Profissional.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration