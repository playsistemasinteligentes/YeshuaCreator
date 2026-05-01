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
            this.Query = $@" UPDATE Profissional SET Nome = @Nome, EspecialidadeId = @EspecialidadeId, Telefone = @Telefone, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = Profissional.Nome,
                EspecialidadeId = Profissional.EspecialidadeId,
                Telefone = Profissional.Telefone,
                Changed = Profissional.Changed,
                UserId = _currentUser.UserId,
                Id = Profissional.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNome(int id, string value)
        {
            this.Query = $@" UPDATE Profissional SET Nome = @Nome WHERE Id = @Id ";
            this.Parameters = new
            {
                Nome = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEspecialidadeId(int id, int value)
        {
            this.Query = $@" UPDATE Profissional SET EspecialidadeId = @EspecialidadeId WHERE Id = @Id ";
            this.Parameters = new
            {
                EspecialidadeId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTelefone(int id, string value)
        {
            this.Query = $@" UPDATE Profissional SET Telefone = @Telefone WHERE Id = @Id ";
            this.Parameters = new
            {
                Telefone = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Profissional SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Profissional SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Profissional SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Profissional SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
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