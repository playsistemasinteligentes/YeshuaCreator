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
        protected readonly ICurrentUser _correntUser;
        public EspecialidadeQueryWrite(ICurrentUser correntUser)
        {
            _correntUser = correntUser;
        }
        public QueryModel InserirEspecialidadeQuery(IEspecialidadeEntity Especialidade)
        {
            this.Query = $@" INSERT INTO Especialidade (Descricao) OUTPUT INSERTED.Id VALUES(@Descricao) ";
            this.Parameters = new
            {
                Descricao = Especialidade.Descricao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEspecialidadeQuery(IEspecialidadeEntity Especialidade)
        {
            this.Query = $@" UPDATE Especialidade SET Descricao = @Descricao WHERE Id = @Id ";
            this.Parameters = new
            {
                Descricao = Especialidade.Descricao,
                Id = Especialidade.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescricao(IEspecialidadeEntity entity)
        {
            this.Query = $@" UPDATE Especialidade SET Descricao = @Descricao WHERE Id = @Id ";
            this.Parameters = new
            {
                Descricao = entity.Descricao,
                Id = entity.Id,
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