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
    public class EspecialidadeQueryWrite : QueryBase, IEspecialidadeQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public EspecialidadeQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirEspecialidadeQuery(IEspecialidadeEntity Especialidade)
        {
            this.Query = $@" INSERT INTO Especialidade (Descricao, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@Descricao, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Descricao = Especialidade.Descricao,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEspecialidadeQuery(IEspecialidadeEntity Especialidade)
        {
            this.Query = $@" UPDATE Especialidade SET Descricao = @Descricao, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                Descricao = Especialidade.Descricao,
                Changed = Especialidade.Changed,
                UserId = _executionContext.UserId,
                Id = Especialidade.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescricao(int id, string value)
        {
            this.Query = $@" UPDATE Especialidade SET Descricao = @Descricao WHERE Id = @Id ";
            this.Parameters = new
            {
                Descricao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Especialidade SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Especialidade SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Especialidade SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Especialidade SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteEspecialidadeQuery(IEspecialidadeEntity Especialidade)
        {
            this.Query = $@" DELETE FROM Especialidade WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Especialidade.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration